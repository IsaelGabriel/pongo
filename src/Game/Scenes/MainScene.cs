using System.Numerics;
using Raylib_cs;

public class MainScene : IEntity {

    private Bracket[] brackets = [
        new(new(16, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
        new(new(Global.WindowWidth - 16 - Bracket.BracketWidth, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
    ];
    private Ball ball = new(new Vector2(
            Global.WindowWidth - Ball.BallWidth, 
            Global.WindowHeight - Ball.BallHeight
        ) / 2);

    public void Update() {
        HandlePlayerInput();
    }

    private void HandlePlayerInput() {
        float diffY = (float) (Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up));
        Vector2 newPosition = brackets[0].position;
        newPosition.Y += diffY * Bracket.BracketSpeed * Raylib.GetFrameTime();
        brackets[0].position = newPosition;
    }

    public void Render() {
        foreach(Bracket bracket in brackets) {
            bracket.Render();
        }
        ball.Render();
        Raylib.DrawFPS(0, 0);
    }
}