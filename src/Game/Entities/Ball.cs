using System.Numerics;
using Raylib_cs;

public class Ball(Vector2 position) : IEntity {
    
    public const int BallWidth = 8;
    public const int BallHeight = 8;
    public Rectangle rect = new(position, new(BallWidth, BallHeight));
    
    public void Render() {
        Raylib.DrawRectangleRec(rect, Color.RayWhite);
    }
}