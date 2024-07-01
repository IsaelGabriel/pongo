using System.Numerics;
using Raylib_cs;

public class Bracket(Vector2 position) : IEntity {

    public const int BracketWidth = 8;
    public const int BracketHeight = Global.WindowHeight / 5;
    public Rectangle rect = new(position, new(BracketWidth, BracketHeight));
    public Vector2 position {
        get=>rect.Position;
        set=>rect.Position = value;
    }
    

    public void Render() {
        Raylib.DrawRectangleRec(rect, Color.RayWhite);
    }
}