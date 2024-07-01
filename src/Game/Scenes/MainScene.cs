using Raylib_cs;

public class MainScene : IEntity {

    private Bracket player = new Bracket(new(0, 200));
    private Bracket[] brackets = [
        new(new(16, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
        new(new(Global.WindowWidth - 16 - Bracket.BracketWidth, (Global.WindowHeight - Bracket.BracketHeight) / 2)),
    ];

    public void Render() {
        foreach(Bracket bracket in brackets) {
            bracket.Render();
        }
        Raylib.DrawFPS(0, 0);
    }
}