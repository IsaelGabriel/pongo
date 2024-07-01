using System.Numerics;
using Raylib_cs;

public class Ball(Vector2 position) : IEntity {
    
    public const int BallWidth = 8;
    public const int BallHeight = 8;
    public const float DefaultBallSpeed = 200f;
    public Rectangle rect = new(position, new(BallWidth, BallHeight));
    public Vector2 position { 
        get => rect.Position;
        set=>rect.Position = value;
    }
    public Vector2 movement = new(-1, 1);

    public void Update() {
        Vector2 newPosition = rect.Position;

        newPosition += movement * DefaultBallSpeed * Raylib.GetFrameTime();

        if(newPosition.Y <= 0f) {
            newPosition.Y = 0f;
            movement.Y = 1;
        }else if(newPosition.Y >= Global.WindowHeight - BallHeight) {
            newPosition.Y = Global.WindowHeight - BallHeight;
            movement.Y = -1;
        }

        rect.Position = newPosition;
    }

    public void Render() {
        Raylib.DrawRectangleRec(rect, Color.RayWhite);
    }
}