using System.Text;

public class WorkersData
{
    //public List<(int number, String name, int money)> allWorkersData { get; private set; } = new List<(int number, string name, int money)>();
    public Dictionary<int, Tree> allWorkersData { get; private set; } = new Dictionary<int, Tree>(); //allWorkersData <---- tree_dictionary
    public Tree root = null;
    public WorkersData(string namesPath, string positionPath)
    {
        using (StreamReader reader = new StreamReader(namesPath))
        {
            int i = 0;
            String[] temp;
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                temp = line.Split(' ');
                if (Int32.TryParse(temp[1], out int money))
                {
                    allWorkersData[i] = new Tree(temp[0], money, i);
                    i++;
                }
            }
        }


        foreach (var line0 in File.ReadAllLines(positionPath))
        {
            var parts = line0.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int boss = parts[0];

            for (int j = 1; j < parts.Count; j++)
            {
                int sub = parts[j];
                allWorkersData[boss].vertexes.Add(allWorkersData[sub]);
                allWorkersData[sub].parent = allWorkersData[boss];
            }
        }

        root = allWorkersData.Values.First(n => n.parent == null);

    }

    public override string ToString()
    {
        StringBuilder returner = new StringBuilder();
        foreach (int key in allWorkersData.Keys)
        {
            returner.AppendLine(allWorkersData[key].ToString());
        }

        return returner.ToString();
    }
}