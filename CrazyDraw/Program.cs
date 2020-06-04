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

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update

                // Draw
                //----------------------------------------------------------------------------------
                BeginDrawing();

                ClearBackground(RAYWHITE);

                DrawText("Congrats! You created your first window!", 190, 200, 20, MAROON);

                EndDrawing();
                //----------------------------------------------------------------------------------
            }

            CloseWindow();
            return 0;


        }
    }
}
