using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    public const String configpath = @" Config.txt path ";  //Config.txt path
    public static void Main(String[] args)
    {
        using (InputOutputFileAndReadPaths filereaderandwriter = new InputOutputFileAndReadPaths(configpath, ["Cat and mouse\n", "Cat Mouse  Distance", "-------------------"]))
        {
            Board game = new Board(Int32.Parse(filereaderandwriter.TEXTFROMFILE[0]));
            Regex pattern = new Regex(@"^(\S?)\s*(-?\d+)?$", RegexOptions.Compiled);

            for (int i = 1; i < filereaderandwriter.TEXTFROMFILE.Length && game.gameState == GameState.Start; i++)
            {
                Match matcher = pattern.Match(filereaderandwriter.TEXTFROMFILE[i]);
                Commands.CommandExecute(matcher, game, filereaderandwriter);
            }
            filereaderandwriter.WriteInFile(["-------------------\n\r",
                "Distance traveled:   Mouse   Cat",
                String.Format("{0,26}{1,6}\n",
                (game.mouse.stepsCount),
                (game.cat.stepsCount))]);

            if (game.mouse.state is State.Play or State.NotInGame)
            {
                filereaderandwriter.WriteInFile(["Mouse evaded Cat"]);
                game.mouse.state = State.Winner;
                game.cat.state = State.Looser;
            }

            else
            {
                filereaderandwriter.WriteInFile([$"Mouse caught at: {game.cat.position}"]);
            }

        }
    }
}
