public class Word : IToken
{
    private string _word;

    public TokenType Type { get; } = TokenType.Word;

    public Word(string word)
    {
        this._word = word ;
    }

    public string word
    {
        get
        {
            return this._word;
        }
        // set
        // {
        //     this._word = value;
        // }
    }

    public string GetSTR()
    {
        return _word;
    }
}


