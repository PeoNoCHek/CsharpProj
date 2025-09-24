public class Config
{
    public readonly String namesPath;
    public readonly String requirementsPath;
    public readonly String positionPath;

    public Config()
    {
        System.Console.Write("namesPath: ");
        namesPath = System.Console.ReadLine() ?? String.Empty;

        System.Console.Write("requirementsPath: ");
        requirementsPath = System.Console.ReadLine() ?? String.Empty;

        System.Console.Write("positionPath: ");
        positionPath = System.Console.ReadLine() ?? String.Empty;
    }

    public Config(String namesPath, String requirementsPath, String positionPath)
    {
        this.namesPath = namesPath;
        this.requirementsPath = requirementsPath;
        this.positionPath = positionPath;
    }
}