public class TreeOld
{
    public TreeOld parent;
    public List<TreeOld> vertexes = new List<TreeOld>();
    //эта хрень чисто для моей задачки
    public string name { get; private set; }
    public int money { get; private set; }
    public int number{ get; private set; }

    private bool _locked = false;
    //
    public TreeOld(string name, int money, int number, TreeOld? parent = null)
    {
        this.name = name;
        this.money = money;
        this.number = number;
        this.parent = parent;
    }

    public TreeOld AddVertex(String name, int money, int number)
    {
        if (_locked)
        {
            System.Console.WriteLine("Не удалось добавить: добавление закрыто");
            return null;
        }
        var temp = new TreeOld(name, money, number, this);
        this.vertexes.Add(temp);
        return temp;
    }

    public void Lock() => _locked = true;

    public void PrintTree(string indent = "", bool last = true)
    {
        Console.WriteLine(indent + (last ? "└─ " : "├─ ") + ToString());
        indent += last ? "   " : "│  ";
        for (int i = 0; i < vertexes.Count; i++)
            vertexes[i].PrintTree(indent, i == vertexes.Count - 1);
    }

    public override string ToString() => $"{name} {money} {number}";


}


