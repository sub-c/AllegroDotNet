using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;

namespace Ex.Projection2;

internal static class Program
{
    public static void draw_pyramid(AllegroBitmap? texture, float x, float y, float z, float theta)
    {
        AllegroColor c = Al.MapRgbF(1, 1, 1);
        AllegroTransform t = new AllegroTransform();
        AllegroVertex[] vtx = new AllegroVertex[5]
        {
      new AllegroVertex
      {
        X = 0,
        Y = 1,
        Z = 0,
        U = 0,
        V = 64,
        Color = c
      },
      new AllegroVertex
      {
        X = -1,
        Y = -1,
        Z = -1,
        U = 0,
        V = 0,
        Color = c
      },
      new AllegroVertex
      {
        X = 1,
        Y = -1,
        Z = -1,
        U = 64,
        V = 64,
        Color = c
      },
      new AllegroVertex
      {
        X = 1,
        Y = -1,
        Z = 1,
        U = 64,
        V = 0,
        Color = c
      },
      new AllegroVertex
      {
        X = -1,
        Y = -1,
        Z = 1,
        U = 64,
        V = 64,
        Color = c
      }
        };
        int[] indices = new int[12]
        {
      0, 1, 2,
      0, 2, 3,
      0, 3, 4,
      0, 4, 1
        };

        Al.IdentityTransform(ref t);
        Al.RotateTransform3D(ref t, 0, 1, 0, theta);
        Al.TranslateTransform3D(ref t, x, y, z);
        Al.UseTransform(ref t);
        Al.DrawIndexedPrim(vtx, texture, indices, 12, PrimType.TriangleList);
    }

    public static void set_perspective_transform(AllegroBitmap? bmp)
    {
        AllegroTransform p = new AllegroTransform();
        float aspect_ratio = (float)Al.GetBitmapHeight(bmp) / Al.GetBitmapWidth(bmp);
        Al.SetTargetBitmap(bmp);
        Al.IdentityTransform(ref p);
        Al.PerspectiveTransform(ref p, -1, aspect_ratio, 1, 1, -aspect_ratio, 1000);
        Al.UseProjectionTransform(ref p);
    }

    public static void Main(string[] args)
    {
        AllegroDisplay? display;
        AllegroTimer? timer;
        AllegroEventQueue? queue;
        AllegroBitmap? texture;
        AllegroBitmap? display_sub_persp;
        AllegroBitmap? display_sub_ortho;
        AllegroBitmap? buffer;
        AllegroFont? font;
        bool redraw = false;
        bool quit = false;
        bool fullscreen = false;
        bool background = false;
        DisplayFlags display_flags = DisplayFlags.Resizable;
        float theta = 0;

        if (args.Length > 1)
        {
            if (args[1] == "--use-shaders")
                display_flags |= DisplayFlags.ProgrammablePipeline;
            else
                throw new Exception("!");
        }

        if (!Al.InstallSystem(LibraryVersion.V528))
            throw new Exception("Could not init Allegro.\n");
        Al.InitImageAddon();
        Al.InitPrimitivesAddon();
        Al.InitFontAddon();
        Al.InstallKeyboard();

        Al.SetNewDisplayFlags(display_flags);
        Al.SetNewDisplayOption(DisplayOption.DepthSize, 16, DisplayImportance.Suggest);
        /* Load everything as a POT bitmap to make sure the projection stuff works
        * with mismatched backing texture and bitmap sizes. */
        Al.SetNewDisplayOption(DisplayOption.SupportNpotBitmap, 0, DisplayImportance.Require);
        display = Al.CreateDisplay(800, 600);
        if (display == null)
            throw new Exception("Error creating display\n");
        Al.SetWindowConstraints(display, 256, 512, 0, 0);
        Al.ApplyWindowConstraints(display, true);
        set_perspective_transform(Al.GetBackbuffer(display));

        /* This bitmap is a sub-bitmap of the display, and has a perspective transformation. */
        display_sub_persp = Al.CreateSubBitmap(Al.GetBackbuffer(display), 0, 0, 256, 256);
        set_perspective_transform(display_sub_persp);

        /* This bitmap is a sub-bitmap of the display, and has a orthographic transformation. */
        display_sub_ortho = Al.CreateSubBitmap(Al.GetBackbuffer(display), 0, 0, 256, 512);

        /* This bitmap has a perspective transformation, purposefully non-POT */
        buffer = Al.CreateBitmap(200, 200);
        set_perspective_transform(buffer);

        timer = Al.CreateTimer(1.0 / 60);
        font = Al.CreateBuiltinFont();

        queue = Al.CreateEventQueue();
        Al.RegisterEventSource(queue, Al.GetKeyboardEventSource());
        Al.RegisterEventSource(queue, Al.GetDisplayEventSource(display));
        Al.RegisterEventSource(queue, Al.GetTimerEventSource(timer));

        Al.SetNewBitmapFlags(BitmapFlags.MinLinear | BitmapFlags.MagLinear | BitmapFlags.Mipmap);

        texture = Al.LoadBitmap("data/bkg.png");
        if (texture == null)
            throw new Exception("Could not load data/bkg.png");

        Al.StartTimer(timer);
        while (!quit)
        {
            AllegroEvent @event = new AllegroEvent();

            Al.WaitForEvent(queue, ref @event);
            switch (@event.Type)
            {
                case EventType.DisplayClose:
                    quit = true;
                    break;

                case EventType.DisplayResize:
                    Al.AcknowledgeResize(display);
                    set_perspective_transform(Al.GetBackbuffer(display));
                    break;

                case EventType.KeyDown:
                    switch (@event.Keyboard.KeyCode)
                    {
                        case KeyCode.KeyEscape:
                            quit = true;
                            break;

                        case KeyCode.KeySpace:
                            fullscreen = !fullscreen;
                            Al.SetDisplayFlag(display, DisplayFlags.FullscreenWindow, fullscreen);
                            set_perspective_transform(Al.GetBackbuffer(display));
                            break;
                    }
                    break;

                case EventType.Timer:
                    redraw = true;
                    theta = (float)((theta + 0.05) % (2 * Al.ALLEGRO_PI));
                    break;

                case EventType.DisplayHaltDrawing:
                    background = true;
                    Al.AcknowledgeDrawingHalt(display);
                    Al.StopTimer(timer);
                    break;

                case EventType.DisplayResumeDrawing:
                    background = false;
                    Al.AcknowledgeDrawingResume(display);
                    Al.StartTimer(timer);
                    break;
            }

            if (!background && redraw && Al.IsEventQueueEmpty(queue))
            {
                Al.SetTargetBackbuffer(display);
                Al.SetRenderState(AllegroRenderState.DepthTest, 1);
                Al.ClearToColor(Al.MapRgbF(0, 0, 0));
                Al.ClearDepthBuffer(1000);
                draw_pyramid(texture, 0, 0, -4, theta);

                Al.SetTargetBitmap(buffer);
                Al.SetRenderState(AllegroRenderState.DepthTest, 1);
                Al.ClearToColor(Al.MapRgbF(0, 0.1f, 0.1f));
                Al.ClearDepthBuffer(1000);
                draw_pyramid(texture, 0, 0, -4, theta);

                Al.SetTargetBitmap(display_sub_persp);
                Al.SetRenderState(AllegroRenderState.DepthTest, 1);
                Al.ClearToColor(Al.MapRgbF(0, 0, 0.25f));
                Al.ClearDepthBuffer(1000);
                draw_pyramid(texture, 0, 0, -4, theta);

                Al.SetTargetBitmap(display_sub_ortho);
                Al.SetRenderState(AllegroRenderState.DepthTest, 0);
                Al.DrawText(font, Al.MapRgbF(1, 1, 1), 128, 16, FontAlignFlags.Center, "Press Space to toggle fullscreen");
                Al.DrawBitmap(buffer, 0, 256, 0);

                Al.FlipDisplay();
                redraw = false;
            }
        }
    }
}
