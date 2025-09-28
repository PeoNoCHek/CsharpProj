public class Punctuation : IToken
{
    public TokenType Type { get; } = TokenType.Punctuation;
    private char _symbol;

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

    public String GetSTR()
    {
        return _symbol.ToString();
    }



}