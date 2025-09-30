public class Board
{
    public int? distance { private set; get; } = null;
    public GameState gameState { set; get; }
    public Player cat { private set; get; }
    public Player mouse { private set; get; }
    public readonly int BoardSize;

    public Board(int BoardSize = 0)
    {
        this.BoardSize = BoardSize;
        cat = new Player(this.BoardSize, "cat");
        mouse = new Player(this.BoardSize, "mouse");
        gameState = GameState.Start;
    }
    public void RedefineDistance() => this.distance = cat.state == State.NotInGame || mouse.state == State.NotInGame ? null : Math.Abs(((cat.position - mouse.position)??0));
    public bool CompareCatAndMousePosition() => cat.position == mouse.position && cat.position != null;
}

