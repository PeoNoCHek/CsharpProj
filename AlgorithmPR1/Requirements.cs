public class Requirements
{
    public Dictionary<int, List<List<int>>> requirements_dictionary { get; private set; } = new Dictionary<int, List<List<int>>>();
    public Requirements(String requirementsPath)
    {
        using (var reader = new StreamReader(requirementsPath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var temp = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int firstelement = Int32.Parse(temp[0]);

                if (!requirements_dictionary.ContainsKey(firstelement))
                    requirements_dictionary[firstelement] = new List<List<int>>();

                for (int i = 1; i < temp.Length; i++)
                {
                    if (Int32.TryParse(temp[i], out int tempInt))
                    {
                        requirements_dictionary[firstelement].Add(new List<int> { tempInt });
                    }
                    else
                    {
                        int[] values = temp[i].Split('-').Select(int.Parse).ToArray();
                        requirements_dictionary[firstelement].Add(new List<int>(values));
                    }
                }
            }
        }
    }

    public static void PrintRequirements(Dictionary<int, List<List<int>>> requirements)
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