public class Text
{

   private List<Sentence> _text = new List<Sentence>(); //временно публичноке
    public void AddSentence(Sentence sentence)
    {
        _text.Add(sentence);
    }

    public void PrintAllSentences()
    {
        for (int i = 0; i < _text.Count; i++)
        {
            _text[i].printall();
        }
    }
    
}