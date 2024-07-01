using Raylib_cs;

public class MainScene : IEntity {
    public void Render() {
        Raylib.DrawFPS(0, 0);
    }
}