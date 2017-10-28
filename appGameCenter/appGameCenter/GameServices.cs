
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

    private static string ConvertGames2ToString()
    {
        string res = "";
        foreach (Game game in Games)
        {

            foreach (Platforms ranking in game.Rankings.Keys)
            {
                res += string.Format("{0}-{1}-", game.Name, game.Rankings[ranking].Name);
                foreach (Score score in game.Rankings[ranking].Scores)
                {
                    res += string.Format("{0}={1},", score.Nickname, score.Points);
                }
                res += "\n";
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
        }

        res += "\n";
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
        //to do
        Console.WriteLine("----------Players--------------");
        foreach (string s in playerLines)
        {
            Console.WriteLine(s);
        }

        Console.WriteLine("----------Games--------------");
        foreach (string s2 in gameLines)
        {
            Console.WriteLine(s2);
        }
        Console.WriteLine("----------RankingGames--------------");
        foreach (string s3 in rankingGameLines)
        {
            Console.WriteLine(s3);
        }
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
            if (game.Name == nameGame)
            {
                foreach (Platforms ranking in game.Rankings.Keys)
                {
                    if (game.Rankings[ranking].Name == nameRanking)
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
}

