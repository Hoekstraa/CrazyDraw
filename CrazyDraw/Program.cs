using static Raylib_cs.Raylib;
using static Raylib_cs.Color;
using CrazyDraw.Figures;

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

            var rv = new Figures.IFigure.ResizeVisitor(canvasManager);
            var mv = new Figures.IFigure.MoveVisitor(canvasManager);

            BasicFigure.EllipseStrategy rectangleStrat = BasicFigure.EllipseStrategy.Instance;

            // Temporary Decorated Figure testing
            DecoratedFigure df = new DecoratedFigure(new BasicFigure(300, 300, 50, 50, BasicFigure.RectangleStrategy.Instance));
            canvasManager.canvas.AddFigure(df);
            df.North("iets");
            df.South("Pog");
            df.West("west");
            df.East("East");
            /////////////////////////////////////

            // Main game loop
            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                // Update
                //----------------------------------------------------------------------------------
                canvasManager.canvas.Update();
                canvasManager.canvas.Visit(rv);
                canvasManager.canvas.Visit(mv);
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
