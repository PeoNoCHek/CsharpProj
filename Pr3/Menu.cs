public class Menu //возможно удалится
{
    public Action[] action;
    public String[] strings;
    public void DoCommand(int i) => action[i]();
    public void SeeMenu() {
        int i = 0;
        foreach (string s in strings)
        {
            System.Console.WriteLine(i + ' ' + s);
            i++;
        }
    }
    public Menu(int count, String[] strings,Action[] actions)
    {
        action = new Action[count];
        this.strings = strings;
        this.action = actions;
    }
}