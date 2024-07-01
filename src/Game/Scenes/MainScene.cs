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
    private readonly Random rng = new();

    public void Update() {
        HandlePlayerInput();
        HandleEnemyAI();
        CheckBallCollision();
        ball.Update();
    }

    private void HandlePlayerInput() {
        float diffY = (float) (Raylib.IsKeyDown(KeyboardKey.Down) - Raylib.IsKeyDown(KeyboardKey.Up));
        Vector2 newPosition = brackets[0].position;
        newPosition.Y += diffY * Bracket.BracketSpeed * Raylib.GetFrameTime();
        brackets[0].position = newPosition;
    }

    private void HandleEnemyAI() {
        float centerY = brackets[1].position.Y + Bracket.BracketHeight / 2;
        int direction = 1;
        if(ball.position.Y < centerY) {
            direction = -1;
        }
        Vector2 newPosition = brackets[1].position;
        newPosition.Y += direction * Bracket.BracketSpeed * Raylib.GetFrameTime() * 0.75f;
        brackets[1].position = newPosition;
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
        ball.movement = new(
            rng.NextInt64() % 2 * 2 - 1,
            rng.NextInt64() % 2 * 2 - 1
        );
    }

    public void Render() {
        Raylib.DrawLineEx(
            new( Global.WindowWidth / 2 - 1, 0),
            new(Global.WindowWidth / 2 - 1, Global.WindowHeight),
            2,
            Color.Gray
        );

        float textY = (Global.WindowHeight - ScoreTextSize) / 2;
        for(int i = 0; i < 2; i++) {
            float textX = ((Global.WindowWidth - ScoreTextSize) * (i + 1) / 3);
            Raylib.DrawText($"{scores[i]}", (int) textX, (int) textY, ScoreTextSize, Color.Gray);
        }
        foreach(Bracket bracket in brackets) {
            bracket.Render();
        }
        ball.Render();
    }
}