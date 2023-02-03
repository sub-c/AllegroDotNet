using Ex.Common;
using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using System;

namespace Ex.Camera;

internal static class Program
{
  public struct Vector
  {
    public float x, y, z;
  }

  public struct Camera
  {
    public Vector position;
    public Vector xaxis; /* This represent the direction looking to the right. */
    public Vector yaxis; /* This is the up direction. */
    public Vector zaxis; /* This is the direction towards the viewer ('backwards'). */
    public double vertical_field_of_view; /* In radians. */
  }

  public struct Example
  {
    public Camera camera;

    /* controls sensitivity */
    public double mouse_look_speed;
    public double movement_speed;

    /* keyboard and mouse state */
    public int[] button;
    public int[] key;
    public int[] keystate;
    public int mouse_dx, mouse_dy;

    /* control scheme selection */
    public int controls;
    public string[] controls_names;

    /* the vertex data */
    public int n, v_size;
    public AllegroVertex[] v;

    /* used to draw some info text */
    public AllegroFont? font;

    /* if not NULL the skybox picture to use */
    public AllegroBitmap? skybox;
  }

  public static Example ex;

  /* Calculate the dot product between two vectors. This corresponds to the
  * angle between them times their lengths.
  */
  public static double vector_dot_product(Vector a, Vector b)
  {
    return a.x * b.x + a.y * b.y + a.z * b.z;
  }

  /* Calculate the cross product of two vectors. This produces a normal to the
  * plane containing the operands.
  */
  static Vector vector_cross_product(Vector a, Vector b)
  {
    Vector v = new()
    {
      x = a.y * b.z - a.z * b.y,
      y = a.z * b.x - a.x * b.z,
      z = a.x * b.y - a.y * b.x
    };
    return v;
  }

  /* Return a vector multiplied by a scalar. */
  static Vector vector_mul(Vector a, float s)
  {
    Vector v = new()
    {
      x = a.x * s,
      y = a.y * s,
      z = a.z * s
    };
    return v;
  }

  /* Return the vector norm (length). */
  static double vector_norm(Vector a)
  {
    return Math.Sqrt(vector_dot_product(a, a));
  }

  /* Return a normalized version of the given vector. */
  static Vector vector_normalize(Vector a)
  {
    double s = vector_norm(a);
    if (s == 0)
      return a;
    return vector_mul(a, (float)(1 / s));
  }

  /* In-place add another vector to a vector. */
  static void vector_iadd(ref Vector a, Vector b)
  {
    a.x += b.x;
    a.y += b.y;
    a.z += b.z;
  }

  /* Rotate the camera around the given axis. */
  static void camera_rotate_around_axis(ref Camera c, Vector axis, double radians)
  {
    var t = new AllegroTransform();
    Al.IdentityTransform(t);
    Al.RotateTransform3D(t, axis.x, axis.y, axis.z, (float)radians);
    Al.TransformCoordinates3D(t, ref c.yaxis.x, ref c.yaxis.y, ref c.yaxis.z);
    Al.TransformCoordinates3D(t, ref c.zaxis.x, ref c.zaxis.y, ref c.zaxis.z);

    /* Make sure the axes remain orthogonal to each other. */
    c.zaxis = vector_normalize(c.zaxis);
    c.xaxis = vector_cross_product(c.yaxis, c.zaxis);
    c.xaxis = vector_normalize(c.xaxis);
    c.yaxis = vector_cross_product(c.zaxis, c.xaxis);
  }

  /* Move the camera along its x axis and z axis (which corresponds to
  * right and backwards directions).
  */
  static void camera_move_along_direction(ref Camera camera, double right, double forward)
  {
    vector_iadd(ref camera.position, vector_mul(camera.xaxis, (float)right));
    vector_iadd(ref camera.position, vector_mul(camera.zaxis, (float)-forward));
  }

  /* Get a vector with y = 0 looking in the opposite direction as the camera z
  * axis. If looking straight up or down returns a 0 vector instead.
  */
  static Vector get_ground_forward_vector(ref Camera camera)
  {
    Vector move = vector_mul(camera.zaxis, -1);
    move.y = 0;
    return vector_normalize(move);
  }

  /* Get a vector with y = 0 looking in the same direction as the camera x axis.
  * If looking straight up or down returns a 0 vector instead.
  */
  static Vector get_ground_right_vector(ref Camera camera)
  {
    Vector move = camera.xaxis;
    move.y = 0;
    return vector_normalize(move);
  }

  /* Like camera_move_along_direction but moves the camera along the ground plane
  * only.
  */
  static void camera_move_along_ground(ref Camera camera, double right, double forward)
  {
    Vector f = get_ground_forward_vector(ref camera);
    Vector r = get_ground_right_vector(ref camera);
    camera.position.x += (float)(f.x * forward + r.x * right);
    camera.position.z += (float)(f.z * forward + r.z * right);
  }

  /* Calculate the pitch of the camera. This is the angle between the z axis
  * vector and our direction vector on the y = 0 plane.
  */
  static double get_pitch(ref Camera c)
  {
    Vector f = get_ground_forward_vector(ref c);
    return Math.Asin(vector_dot_product(f, c.yaxis));
  }

  /* Calculate the yaw of the camera. This is basically the compass direction.
  */
  static double get_yaw(ref Camera c)
  {
    return Math.Atan2(c.zaxis.x, c.zaxis.z);
  }

  /* Calculate the roll of the camera. This is the angle between the x axis
  * vector and its project on the y = 0 plane.
  */
  static double get_roll(ref Camera c)
  {
    Vector r = get_ground_right_vector(ref c);
    return Math.Asin(vector_dot_product(r, c.yaxis));
  }

  /* Set up a perspective transform. We make the screen span
  * 2 vertical units (-1 to +1) with square pixel aspect and the camera's
  * vertical field of view. Clip distance is always set to 1.
  */
  static void setup_3d_projection()
  {
    var projection = new AllegroTransform();
    var display = Al.GetCurrentDisplay();
    double dw = Al.GetDisplayWidth(display);
    double dh = Al.GetDisplayHeight(display);
    double f;
    Al.IdentityTransform(projection);
    Al.TranslateTransform3D(projection, 0, 0, -1);
    f = Math.Tan(ex.camera.vertical_field_of_view / 2);
    Al.PerspectiveTransform(projection, (float)(-1 * dw / dh * f), (float)f,
       1,
       (float)(f * dw / dh), (float)-f, 1000);
    Al.UseProjectionTransform(projection);
  }

  /* Adds a new vertex to our scene. */
  static void add_vertex(double x, double y, double z, double u, double v, AllegroColor color)
  {
    int i = ex.n++;
    //if (i >= ex.v_size)
    if (ex.v is null || i >= ex.v.Length)
    {
      ex.v_size += 1;
      ex.v_size *= 2;
      
      //ex.v = realloc(ex.v, ex.v_size * sizeof *ex.v);
      if (ex.v is null || ex.v.Length == 0)
      {
        ex.v = new AllegroVertex[1];
      }
      else
      {
        var oldArray = ex.v;
        ex.v = new AllegroVertex[ex.v_size];
        Array.Copy(oldArray, ex.v, oldArray.Length);
      }
    }
    ex.v[i].x = (float)x;
    ex.v[i].y = (float)y;
    ex.v[i].z = (float)z;
    ex.v[i].u = (float)u;
    ex.v[i].v = (float)v;
    ex.v[i].color = color;
  }

  /* Adds two triangles (6 vertices) to the scene. */
  static void add_quad(double x, double y, double z, double u, double v,
     double ux, double uy, double uz, double uu, double uv,
     double vx, double vy, double vz, double vu, double vv,
     AllegroColor c1, AllegroColor c2)
  {
    add_vertex(x, y, z, u, v, c1);
    add_vertex(x + ux, y + uy, z + uz, u + uu, v + uv, c1);
    add_vertex(x + vx, y + vy, z + vz, u + vu, v + vv, c2);
    add_vertex(x + vx, y + vy, z + vz, u + vu, v + vv, c2);
    add_vertex(x + ux, y + uy, z + uz, u + uu, v + uv, c1);
    add_vertex(x + ux + vx, y + uy + vy, z + uz + vz, u + uu + vu,
       v + uv + vv, c2);
  }

  /* Create a checkerboard made from colored quads. */
  static void add_checkerboard()
  {
    int x, y;
    AllegroColor c1 = Al.MapRgb(0, 255, 255); //yellow
    AllegroColor c2 = Al.MapRgb(0, 255, 0); //al_color_name("green");

    for (y = 0; y < 20; y++)
    {
      for (x = 0; x < 20; x++)
      {
        double px = x - 20 * 0.5;
        double py = 0.2;
        double pz = y - 20 * 0.5;
        AllegroColor c = c1;
        if (((x + y) & 1) != 0) // TODO, is this right? non-zero is true in C?
        {
          c = c2;
          py -= 0.1;
        }
        add_quad(px, py, pz, 0, 0,
           1, 0, 0, 0, 0,
           0, 0, 1, 0, 0,
           c, c);
      }
    }
  }

  /* Create a skybox. This is simply 5 quads with a fixed distance to the
  * camera.
  */
  static void add_skybox()
  {
    Vector p = ex.camera.position;
    AllegroColor c1 = Al.MapRgb(0, 0, 0); // al_color_name("black");
    AllegroColor c2 = Al.MapRgb(0, 0, 255); // al_color_name("blue");
    AllegroColor c3 = Al.MapRgb(255, 255, 255); // al_color_name("white");

    double a = 0, b = 0;
    if (ex.skybox != null)
    {
      a = Al.GetBitmapWidth(ex.skybox) / 4.0;
      b = Al.GetBitmapHeight(ex.skybox) / 3.0;
      c1 = c2 = c3;
    }

    /* Back skybox wall. */
    add_quad(p.x - 50, p.y - 50, p.z - 50, a * 4, b * 2,
       100, 0, 0, -a, 0,
       0, 100, 0, 0, -b,
       c1, c2);
    /* Front skybox wall. */
    add_quad(p.x - 50, p.y - 50, p.z + 50, a, b * 2,
       100, 0, 0, a, 0,
       0, 100, 0, 0, -b,
       c1, c2);
    /* Left skybox wall. */
    add_quad(p.x - 50, p.y - 50, p.z - 50, 0, b * 2,
       0, 0, 100, a, 0,
       0, 100, 0, 0, -b,
       c1, c2);
    /* Right skybox wall. */
    add_quad(p.x + 50, p.y - 50, p.z - 50, a * 3, b * 2,
       0, 0, 100, -a, 0,
       0, 100, 0, 0, -b,
       c1, c2);

    /* Top of skybox. */
    add_vertex(p.x - 50, p.y + 50, p.z - 50, a, 0, c2);
    add_vertex(p.x + 50, p.y + 50, p.z - 50, a * 2, 0, c2);
    add_vertex(p.x, p.y + 50, p.z, a * 1.5, b * 0.5, c3);

    add_vertex(p.x + 50, p.y + 50, p.z - 50, a * 2, 0, c2);
    add_vertex(p.x + 50, p.y + 50, p.z + 50, a * 2, b, c2);
    add_vertex(p.x, p.y + 50, p.z, a * 1.5, b * 0.5, c3);

    add_vertex(p.x + 50, p.y + 50, p.z + 50, a * 2, b, c2);
    add_vertex(p.x - 50, p.y + 50, p.z + 50, a, b, c2);
    add_vertex(p.x, p.y + 50, p.z, a * 1.5, b * 0.5, c3);

    add_vertex(p.x - 50, p.y + 50, p.z + 50, a, b, c2);
    add_vertex(p.x - 50, p.y + 50, p.z - 50, a, 0, c2);
    add_vertex(p.x, p.y + 50, p.z, a * 1.5, b * 0.5, c3);
  }

  static void draw_scene()
  {
    //Camera* c = &ex.camera;
    /* We save Allegro's projection so we can restore it for drawing text. */
    var projection = Al.GetCurrentProjectionTransform(); //*al_get_current_projection_transform();
    AllegroTransform t = new AllegroTransform();
    var back = Al.MapRgb(0, 0, 0); //al_color_name("black");
    var front = Al.MapRgb(255, 255, 255); //al_color_name("white");
    int th;
    double pitch, yaw, roll;

    setup_3d_projection();
    //al_clear_to_color(back);
    Al.ClearToColor(back);

    /* We use a depth buffer. */
    Al.SetRenderState(RenderState.DepthTest, 1); //al_set_render_state(ALLEGRO_DEPTH_TEST, 1);
    Al.ClearDepthBuffer(1); //al_clear_depth_buffer(1);

    /* Recreate the entire scene geometry - this is only a very small example
     * so this is fine.
     */
    ex.n = 0;
    add_checkerboard();
    add_skybox();

    /* Construct a transform corresponding to our camera. This is an inverse
     * translation by the camera position, followed by an inverse rotation
     * from the camera orientation.
     */
    Al.BuildCameraTransform(t,
      ex.camera.position.x, ex.camera.position.y, ex.camera.position.z,
      ex.camera.position.x - ex.camera.zaxis.x,
      ex.camera.position.y - ex.camera.zaxis.y,
      ex.camera.position.z - ex.camera.zaxis.z,
      ex.camera.yaxis.x, ex.camera.yaxis.y, ex.camera.yaxis.z);
    Al.UseTransform(t);
    Al.DrawPrim(ex.v, null, ex.skybox, 0, ex.n, PrimitiveType.TriangleList);

    Al.IdentityTransform(t);
    Al.UseTransform(t);
    Al.UseProjectionTransform(projection);
    Al.SetRenderState(RenderState.DepthTest, 0);

    /* Draw some text. */
    th = Al.GetFontLineHeight(ex.font);
    Al.DrawText(ex.font, front, 0, th * 0, 0, "look: %+3.1f/%+3.1f/%+3.1f (change with left mouse button and drag)");
    pitch = get_pitch(ref ex.camera) * 180 / Al.ALLEGRO_PI;
    yaw = get_yaw(ref ex.camera) * 180 / Al.ALLEGRO_PI;
    roll = get_roll(ref ex.camera) * 180 / Al.ALLEGRO_PI;
    Al.DrawText(ex.font, front, 0, th * 1, 0, "pitch: %+4.0f yaw: %+4.0f roll: %+4.0f");
    Al.DrawText(ex.font, front, 0, th * 2, 0, "vertical field of view: %3.1f (change with Z/X)");
    Al.DrawText(ex.font, front, 0, th * 3, 0, "move with WASD or cursor\")");
    Al.DrawText(ex.font, front, 0, th * 4, 0, "control style: %s (space to change)");
  }

  static void setup_scene()
  {
    ex.camera.xaxis.x = 1;
    ex.camera.yaxis.y = 1;
    ex.camera.zaxis.z = 1;
    ex.camera.position.y = 2;
    ex.camera.vertical_field_of_view = 60 * Al.ALLEGRO_PI / 180;

    ex.mouse_look_speed = 0.03;
    ex.movement_speed = 0.05;

    ex.controls_names[0] = "FPS";
    ex.controls_names[1] = "airplane";
    ex.controls_names[2] = "spaceship";

    ex.font = Al.CreateBuiltinFont();
  }

  static void handle_input()
  {
    double x = 0, y = 0;
    double xy;
    if (ex.key[(int)KeyCode.KeyA] != 0 || ex.key[(int)KeyCode.KeyLeft] != 0) x = -1;
    if (ex.key[(int)KeyCode.KeyS] != 0 || ex.key[(int)KeyCode.KeyDown] != 0) y = -1;
    if (ex.key[(int)KeyCode.KeyD] != 0 || ex.key[(int)KeyCode.KeyRight] != 0) x = 1;
    if (ex.key[(int)KeyCode.KeyW] != 0 || ex.key[(int)KeyCode.KeyUp] != 0) y = 1;

    /* Change field of view with Z/X. */
    if (ex.key[(int)KeyCode.KeyZ] != 0)
    {
      double m = 20 * Al.ALLEGRO_PI / 180;
      ex.camera.vertical_field_of_view -= 0.01;
      if (ex.camera.vertical_field_of_view < m)
        ex.camera.vertical_field_of_view = m;
    }
    if (ex.key[(int)KeyCode.KeyX] != 0)
    {
      double m = 120 * Al.ALLEGRO_PI / 180;
      ex.camera.vertical_field_of_view += 0.01;
      if (ex.camera.vertical_field_of_view > m)
        ex.camera.vertical_field_of_view = m;
    }

    /* In FPS style, always move the camera to height 2. */
    if (ex.controls == 0)
    {
      if (ex.camera.position.y > 2)
        ex.camera.position.y -= (float)0.1;
      if (ex.camera.position.y < 2)
        ex.camera.position.y = 2;
    }

    /* Set the roll (leaning) angle to 0 if not in airplane style. */
    if (ex.controls == 0 || ex.controls == 2)
    {
      double roll = get_roll(ref ex.camera);
      camera_rotate_around_axis(ref ex.camera, ex.camera.zaxis, roll / 60);
    }

    /* Move the camera, either freely or along the ground. */
    xy = Math.Sqrt(x * x + y * y);
    if (xy > 0)
    {
      x /= xy;
      y /= xy;
      if (ex.controls == 0)
      {
        camera_move_along_ground(ref ex.camera, ex.movement_speed * x,
           ex.movement_speed * y);
      }
      if (ex.controls == 1 || ex.controls == 2)
      {
        camera_move_along_direction(ref ex.camera, ex.movement_speed * x,
           ex.movement_speed * y);
      }
    }

    /* Rotate the camera, either freely or around world up only. */
    if (ex.button[1] != 0)
    {
      if (ex.controls == 0 || ex.controls == 2)
      {
        //Vector up = { 0, 1, 0 };
        Vector up = new Vector { x = 0, y = 1, z = 0 };
        camera_rotate_around_axis(ref ex.camera, ex.camera.xaxis,
           -ex.mouse_look_speed * ex.mouse_dy);
        camera_rotate_around_axis(ref ex.camera, up,
           -ex.mouse_look_speed * ex.mouse_dx);
      }
      if (ex.controls == 1)
      {
        camera_rotate_around_axis(ref ex.camera, ex.camera.xaxis,
           -ex.mouse_look_speed * ex.mouse_dy);
        camera_rotate_around_axis(ref ex.camera, ex.camera.zaxis,
           -ex.mouse_look_speed * ex.mouse_dx);
      }
    }
  }

  static void Main(string[] args)
  {
    AllegroDisplay? display;
    AllegroTimer? timer;
    AllegroEventQueue? queue;
    int redraw = 0;
    string skybox_name = string.Empty;

    ex.button = new int[10];
    ex.key = new int[(int)KeyCode.KeyMax];
    ex.keystate = new int[(int)KeyCode.KeyMax];
    ex.controls_names = new string[3];

    if (args.Length > 1)
      skybox_name = args[1];

    if (!Al.Init())
      ExCommon.abort_example("Could not init ALlegro.");
    Al.InitFontAddon();
    Al.InitPrimitivesAddon();
    Al.InstallKeyboard();
    Al.InstallMouse();

    Al.SetNewDisplayOption(DisplayOption.SampleBuffers, 1, DisplayImportance.Suggest);
    Al.SetNewDisplayOption(DisplayOption.Samples, 8, DisplayImportance.Suggest);
    Al.SetNewDisplayOption(DisplayOption.DepthSize, 16, DisplayImportance.Suggest);
    Al.SetNewDisplayFlags(DisplayFlags.Resizable);
    display = Al.CreateDisplay(640, 360);
    if (display is null)
      ExCommon.abort_example("Error creating display");

    if (!string.IsNullOrEmpty(skybox_name))
    {
      Al.InitImageAddon();
      ex.skybox = Al.LoadBitmap(skybox_name);
      if (ex.skybox is not null)
        Console.WriteLine($"Loaded skybox {skybox_name}: {Al.GetBitmapWidth(ex.skybox)} x {Al.GetBitmapHeight(ex.skybox)}");
      else
        Console.WriteLine($"Failed loading skybox {skybox_name}");
    }

    timer = Al.CreateTimer(1.0 / 60);

    queue = Al.CreateEventQueue();
    Al.RegisterEventSource(queue, Al.GetKeyboardEventSource());
    Al.RegisterEventSource(queue, Al.GetMouseEventSource());
    Al.RegisterEventSource(queue, Al.GetDisplayEventSource(display));
    Al.RegisterEventSource(queue, Al.GetTimerEventSource(timer));

    setup_scene();

    AllegroEvent @event = new AllegroEvent();
    Al.StartTimer(timer);
    while (true)
    {
      Al.WaitForEvent(queue, @event);

      if (@event.Type == EventType.DisplayClose)
        break;
      else if (@event.Type == EventType.DisplayResize)
        Al.AcknowledgeResize(display);
      else if (@event.Type == EventType.KeyDown)
      {
        if (@event.KeyCode == KeyCode.KeyEscape)
          break;
        if (@event.KeyCode == KeyCode.KeySpace)
        {
          ex.controls++;
          ex.controls %= 3;
        }

        ex.key[(int)@event.KeyCode] = 1;
        ex.keystate[(int)@event.KeyCode] = 1;
      }
      else if (@event.Type == EventType.KeyUp)
        ex.keystate[(int)@event.KeyCode] = 0;
      else if (@event.Type == EventType.Timer)
      {
        int i = 0;
        handle_input();
        redraw = 1;

        for (i = 0; i < (int)KeyCode.KeyMax; ++i)
        {
          if (ex.keystate[i] == 0)
            ex.key[i] = 0;
        }
        ex.mouse_dx = 0;
        ex.mouse_dy = 0;
      }
      else if (@event.Type == EventType.MouseButtonDown)
        ex.button[@event.MouseButton] = 1;
      else if (@event.Type == EventType.MouseButtonUp)
        ex.button[@event.MouseButton] = 0;
      else if (@event.Type == EventType.MouseAxes)
      {
        ex.mouse_dx += @event.MouseX;
        ex.mouse_dy += @event.MouseY;
      }

      if (redraw != 0 && Al.IsEventQueueEmpty(queue))
      {
        draw_scene();
        Al.FlipDisplay();
        redraw = 0;
      }
    }
  }
}
