// See https://aka.ms/new-console-template for more information
string path = @"text.txt";
Text test = Parser.TextParser(path);
System.Console.WriteLine();
test.PrintAllSentences();
//test.PrintAllSentences();
//Проблема такова : присуствует смещение на один байт
//ИСПРАВИТЬ САМУЮ ГЛАВНУЮ ПРОБЛЕМУ ПАРСЕРА :::: ЗНАКИ ПРЕПИНАНИЯ