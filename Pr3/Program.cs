// See https://aka.ms/new-console-template for more information
string path = @"/home/penb/CsharpProj/Pr3/text2.txt";
Text test = Parser.Parse(path);
test.SortByTokensCount();
test.PrintAllSentences();


//  System.Console.WriteLine();
//  System.Console.WriteLine("СТАРОЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕ");
//  test.PrintAllSentences();
//  System.Console.WriteLine("СТАРОЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕ");
//  System.Console.WriteLine();


// Text test0 = test.GetSorted();
//  System.Console.WriteLine();
// System.Console.WriteLine("НОВОЕ");
//  test0.PrintAllSentences();
//  System.Console.WriteLine("Новое");
//  System.Console.WriteLine();
//  System.Console.WriteLine();

//   System.Console.WriteLine("СТАРОЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕ");
//  test.PrintAllSentences();
//  System.Console.WriteLine("СТАРОЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕЕ");
//  System.Console.WriteLine();
