using System.Text;

public static class Parser
{
    public static Text TextParser(String path)
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
                    //окончание предложения
                    case '?':
                        sentence.SetType(SentenceType.Question);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    case '!':
                        sentence.SetType(SentenceType.Exclamation);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    case '.': //пересмотреть троеточие
                        sentence.SetType(SentenceType.Dot);
                        sentence.AddPunctuation(new Punctuation(symbol));
                        result.AddSentence(sentence);
                        sentence = new Sentence();
                        break;
                    //окончание предложения
                    //знаки препинания
                    case ',' or '«' or '»' or '\'' or '\"' or ':' or ';' or '—': //Здесь основные проблемы касающиеся 
                        if (stringBuilder.Length != 0)
                        {
                            sentence.AddPunctuation(new Punctuation(' '));
                            sentence.AddWord(new Word(stringBuilder.ToString()));
                            stringBuilder.Clear();
                         }
                       
                        //System.Console.WriteLine("добавлен символ " + symbol); //debug
                        sentence.AddPunctuation(new Punctuation(symbol));
                        break;

                    //case '-': //может быть частью слова пока предположу как часть слова
                    //    break;

                    //знаки препинания                
                    //окончание слова
                    case ' ':
                        //ТЕСТОВАЯ ВЕЩЬ УДАЛИТЬ ПОТОМ!!!!!!!!!!!!!!!!!!!
                        if (stringBuilder.Length == 0) break;
                        //System.Console.WriteLine("добавлено слово " + stringBuilder); //debug
                        sentence.AddPunctuation(new Punctuation(' '));
                        sentence.AddWord(new Word(stringBuilder.ToString())); //подумать здесь насчет пробелов
                        stringBuilder.Clear();                          
                        break;
                    //окончание слова
                    //все еще слово
                    default:
                        stringBuilder.Append(symbol);
                        break;
                        //все еще слово
                }
            }
        }
        return result;
    }

}