public class Punctuation : IToken
{
    public TokenType Type { get; } = TokenType.Punctuation;
    private char _symbol;

    public int Length
    {
        get{ return 1; }
    }

    public Punctuation(char symbol)
    {
        this._symbol = symbol;
    }




    public char symbol
    {
        get
        {
            return this._symbol;
        }
    }

    public override String ToString()
    {
        return _symbol.ToString();
    }



}