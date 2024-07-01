
using Raylib_cs;

public static class Game {

    public static bool ShouldClose = false;

    static void Main() {
        Raylib.InitWindow(Global.WindowWidth, Global.WindowHeight, "Pongo");

        Raylib.SetTargetFPS(Global.TargetFPS);

        while(!ShouldClose) {

            
            if(Raylib.WindowShouldClose()) ShouldClose = true;
        }

        Raylib.CloseWindow();
    }
}