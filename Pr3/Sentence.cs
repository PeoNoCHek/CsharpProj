using System.Text;

public class Sentence
{
    public static int CompareSentencesByWordCount(Sentence sentence0, Sentence sentence1)
    {
        
        return 0;
    }
    private SentenceType _sentenceType;
    private int _wordsCount = 0;

    private List<IToken> _tokens = new List<IToken>(); //временно паблик !!!!!!!!!!!!!!!
    public int tokensCount //   число токенов/длина предложения 
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
        _wordsCount++;
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
        _sentenceType = type;
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