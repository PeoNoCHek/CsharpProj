
// See https://aka.ms/new-console-template for more information


// String[] lines = File.ReadAllLines(@"D:\Алгоритмы\pr1\names.txt");
// List<(int number, String name, int money)> list = new List<(int number, string name, int money)>();

// for (int i = 0; i < lines.Length; i++) {
//     var temp = lines[i].Split(' ');
//     list.Add((i, temp[0], Int32.Parse(temp[1])));
// }

// foreach (var n in list)
// {
//     System.Console.WriteLine(n);
// }

Tree example = new Tree("Михаил",100,0);
example.AddVertex("Лев", 20, 1);
example.vertexes[0].AddVertex("Злата", 12, 4);
example.vertexes[0].vertexes[0].AddVertex("Дарина",12,6);
example.vertexes[0].vertexes[0].AddVertex("Сергей",42,7);
example.vertexes[0].vertexes[0].vertexes[0].AddVertex("Анна",122,9);
example.AddVertex("Надежда", 40, 2);
example.vertexes[1].AddVertex("Мария", 23, 5);
example.vertexes[1].vertexes[0].AddVertex("Валерия", 12, 8);
example.vertexes[1].vertexes[0].vertexes[0].AddVertex("Ярослава", 2, 10);
example.AddVertex("Илья", 45, 3);
example.PrintTree();


