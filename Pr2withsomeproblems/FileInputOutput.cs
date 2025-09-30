public class InputOutputFileAndReadPaths : IDisposable
{
    public readonly string[] TEXTFROMFILE;
    private readonly String FILEINPUTPATH;
    private readonly String FILEOUTPUTPATH;
    private StreamWriter writer;
    public void Dispose()
    {
        writer.Dispose();
        System.Console.WriteLine("Завершение");
    }
    public InputOutputFileAndReadPaths(String settingspath, String[] constructortext)
    {
        String[] paths = File.ReadAllLines(settingspath);
        FILEINPUTPATH = paths[0];
        FILEOUTPUTPATH = paths[1];
        TEXTFROMFILE = File.ReadAllLines(FILEINPUTPATH);
        writer = new StreamWriter(FILEOUTPUTPATH, true);
        WriteInFile(constructortext);
    }
    public void WriteInFile(String[] text)
    {
        foreach (String current in text)
        {
            writer.WriteLine(current);
        }
    }
}