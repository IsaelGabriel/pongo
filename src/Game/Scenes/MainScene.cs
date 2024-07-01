using System.Numerics;
using Raylib_cs;

public class MainScene : IEntity {

    private const int ScoreTextSize = 50;

    private readonly Bracket[] brackets = [
        new(new(16, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
        new(new(Global.WindowWidth - 16 - Bracket.BracketWidth, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
    ];
    private readonly Ball ball = new(new Vector2(
            Global.WindowWidth - Ball.BallWidth, 
            Global.WindowHeight - Ball.BallHeight
        ) / 2);

    private int[] scores = [0, 0];

    public void Update() {
        HandlePlayerInput();
        CheckBallCollision();
        ball.Update();
    }

    private void HandlePlayerInput() {
        float diffY = (float) (Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up));
        Vector2 newPosition = brackets[0].position;
        newPosition.Y += diffY * Bracket.BracketSpeed * Raylib.GetFrameTime();
        brackets[0].position = newPosition;
    }

    private void CheckBallCollision() {
        if(ball.position.X <= 0f) {
            scores[1]++;
            ResetBallPosition();
        }else if(ball.position.X >= Global.WindowWidth - Ball.BallWidth) {
            scores[0]++;
            ResetBallPosition();
        }

        for(int i = 0; i < 2; i++) {
            if(Raylib.CheckCollisionRecs(brackets[i].rect, ball.rect)) {
                ball.movement.X = -(i * 2 - 1);
            }
        }
    }

    private void ResetBallPosition() {
        ball.position = new Vector2(
            Global.WindowWidth - Ball.BallWidth, 
            Global.WindowHeight - Ball.BallHeight
        ) / 2;
    }

    public void Render() {
        float textY = (Global.WindowHeight - ScoreTextSize) / 2;
        for(int i = 0; i < 2; i++) {
            float textX = (Global.WindowWidth * (i + 1) / 3) - ScoreTextSize;
            Raylib.DrawText($"{scores[i]}", (int) textX, (int) textY, ScoreTextSize, Color.Gray);
        }
        foreach(Bracket bracket in brackets) {
            bracket.Render();
        }
        ball.Render();
    }
}