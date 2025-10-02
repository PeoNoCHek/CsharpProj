public class Word : IToken
{
    private string _word;

    public TokenType Type { get; } = TokenType.Word;
    public int Length
    {
        get{ return _word.Length;}
    }

    public Word(string word)
    {
        this._word = word;
    }



    public override string ToString()
    {
        return _word;
    }

}


