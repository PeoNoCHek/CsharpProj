
// See https://aka.ms/new-console-template for more information
public static class Program
{
    public static List<(int number, String name, int money)> list = new List<(int number, string name, int money)>();
    public static String[] lines = File.ReadAllLines(@"/home/penb/CsharpProj/AlgorithmPR1/names_old.txt");

    public static Dictionary<int, Tree> tree_dictionary = new Dictionary<int, Tree>();

    public static Dictionary<int, List<List<int>>> requirements = new Dictionary<int, List<List<int>>>();
    public static void Main(String[] args)
    {


        for (int i = 0; i < lines.Length; i++)
        {
            var temp = lines[i].Split(' ');
            list.Add((i, temp[0], Int32.Parse(temp[1])));
        }

        //test
        foreach (var (number, name, money) in list)
        {
            tree_dictionary[number] = new Tree(name, money, number);
        }

        //test

        //test0
        foreach (var line in File.ReadAllLines(@"/home/penb/CsharpProj/AlgorithmPR1/position.txt"))
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(Int32.Parse).ToList();
            int boss = parts[0];

            for (int i = 1; i < parts.Count; i++)
            {
                int sub = parts[i];
                tree_dictionary[boss].vertexes.Add(tree_dictionary[sub]);
                tree_dictionary[sub].parent = tree_dictionary[boss];
            }
        }
        //test0

        Tree root = tree_dictionary.Values.First(n => n.parent == null);
        root.PrintTree();


        //requirements import
        using (StreamReader reader = new StreamReader(@"/home/penb/CsharpProj/AlgorithmPR1/requirements.txt"))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int firstelement = Int32.Parse(temp[0]);

                if (!requirements.ContainsKey(firstelement))
                    requirements[firstelement] = new List<List<int>>();

                for (int i = 1; i < temp.Length; i++)
                {
                    if (Int32.TryParse(temp[i], out int tempInt))
                    {
                        requirements[firstelement].Add(new List<int> { tempInt });
                    }
                    else
                    {

                        int[] values = temp[i].Split('-').Select(Int32.Parse).ToArray();
                        requirements[firstelement].Add(new List<int>(values));
                    }
                }
            }
        }
        //requirements import

        PrintRequirements(requirements);

        //temp methods
        void PrintRequirements(Dictionary<int, List<List<int>>> requirements)
        {
            foreach (var kvp in requirements)
            {
                int person = kvp.Key;
                List<List<int>> alternatives = kvp.Value;

                Console.Write($"Чиновник {person}: ");

                for (int i = 0; i < alternatives.Count; i++)
                {
                    var group = alternatives[i];
                    Console.Write("[");
                    Console.Write(string.Join(",", group));
                    Console.Write("]");

                    if (i < alternatives.Count - 1)
                        Console.Write(" OR ");
                }

                Console.WriteLine();
            }
            //temp methods
        }
    }
}

// Tree0 example = new Tree0("Михаил",100,0);
// example.AddVertex(list);
// example.AddVertex("Лев", 20, 1);
// example.vertexes[0].AddVertex("Злата", 12, 4);
// example.vertexes[0].vertexes[0].AddVertex("Дарина",12,6);
// example.vertexes[0].vertexes[0].AddVertex("Сергей",42,7);
// example.vertexes[0].vertexes[0].vertexes[0].AddVertex("Анна",122,9);
// example.AddVertex("Надежда", 40, 2);
// example.vertexes[1].AddVertex("Мария", 23, 5);
// example.vertexes[1].vertexes[0].AddVertex("Валерия", 12, 8);
// example.vertexes[1].vertexes[0].vertexes[0].AddVertex("Ярослава", 2, 10);
// example.AddVertex("Илья", 45, 3);