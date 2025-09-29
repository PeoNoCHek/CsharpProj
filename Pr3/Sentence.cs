using System.Text;

public class Sentence
{
    private SentenceType sentenceType;

    private List<IToken> _tokens = new List<IToken>(); //временно паблик !!!!!!!!!!!!!!!
    public int tokensCount
    {
        get
        {
            return _tokens.Count;
        }
    }

    StringBuilder wordAndPunctuationPos = new StringBuilder();

    public Sentence()
    {

    }

    public Sentence(Sentence sentence)
    {
        //для троеточия и тд пока что будет пустым

    }



    public void AddWord(Word word)
    {
        _tokens.Add(word);
        wordAndPunctuationPos.Append('w');
    }

    public void AddPunctuation(Punctuation punctuation)
    {
        _tokens.Add(punctuation);
        wordAndPunctuationPos.Append('p');
    }

    public void SetType(SentenceType type)
    {
        sentenceType = type;
    }
    public void Close()
    {


    }

    public void printall() // Потом переписать
{
    for (int i = 0; i < _tokens.Count; i++)
    {
        Console.Write(_tokens[i].GetSTR());

        if (i + 1 < _tokens.Count)
        {
            if (_tokens[i] is Word && _tokens[i + 1] is Word)
            {
                Console.Write(" ");
            }
            else if (_tokens[i] is Punctuation && _tokens[i + 1] is Word)
            {
                Console.Write(" ");
            }
        }
    }
}
}