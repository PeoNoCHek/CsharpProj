// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

public class Program0
{
    public static List<(int number, String name, int money)> list = new List<(int number, string name, int money)>();
    public static String[] lines = File.ReadAllLines(@"names");

    public static Dictionary<int, Tree> tree_dictionary = new Dictionary<int, Tree>();

    public static Dictionary<int, List<List<int>>> requirements = new Dictionary<int, List<List<int>>>();

    public static void Main() //String[] args)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            var temp = lines[i].Split(' ');
            list.Add((i, temp[0], Int32.Parse(temp[1])));
        }

        // создаем дерево
        foreach (var (number, name, money0) in list)
        {
            tree_dictionary[number] = new Tree(name, money0, number);
        }

        // формируем связи (подчиненные)
        foreach (var line in File.ReadAllLines(@"position"))
        {
            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int boss = parts[0];

            for (int i = 1; i < parts.Count; i++)
            {
                int sub = parts[i];
                tree_dictionary[boss].vertexes.Add(tree_dictionary[sub]);
                tree_dictionary[sub].parent = tree_dictionary[boss];
            }
        }

        Tree root = tree_dictionary.Values.First(n => n.parent == null);
        root.PrintTree();


        using (var reader = new StreamReader(@"requirements"))
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
                        int[] values = temp[i].Split('-').Select(int.Parse).ToArray();
                        requirements[firstelement].Add(new List<int>(values));
                    }
                }
            }
        }

        PrintRequirements(requirements);

        foreach (var jjjjjj in requirements.Keys)
        {
            foreach (var kkkkkk in requirements[jjjjjj])
            {
                foreach (var dfdfsdfs in kkkkkk)
                {
                    System.Console.WriteLine("   " + jjjjjj + " " + dfdfsdfs + "  " +
                        CheckIsThisBossAvailableToUseThisSub(jjjjjj, dfdfsdfs));
                }
            }
        }

        var (money, numbers) = FindFastestPath();

        if (numbers.Count > 0)
        {
            var pathWithNames = numbers
                .Select(n => $"{tree_dictionary[n].name} ({n})");
            Console.WriteLine($"Минимальный путь: {string.Join(" -> ", pathWithNames)}, стоимость = {money}");
        }
        else
        {
            Console.WriteLine("Путь не найден.");
        }

     

        (int money, List<int> numbers) FindFastestPath()
{
    var memo = new Dictionary<int, (int cost, List<int> path)>();

    (int cost, List<int> path) GetMinCostWithPath(int id, HashSet<int> visiting)
    {
        
        if (memo.TryGetValue(id, out var cached))
                    return cached;

        if (visiting.Contains(id))
            return (int.MaxValue, new List<int>());

        if (!tree_dictionary.ContainsKey(id))
            return (int.MaxValue, new List<int>());

        visiting.Add(id);

        int selfMoney = tree_dictionary[id].money;

        if (!requirements.ContainsKey(id))
        {
            var p = new List<int> { id };
            memo[id] = (selfMoney, p);
            visiting.Remove(id);
            return memo[id];
        }

        int bestExtra = int.MaxValue;
        List<int> bestGroupPath = null;

        foreach (var group in requirements[id])
        {
            bool valid = true;
            int groupSum = 0;
            var groupPath = new List<int>();

            foreach (var sub in group)
            {
                if (!CheckIsThisBossAvailableToUseThisSub(id, sub))
                {
                    valid = false;
                    break;
                }
                
                var (subCost, subPath) = GetMinCostWithPath(sub, visiting);
                if (subCost == int.MaxValue)
                {
                    valid = false;
                    break;
                }

                groupSum += subCost;
                groupPath.AddRange(subPath);
            }

            if (valid && groupSum < bestExtra)
            {
                bestExtra = groupSum;
                bestGroupPath = groupPath;
            }
        }

                (int total, List<int> finalPath) result;
        if (bestExtra == int.MaxValue)
            result = (int.MaxValue, new List<int>());
        else
        {
            var final = new List<int>();
            final.AddRange(bestGroupPath);
            final.Add(id);
            result = (selfMoney + bestExtra, final);
        }

        memo[id] = result;
        visiting.Remove(id);
        return result;
    }

    var (rootCost, rootPath) = GetMinCostWithPath(root.number, new HashSet<int>());
    return (rootCost == int.MaxValue ? 0 : rootCost, rootPath ?? new List<int>());
}


        bool CheckIsThisBossAvailableToUseThisSub(int number_of_boss, int number_of_sub)
        {
            if (!tree_dictionary.ContainsKey(number_of_boss) || !tree_dictionary.ContainsKey(number_of_sub))
                return false;

            Tree current = tree_dictionary[number_of_sub];

            while (current != null)
            {
                if (current.number == number_of_boss)
                    return true;

                current = current.parent;
            }

            return false;
        }

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
                }

                Console.WriteLine();
            }
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