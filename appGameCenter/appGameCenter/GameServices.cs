
using System;
using System.Collections.Generic;
using System.IO;

public static class GameServices
{
    private static string PATH = "../../data.txt";
    private static List<Player> players = new List<Player>();

    public static List<Player> Players
    {
        get { return GameServices.players; }
    }

    private static List<Game> games = new List<Game>();

    public static List<Game> Games
    {
        get { return GameServices.games; }
    }

    public static void Export()
    {
        // Convertir todas los players en string con el formato
        string playerData = ConvertPlayersToString();
        // Convertir todas los games en string con el formato
        string gamesData = ConvertGamesToString();
        string gamesData2 = ConvertGames2ToString();
        // Escribir en el fichero los datos anteriores separados por el patron '*+++*'
        try
        {
            StreamWriter file = File.CreateText(PATH);
            string completeData = playerData + "\n*+*+*+*\n" + gamesData + "*+*+*+*\n" + gamesData2;
            file.Write(completeData);
            file.Close();
            Console.WriteLine("Datos exportados correctamente");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al exportar los datos. " + e);
        }
    }

    public static Player getPlayer(string stringPlayer)
    {
        Player p = null;
        foreach (Player player in Players)
        {
            if (player.Nickname == stringPlayer)
            {
                p = player;
            }
        }
        return p;
    }

    private static string ConvertGames2ToString()
    {
        string res = "";
        foreach (Game game in Games)
        {
            if (Games.Count>1) { 
            foreach (Platforms ranking in game.Rankings.Keys)
            {
                res += string.Format("{0}-{1}-{2}-", game.Name, game.Rankings[ranking].Name, ranking);
                foreach (Score score in game.Rankings[ranking].Scores)
                {
                    res += string.Format("{0}={1},", score.Nickname, score.Points);
                }
                res += "\n";
            }
            }
            else
            {
                Console.WriteLine("No haya datos para exportar");
            }
        }


        return res;
    }

    private static string ConvertGamesToString()
    {
        string res = "";
        foreach (Game game in Games)
        {
            res += string.Format("{0}-{1}-{2}-", game.Name, game.Genre, game.ReleaseDate);
            foreach (Platforms platform in game.Platforms)
            {
                res += string.Format("{0},", platform);
            }
            res += "\n";
        }


        return res;
    }

    private static string ConvertPlayersToString()
    {
        string res = "";
        foreach (Player player in Players)
        {
            res += string.Format("{0}\n", player.ToString());
        }
        return res;
    }

    internal static Genres getGenre(string dataGenre)
    {
        Genres g = new Genres();
        
        return g;
    }

    public static void Import()
    {
        List<string> lines = ReadFile(PATH);
        List<string> playerLines = new List<string>();
        List<string> gameLines = new List<string>();
        List<string> rankingGameLines = new List<string>();
        bool isGame = false;
        bool isRankingGame = false;
        string stringSeach = "*+*+*+*";
        int state = 0;

        foreach (string line in lines)
        {
            if (line == stringSeach)
            {
                state++;
                if (state == 1)
                {
                    isGame = true;
                    isRankingGame = false;
                }
                else if (state == 2)
                {
                    isGame = false;
                    isRankingGame = true;
                }
            }

            if (state == 0)
            {
                if (line != "")
                {
                    playerLines.Add(line);
                }

            }
            else if (state == 1 && isGame == true)
            {
                if (line != stringSeach || line != "")
                {
                    gameLines.Add(line);
                }

            }
            else if (state == 2 && isRankingGame == true)
            {
                if (line != stringSeach || line != "")
                {
                    rankingGameLines.Add(line);
                }
            }

        }
        //almacenar datos de players importado de un fichero de texto
        foreach (string dataPlayer in playerLines)
        {
            if (dataPlayer != "")
            {
                players.Add(new Player(dataPlayer));
            }
        }
        //almacenar datos de games importado de un fichero de texto
        saveDataGame(gameLines, rankingGameLines);

        //guardar datos en su lista correspondiente
        Console.WriteLine("datos importado");

    }

    public static List<Platforms> getPlatform(string[] dataPlatforms)
    {
        List<Platforms> p = new List<Platforms>();

        
        foreach (Platforms dataPlatform in Enum.GetValues(typeof(Platforms)))
        {
            foreach (string platfrom in dataPlatforms)
            {
                if (platfrom != "")
                {
                    string res = GameServices.existPlatform(platfrom);
                    if (res != "")
                    {
                        if (dataPlatform.ToString().ToUpper() == res.ToUpper())
                        {
                            p.Add(dataPlatform);
                        }
                    }
                }

            }
            
        }
        return p;
    }

    public static string existPlatform(string platfrom)
    {
        string res = "";
        foreach (Platforms dataPlatform in Enum.GetValues(typeof(Platforms)))
        {
            if (dataPlatform.ToString().ToUpper() == platfrom.ToUpper())
            {
                res = dataPlatform.ToString();
            }
        }
        return res;
    }

    private static void saveDataGame(List<string> gameLines, List<string> rankingGameLines)
    {

        //recoremos un foreach da cada lina de datos almacenado del juego
        foreach (string data in gameLines)
        {
            if (data != "*+*+*+*")
            {
                string[] splitData = data.Split('-');
                List<string> gameDataRankingsLine = getListRankingsByGame(splitData[0], rankingGameLines);
                Game newGame = new Game(data, gameDataRankingsLine);
                Games.Add(newGame);
            }
        }


    }

    private static List<string> getListRankingsByGame(string dataNameGame, List<string> rankingGameLines)
    {
        List<string> dataList = new List<string>();
        foreach (string data in rankingGameLines)
        {
            string[] splitData = data.Split('-');
            if (dataNameGame == splitData[0])
            {
                string d = string.Format("{0}-{1}-{2}", splitData[2], splitData[1], splitData[3]);
                dataList.Add(d);
            }
        }
        return dataList;
    }

    private static List<string> ReadFile(string path)
    {
        List<string> lines = new List<string>();
        try
        {
            StreamReader file = File.OpenText(path);
            string line = "";
            while (line != null)
            {
                line = file.ReadLine();
                if (line != null)
                {
                    lines.Add(line);
                }

            }
            file.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al leer el archivo\n" + e);
        }
        return lines;
    }

    #region funcionalidades de de consultas
    //el juego mas antiguo
    public static Game GetOldestGame()
    {
        Game oldestGame = null;
        int oldest = int.MaxValue;
        foreach (Game game in Games)
        {
            int o = game.ReleaseDate;
            if (oldest > o)
            {
                oldestGame = game;
                oldest = o;
            }

        }
        return oldestGame;
    }
    //Puntuacion total de un ranking de un determinado juego
    public static int GetScoreCount(string nameGame, string nameRanking)
    {
        int res = 0;
        foreach (Game game in Games)
        {
            if (game.Name.ToLower() == nameGame.ToLower())
            {
                foreach (Platforms ranking in game.Rankings.Keys)
                {
                    if (game.Rankings[ranking].Name.ToLower() == nameRanking.ToLower())
                    {
                        foreach (Score score in game.Rankings[ranking].Scores)
                        {
                            res += score.Points;
                        }
                    }
                }
            }
        }
        return res;
    }
    //juegos publicado de determinado genero
    public static int gamesCountByGenre(Genres genre)
    {
        int res = 0;
        foreach (Game game in Games)
        {
            if (game.Genre == genre)
            {
                res++;
            }
        }
        return res;
    }
    //juegos con mayor puntuacion
    public static Game gameBestScore()
    {
        Game bestScoreGame = null;
        int bestScore = -1;
        foreach (Game game in Games)
        {
            foreach (Platforms ranking in game.Rankings.Keys)
            {
                foreach (Score score in game.Rankings[ranking].Scores)
                {
                    if (bestScore < score.Points)
                    {
                        bestScoreGame = game;
                        bestScore = score.Points;
                    }
                }
            }
        }
        return bestScoreGame;
    }

    //juegos que una determinada cadena de texto
    public static bool ExistGameByString(string gameString)
    {
        bool res = false;
        foreach (Game game in Games)
        {
            if (game.Name.Contains(gameString))
            {
                res = true;
            }
        }
        return res;
    }
    //juegos de determinado jugador
    public static List<Game> GetGamesByPlayer(Player player)
    {
        List<Game> gamesList = new List<Game>();
        bool isGame = false;
        foreach (Game game in Games)
        {
            foreach (Platforms ranking in game.Rankings.Keys)
            {
                foreach (Score score in game.Rankings[ranking].Scores)
                {
                    if (score.Nickname == player.Nickname)
                    {
                        if (!gamesList.Contains(game))
                        {
                            gamesList.Add(game);
                        }


                    }


                }

            }

        }
        return gamesList;
    }

    //juegos que ha jugado un jugador
    public static void gamesByPlayer()
    {
        List<Game> gamesList = null;
        string res = "";
        foreach (Player player in Players)
        {
            gamesList = GetGamesByPlayer(player);
            res += string.Format("->{0}:\n========>", player.Nickname);

            foreach (Game game in gamesList)
            {
                res += string.Format("{0},", game.Name);
            }
            if (gamesList.Count == 0)
            {
                res += "not Result";
            }

            res += "\n";

        }
        Console.WriteLine(res);
    }
    #endregion

    public static void runTest()
    {
        while (true)
        {
            Console.WriteLine("Enter a Comand: ");
            string data = Console.ReadLine();

            data = data.ToLower();
            string[] splitData = data.Split(' ');
            string comand = splitData[0];
            //comand = comand.Replace(" ", "");
            string value = "";
            string value2 = "";
            if (splitData.Length > 1)
            {
                value = splitData[1];
                // value = value.Replace(" ", "");
                if (splitData.Length > 2)
                {
                    value2 = splitData[2];
                }
            }

            switch (comand)
            {
                case "import":
                    Import();
                    break;
                case "export":
                    Export();
                    break;
                case "oldest":
                    Game g = GetOldestGame();
                    printGameName(g);
                    break;
                case "scorecount":
                    if (value == "" || value2 == "")
                    {
                        Console.WriteLine("Error writing command Example: scoreCount{gameName}_{nameRanking}");
                    }
                    else
                    {
                        int r = GetScoreCount(value, value2);
                        Console.WriteLine(string.Format("the score of the game:{0}", r));
                    }
                    break;
                case "gamescountbygenre":
                    if (value == "")
                    {
                        Console.WriteLine("Error writing command Example: gamesCountByGenre{gameName}");
                    }
                    else
                    {
                        int res = GetCountTotalByGenre(value);
                        Console.WriteLine("Total games of this genre: " + res);
                        //Genres genre;
                        //if (Enum.TryParse(value,true,out genre))
                        //{

                        //    genre = (Genres)Enum.Parse(typeof(Genres), value);
                        //    gamesCountByGenre(genre);
                        //}
                        //else
                        //{
                        //    Console.WriteLine("{0} is not a member of the Genres enumeration.", value);
                        //}
                    }
                    break;

                case "gamesbyplayer":
                    gamesByPlayer();
                    break;

                case "exit":
                    System.Environment.Exit(-1);
                    break;
                default:
                    break;
            }
        }




    }

    private static int GetCountTotalByGenre(string value)
    {

        int res = 0;
        foreach (Genres genre in Enum.GetValues(typeof(Genres)))
        {
            if (genre.ToString().ToUpper() == value.ToUpper())
            {
                res += gamesCountByGenre(genre);

            }

        }

        return res;
    }

    private static void printGameName(Game g)
    {
        if (g != null)
        {
            Console.WriteLine("The oldest game is: " + g.Name);
        }
        else
        {
            Console.WriteLine("Error: the game is null or incorrect");
        }
    }
}

