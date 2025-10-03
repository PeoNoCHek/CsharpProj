public class Menu //возможно удалится
{   
    //Починить выход за границы
    private Action[] action;
    private String[] strings;
    public void DoCommand(int i) => action[i]();
    public int ReadCommand()
    {
        int result = 0;
        Int32.TryParse(System.Console.ReadLine(), out result);
        System.Console.WriteLine("***********************************************");
        return result;
    }
    public void SeeMenu()
    {
        System.Console.WriteLine("***********************************************");
        int count = Math.Min(action.Length, strings.Length);
        for (int i = 0; i < count; i++)
        {
            System.Console.WriteLine($"{i}. {strings[i]}");
        }
        System.Console.WriteLine("***********************************************");
    }
    public Menu(String[] strings,Action[] actions)
    {
        int count = Math.Min(actions.Length, strings.Length);
        action = new Action[count];
        this.strings = strings;
        this.action = actions;
    }
}