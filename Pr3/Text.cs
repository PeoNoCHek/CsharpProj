public class Text
{
    private List<Sentence> _text;//временно публичноке
    public Text(List<Sentence> sentences)
    {
        this._text = sentences;
    }

    public Text()
    {
        this._text = new List<Sentence>();
    }

    public void SortByWordsCount()
    {
        _text.Sort(Sentence.CompareSentencesByWordCount);
    }

    public void SortByTokensCount()
    {
        _text.Sort(Sentence.CompareSentencesByTokensCount);
    }


    public void AddSentence(Sentence sentence)
    {
        _text.Add(sentence);
    }
    public List<Sentence> GetSentencesList() => _text;

    public void PrintAllSentences()
    {
        for (int i = 0; i < _text.Count; i++)
        {
            System.Console.WriteLine(_text[i]);
        }
    }


    public HashSet<IToken> FindAllWordsWithOneLengthInQuestionSentences(int wordLength) //на вторую пока прототип доделать потом
    {
        HashSet<IToken> result = new HashSet<IToken>();
        for (int i = 0; i < _text.Count; i++)
        {
            if (_text[i].sentenceType == SentenceType.Question)
            {
               
                
                



            }

        }



        return result;
    }

















}