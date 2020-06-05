using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace CrazyDraw
{
    class Program
    {
        public static int Main()
        {
            // Initialization
            //--------------------------------------------------------------------------------------
            const int screenWidth = 800;
            const int screenHeight = 600;

            InitWindow(screenWidth, screenHeight, "CrazyDraw");

            SetTargetFPS(60);
            //--------------------------------------------------------------------------------------

            Canvas.CanvasManager canvasManager = new Canvas.CanvasManager();
            ButtonCollection buttons = new ButtonCollection(canvasManager);

            //ResizeVisitor rv;
            //rv.cm = canvasManager;
            //MoveVisitor mv;
            //mv.cm = canvasManager;

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update

                canvasManager.canvas.Update();
                //canvasManager.canvas.Visit(rv);
                //canvasManager.canvas.Visit(mv);
                buttons.Update();

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                canvasManager.canvas.Draw();
                buttons.Draw();

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            CloseWindow();
            return 0;


        }
    }
}
