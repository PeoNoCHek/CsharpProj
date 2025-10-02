using System.Text;

public class Sentence
{
    public static int CompareSentencesByWordCount(Sentence sentence0, Sentence sentence1) //определение 
    {
        if (sentence0._wordsCount == sentence1._wordsCount) return 0;
        if (sentence0._wordsCount > sentence1._wordsCount) return 1;
        return -1;
    }

    public static int CompareSentencesByTokensCount(Sentence sentence0, Sentence sentence1)
    {
        if (sentence0._tokens.Count == sentence1._tokens.Count) return 0;
        if (sentence0._tokens.Count > sentence1._tokens.Count) return 1;
        return -1;
    }

    public SentenceType sentenceType{ private set; get; } = SentenceType.Unknown;
    private int _wordsCount = 0;

    private List<IToken> _tokens = new List<IToken>(); //временно паблик !!!!!!!!!!!!!!!


    StringBuilder wordAndPunctuationPos = new StringBuilder();

    public HashSet<IToken> NonRecurringWordsWithThisLength (int Length)//Получение всех неповторяющихся слов определенной длины в предложении
    {
        HashSet<IToken> result = new HashSet<IToken>();
        for (int i = 0; i < _tokens.Count; i++)
        {
            if (_tokens[i].Type == TokenType.Word && _tokens[i].Length == Length)
            {
                result.Add(_tokens[i]);
            }
        }

        return result;
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
        sentenceType = type;
    }

    
    public override string ToString() // Потом переписать
    {

        StringBuilder stringBuilder = new StringBuilder(_tokens.Count * 3);
        for (int i = 0; i < _tokens.Count; i++)
        {
            stringBuilder.Append(_tokens[i]);

            if (i + 1 < _tokens.Count)
            {
                if (_tokens[i] is Word && _tokens[i + 1] is Word)
                {
                    stringBuilder.Append(' ');
                }
                else if (_tokens[i] is Punctuation && _tokens[i + 1] is Word)
                {
                    stringBuilder.Append(' ');
                }
            }
        }
        return stringBuilder.ToString();
    }
}