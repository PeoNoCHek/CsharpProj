using System.Text;

public static class Parser 
{
    public static Text Parse(String path)
    {
        Text result = new Text();

        using (StreamReader reader = new StreamReader(path))
        {
            StringBuilder stringBuilder = new StringBuilder();
            Sentence sentence = new Sentence();
            int c;
            while ((c = reader.Read()) != -1)
            {
                char symbol = (char)c;
                switch (symbol)
                {
                    case '?':
                        if (stringBuilder.Length > 0)
                        {
                            sentence.AddWord(new Word(stringBuilder.ToString()));
                            stringBuilder.Clear();
                        }
                        sentence.SetType(SentenceType.Question);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    case '!':
                        if (stringBuilder.Length > 0)
                        {
                            sentence.AddWord(new Word(stringBuilder.ToString()));
                            stringBuilder.Clear();
                        }
                        sentence.SetType(SentenceType.Exclamation);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    case '.':

                        if (stringBuilder.Length > 0)
                        {
                            sentence.AddWord(new Word(stringBuilder.ToString()));
                            stringBuilder.Clear();
                        }
                        sentence.SetType(SentenceType.Dot);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    //окончание предложения
                    //знаки препинания
                    case ',' or '«' or '»' or '\'' or '\"' or ':' or ';' or '—':  

                        if (stringBuilder.Length > 0)
                        {
                            sentence.AddWord(new Word(stringBuilder.ToString()));
                            stringBuilder.Clear();
                        }

                        
                        sentence.AddPunctuation(new Punctuation(symbol));
                        break;

                    //case '-' : //может быть частью слова пока предположу как часть слова
                    //    break;

                    //знаки препинания                
                    //окончание слова
                    case ' ':
                        if (stringBuilder.Length > 0)
                        {
                        sentence.AddWord(new Word(stringBuilder.ToString())); //подумать здесь насчет пробелов
                        stringBuilder.Clear();
                        }
                        break;
                    //окончание слова
                    //все еще слово
                    default:
                        stringBuilder.Append(symbol);
                        break;
                        //все еще слово
                }
            }

            if (stringBuilder.Length > 0)
            {
                sentence.AddWord(new Word(stringBuilder.ToString()));
            }
        }
        return result;
    }

}