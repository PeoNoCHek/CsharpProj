// See https://aka.ms/new-console-template for more information
string path = @"/home/penb/Csharpproj/CsharpProj/Pr3/warandpeace0.txt";
//исправить проверку троеточия в парсере !!!!!!!!!!!!!
Text test = Parser.Parse(path);
String[] alltext = {
"Вывести весь текст",
"Вывести все предложения заданного текста в порядке возрастания количества слов в предложениях.",
"Вывести все предложения заданного текста в порядке возрастания длины предложения.",
"Во всех вопросительных предложениях текста найти слова заданной длины (не повторять одни и те же слова)."
};
Action[] action = {
test.PrintAllSentences,
test.SortByWordsCount,
test.SortByTokensCount,
};

Menu menu = new Menu(alltext, action);
while (true)
{
    menu.SeeMenu();
    menu.DoCommand(menu.ReadCommand());
}
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
