// See https://aka.ms/new-console-template for more information
string path = @"/home/penb/CsharpProj/Pr3/text.txt";
Text test = Parser.TextParser(path);
System.Console.WriteLine();
test.PrintAllSentences();
System.Console.WriteLine();
//test.PrintAllSentences();
//Проблема такова : присуствует смещение на один байт
//ИСПРАВИТЬ САМУЮ ГЛАВНУЮ ПРОБЛЕМУ ПАРСЕРА :::: ЗНАКИ ПРЕПИНАНИЯ