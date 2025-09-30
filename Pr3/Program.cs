// See https://aka.ms/new-console-template for more information
string path = @"D:\CsharpProj\Pr3\text.txt";
Text test = Parser.Parse(path);
// System.Console.WriteLine();
// test.PrintAllSentences();
// System.Console.WriteLine();
Pr3Methods.SortByWordsCount(test);
