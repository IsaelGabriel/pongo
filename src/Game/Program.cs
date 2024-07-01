
using Raylib_cs;

public static class Game {

    public static bool ShouldClose = false;

    public static IEntity currentScene = new MainScene();

    static void Main() {
        Raylib.InitWindow(Global.WindowWidth, Global.WindowHeight, "Pongo");

        Raylib.SetTargetFPS(Global.TargetFPS);

        currentScene.Start();

        while(!ShouldClose) {
            currentScene.Update();
            Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Black);
                currentScene.Render();
            Raylib.EndDrawing();

            if(Raylib.WindowShouldClose()) ShouldClose = true;
        }

        Raylib.CloseWindow();
    }
}