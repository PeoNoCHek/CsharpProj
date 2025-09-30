public class Player
{
    private readonly int _BoardSize;
    public readonly String name;
    public State state = State.NotInGame;
    public int? position { get; private set; } = null;
    public int stepsCount { get; private set; } = 0;
    public Player(int BoardSize = 0, String name = "default name")
    {
        this._BoardSize = BoardSize;
        this.name = name;
    }

    public void Move(int steps)
    {
        if (state == State.NotInGame)
        {
            state = State.Play;
            position = steps;
            MoveToCorrectPossition();
            return;
        }
        this.position += steps;
        MoveToCorrectPossition();
        stepsCount += Math.Abs(steps);
    }

    // public void SetPosition(int position) => this.position = position;
    public void MoveToCorrectPossition()
    {
        while (this.position > _BoardSize) this.position -= _BoardSize;
        while (this.position < 1) this.position += _BoardSize;
    }

}