using System.Text.RegularExpressions;

public static class Commands
{
    public static void CommandExecute(Match matcher, Board game, InputOutputFileAndReadPaths filereaderandwriter)
    {
           
        switch (matcher.Groups[1].Value[0])
        {
            case 'P':
                game.RedefineDistance();
                if (game.CompareCatAndMousePosition())
                {
                    game.gameState = GameState.End;
                    game.cat.state = State.Winner;
                    game.mouse.state = State.Looser;
                    return;
                }
                else
                {
                    filereaderandwriter.WriteInFile
                    ([
                        String.Format("{0,3} {1,5} {2,9}",
                        (game.cat.state == State.NotInGame ? "??" : game.cat.position),
                        (game.mouse.state == State.NotInGame ? "??" : game.mouse.position),
                        game.distance
                    )]);
                    return;
                }
            case 'M':
                game.mouse.Move(Int32.Parse(matcher.Groups[2].Value));               
                return;
            case 'C':
                game.cat.Move(Int32.Parse(matcher.Groups[2].Value));
                return;
        }
    }
}