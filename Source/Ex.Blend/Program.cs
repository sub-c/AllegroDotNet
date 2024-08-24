/* An example demonstrating different blending modes.
 */

using SubC.AllegroDotNet;
using SubC.AllegroDotNet.Enums;
using SubC.AllegroDotNet.Models;
using System.Runtime.InteropServices;

namespace Ex.Blend;

internal static class ExBlend
{

    /* A structure holding all variables of our example program. */
    struct Example
    {
        public AllegroBitmap? example; /* Our example bitmap. */
        public AllegroBitmap? offscreen; /* An offscreen buffer, for testing. */
        public AllegroBitmap? memory; /* A memory buffer, for testing. */
        public AllegroFont? myfont; /* Our font. */
        public AllegroEventQueue? queue; /* Our events queue. */
        public int image; /* Which test image to use. */
        public int mode; /* How to draw it. */
        public int BUTTONS_X; /* Where to draw buttons. */

        public int FPS;
        public double last_second;
        public int frames_accum;
        public double fps;
    }

    static Example ex = new();

    /* Print some text with a shadow. */
    static void print(int x, int y, bool vertical, string message)
    {
        AllegroColor color;
        int h = default;
        int j;

        Al.SetBlender(BlendOperation.Add, BlendMode.One, BlendMode.InverseAlpha);
        Al.GetFontLineHeight(ex.myfont);

        for (j = 0; j < 2; j++)
        {
            if (j == 0)
                color = Al.MapRgb(0, 0, 0);
            else
                color = Al.MapRgb(255, 255, 255);

            if (vertical)
            {
                int i;
                AllegroUstrInfo ui = new();
                var cStringMessage = Marshal.StringToHGlobalAnsi(message);
                AllegroUstr? us = Al.RefCstr(ref ui, cStringMessage);
                for (i = 0; i < (int)Al.UstrLength(us); i++)
                {
                    AllegroUstrInfo letter = new();
                    Al.DrawUstr(ex.myfont, color, x + 1 - j, y + 1 - j + h * i, FontAlignFlags.Left,
                      Al.RefUstr(ref letter, us, Al.UstrOffset(us, i),
                      Al.UstrOffset(us, i + 1)));
                }
            }
            else
            {
                Al.DrawText(ex.myfont, color, x + 1 - j, y + 1 - j, 0, message);
            }
        }
    }

    /* Create an example bitmap. */
    static unsafe AllegroBitmap? create_example_bitmap()
    {
        AllegroBitmap? bitmap;
        int i, j;
        AllegroLockedRegion? locked;
        byte* data;

        bitmap = Al.CreateBitmap(100, 100);
        locked = Al.LockBitmap(bitmap, PixelFormat.Abgr8888, LockFlag.WriteOnly);
        data = (byte*)locked!.Value.Data;

        for (j = 0; j < 100; j++)
        {
            for (i = 0; i < 100; i++)
            {
                int x = i - 50, y = j - 50;
                int r = (int)Math.Sqrt(x * x + y * y);
                float rc = (float)(1 - r / 50.0);
                if (rc < 0)
                    rc = 0;

                data[i * 4 + 0] = (byte)(i * 255 / 100);
                data[i * 4 + 1] = (byte)(j * 255 / 100);
                data[i * 4 + 2] = (byte)(rc * 255);
                data[i * 4 + 3] = (byte)(rc * 255);
            }

            data += locked!.Value.Pitch;
        }
        Al.UnlockBitmap(bitmap);

        return bitmap;
    }

    /* Draw our example scene. */
    static void draw()
    {
        AllegroColor[] test = new AllegroColor[5];
        AllegroBitmap? target = Al.GetTargetBitmap();

        string[] blend_names = new[] { "ZERO", "ONE", "ALPHA", "INVERSE" };
        string[] blend_vnames = new[] { "ZERO", "ONE", "ALPHA", "INVER" };
        BlendMode[] blend_modes = new[] { BlendMode.Zero, BlendMode.One, BlendMode.Alpha, BlendMode.InverseAlpha };
        float x = 40, y = 40;
        int i, j;

        Al.ClearToColor(Al.MapRgbF(0.5f, 0.5f, 0.5f));

        test[0] = Al.MapRgbaF(1, 1, 1, 1);
        test[1] = Al.MapRgbaF(1, 1, 1, 0.5f);
        test[2] = Al.MapRgbaF(1, 1, 1, 0.25f);
        test[3] = Al.MapRgbaF(1, 0, 0, 0.75f);
        test[4] = Al.MapRgbaF(0, 0, 0, 0);

        print((int)x, 0, false, $"D  E  S  T  I  N  A  T  I  O  N  ({ex.fps:0.00} fps)");
        print(0, (int)y, true, "S O U R C E");
        for (i = 0; i < 4; i++)
        {
            print((int)x + i * 110, 20, false, blend_names[i]);
            print(20, (int)y + i * 110, true, blend_vnames[i]);
        }

        Al.SetBlender(BlendOperation.Add, BlendMode.One, BlendMode.Zero);
        if (ex.mode >= 1 && ex.mode <= 5)
        {
            Al.SetTargetBitmap(ex.offscreen);
            Al.ClearToColor(test[ex.mode - 1]);
        }
        if (ex.mode >= 6 && ex.mode <= 10)
        {
            Al.SetTargetBitmap(ex.memory);
            Al.ClearToColor(test[ex.mode - 6]);
        }

        for (j = 0; j < 4; j++)
        {
            for (i = 0; i < 4; i++)
            {
                Al.SetBlender(BlendOperation.Add, blend_modes[j], blend_modes[i]);
                if (ex.image == 0)
                    Al.DrawBitmap(ex.example, x + i * 110, y + j * 110, FlipFlags.None);
                else if (ex.image >= 1 && ex.image <= 6)
                {
                    Al.DrawFilledRectangle(x + i * 110, y + j * 110,
                       x + i * 110 + 100, y + j * 110 + 100,
                          test[ex.image - 1]);
                }
            }
        }

        if (ex.mode >= 1 && ex.mode <= 5)
        {
            Al.SetBlender(BlendOperation.Add, BlendMode.One, BlendMode.InverseAlpha);
            Al.SetTargetBitmap(target);
            Al.DrawBitmapRegion(ex.offscreen, x, y, 430, 430, x, y, 0);
        }
        if (ex.mode >= 6 && ex.mode <= 10)
        {
            Al.SetBlender(BlendOperation.Add, BlendMode.One, BlendMode.InverseAlpha);
            Al.SetTargetBitmap(target);
            Al.DrawBitmapRegion(ex.memory, x, y, 430, 430, x, y, 0);
        }

        static string Is1(int i)
        {
            return ex.image == i ? "*" : " ";
        }

        print(ex.BUTTONS_X, 20 * 1, false, "What to draw");
        print(ex.BUTTONS_X, 20 * 2, false, $"{Is1(0)} Picture");
        print(ex.BUTTONS_X, 20 * 3, false, $"{Is1(1)} Rec1 (1/1/1/1)");
        print(ex.BUTTONS_X, 20 * 4, false, $"{Is1(2)} Rec2 (1/1/1/.5)");
        print(ex.BUTTONS_X, 20 * 5, false, $"{Is1(3)} Rec3 (1/1/1/.25)");
        print(ex.BUTTONS_X, 20 * 6, false, $"{Is1(4)} Rec4 (1/0/0/.75)");
        print(ex.BUTTONS_X, 20 * 7, false, $"{Is1(5)} Rec5 (0/0/0/0)");

        static string Is2(int i)
        {
            return ex.mode == i ? "*" : " ";
        }

        print(ex.BUTTONS_X, 20 * 9, false, "Where to draw");
        print(ex.BUTTONS_X, 20 * 10, false, $"{Is2(0)} screen");

        print(ex.BUTTONS_X, 20 * 11, false, $"{Is2(1)} offscreen1");
        print(ex.BUTTONS_X, 20 * 12, false, $"{Is2(2)} offscreen2");
        print(ex.BUTTONS_X, 20 * 13, false, $"{Is2(3)} offscreen3");
        print(ex.BUTTONS_X, 20 * 14, false, $"{Is2(4)} offscreen4");
        print(ex.BUTTONS_X, 20 * 15, false, $"{Is2(5)} offscreen5");

        print(ex.BUTTONS_X, 20 * 16, false, $"{Is2(6)} memory1");
        print(ex.BUTTONS_X, 20 * 17, false, $"{Is2(7)} memory2");
        print(ex.BUTTONS_X, 20 * 18, false, $"{Is2(8)} memory3");
        print(ex.BUTTONS_X, 20 * 19, false, $"{Is2(9)} memory4");
        print(ex.BUTTONS_X, 20 * 20, false, $"{Is2(10)} memory5");
    }

    /* Called a fixed amount of times per second. */
    static void tick()
    {
        /* Count frames during the last second or so. */
        double t = Al.GetTime();
        if (t >= ex.last_second + 1)
        {
            ex.fps = ex.frames_accum / (t - ex.last_second);
            ex.frames_accum = 0;
            ex.last_second = t;
        }

        draw();
        Al.FlipDisplay();
        ex.frames_accum++;
    }

    /* Run our test. */
    static void run()
    {
        //ALLEGRO_EVENT event;
        AllegroEvent @event = new();
        float x, y;
        bool need_draw = true;

        while (true)
        {
            /* Perform frame skipping so we don't fall behind the timer events. */
            if (need_draw && Al.IsEventQueueEmpty(ex.queue))
            {
                tick();
                need_draw = false;
            }

            Al.WaitForEvent(ex.queue, ref @event);

            switch (@event.Type)
            {
                /* Was the X button on the window pressed? */
                case EventType.DisplayClose:
                    return;

                /* Was a key pressed? */
                case EventType.KeyDown:
                    if (@event.Keyboard.KeyCode == KeyCode.KeyEscape)
                        return;
                    break;

                /* Is it time for the next timer tick? */
                case EventType.Timer:
                    need_draw = true;
                    break;

                /* Mouse click? */
                case EventType.MouseButtonUp:
                    x = @event.Mouse.X;
                    y = @event.Mouse.Y;
                    if (x >= ex.BUTTONS_X)
                    {
                        int button = (int)y / 20;
                        if (button == 2) ex.image = 0;
                        if (button == 3) ex.image = 1;
                        if (button == 4) ex.image = 2;
                        if (button == 5) ex.image = 3;
                        if (button == 6) ex.image = 4;
                        if (button == 7) ex.image = 5;

                        if (button == 10) ex.mode = 0;

                        if (button == 11) ex.mode = 1;
                        if (button == 12) ex.mode = 2;
                        if (button == 13) ex.mode = 3;
                        if (button == 14) ex.mode = 4;
                        if (button == 15) ex.mode = 5;

                        if (button == 16) ex.mode = 6;
                        if (button == 17) ex.mode = 7;
                        if (button == 18) ex.mode = 8;
                        if (button == 19) ex.mode = 9;
                        if (button == 20) ex.mode = 10;
                    }
                    break;
            }
        }
    }

    /* Initialize the example. */
    static void init()
    {
        ex.BUTTONS_X = 40 + 110 * 4;
        ex.FPS = 60;

        ex.myfont = Al.LoadFont("data/font.tga", 0, 0);
        if (ex.myfont is null)
        {
            throw new Exception("data/font.tga not found\n");
        }
        ex.example = create_example_bitmap();

        ex.offscreen = Al.CreateBitmap(640, 480);
        Al.SetNewBitmapFlags(BitmapFlags.MemoryBitmap);
        ex.memory = Al.CreateBitmap(640, 480);
    }

    static int Main(string[] args)
    {
        AllegroDisplay? display;
        AllegroTimer? timer;

        //(void)argc;
        //(void)argv;

        if (!Al.InstallSystem(LibraryVersion.V528))
        {
            throw new Exception("Could not init Allegro.\n");
        }

        Al.InitPrimitivesAddon();
        Al.InstallKeyboard();
        Al.InstallMouse();
        Al.InstallTouchInput();
        Al.InitImageAddon();
        Al.InitFontAddon();

        display = Al.CreateDisplay(640, 480);
        if (display is null)
        {
            throw new Exception("Error creating display\n");
        }

        init();

        timer = Al.CreateTimer(1.0 / ex.FPS);

        ex.queue = Al.CreateEventQueue();
        Al.RegisterEventSource(ex.queue, Al.GetKeyboardEventSource());
        Al.RegisterEventSource(ex.queue, Al.GetMouseEventSource());
        Al.RegisterEventSource(ex.queue, Al.GetDisplayEventSource(display));
        Al.RegisterEventSource(ex.queue, Al.GetTimerEventSource(timer));
        if (Al.IsTouchInputInstalled())
        {
            //al_register_event_source(ex.queue,
            //   al_get_touch_input_mouse_emulation_event_source());
        }

        Al.StartTimer(timer);
        run();

        Al.DestroyEventQueue(ex.queue);

        return 0;
    }

}
