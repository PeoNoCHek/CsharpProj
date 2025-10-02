public interface IToken
{
    public TokenType Type { get; }
    public String ToString();
    public int Length
    {
        get;
    }
}