using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appGameCenter
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player("player1", "email1", Countries.Spain);
            Player player2 = new Player("player2", "email2", Countries.Japan);
            Player player3 = new Player("player3", "email3", Countries.Italy);
            Player player4 = new Player("player4", "email4", Countries.France);
            Player player5 = new Player("player5", "email5", Countries.Germany);

            List<Platforms> listaPlatform1 = new List<Platforms>() { Platforms.LINUX, Platforms.MAC, Platforms.PS4 };
            List<Platforms> listaPlatform2 = new List<Platforms>() { Platforms.MAC, Platforms.XBOXONE, Platforms.PS4,Platforms.LINUX };

            List<Score> listaScore1 = new List<Score>() { new Score(player1, 5), new Score(player5, 13) };
            List<Score> listaScore2 = new List<Score>() { new Score(player2, 53), new Score(player4, 23) , new Score(player5, 23) };
            List<Score> listaScore3 = new List<Score>() { new Score(player3, 5) };
            Ranking ranking1 = new Ranking("ranking1", listaScore1);
            Ranking ranking2 = new Ranking("ranking2", listaScore2);
            Ranking ranking3 = new Ranking("ranking3", listaScore3);

            Dictionary<Platforms, Ranking> diccionarioRanking1 = new Dictionary<Platforms, Ranking>();
            diccionarioRanking1.Add(Platforms.PS4, ranking1);
            diccionarioRanking1.Add(Platforms.XBOXONE, ranking2);
            diccionarioRanking1.Add(Platforms.LINUX, ranking3);
            Dictionary<Platforms, Ranking> diccionarioRanking2 = new Dictionary<Platforms, Ranking>();
            diccionarioRanking2.Add(Platforms.PS4, ranking2);

            Game game1 = new Game("Game1", Genres.Action, listaPlatform1, 2015, diccionarioRanking1);
            Game game2 = new Game("Game2", Genres.Puzzles, listaPlatform2, 2010, diccionarioRanking1);
            Game game3 = new Game("Game3", Genres.Simulation, listaPlatform2, 2009, diccionarioRanking2);

            GameServices.Players.Add(player1);
            GameServices.Players.Add(player2);
            GameServices.Players.Add(player3);
            GameServices.Players.Add(player4);
            GameServices.Players.Add(player5);

            GameServices.Games.Add(game1);
            GameServices.Games.Add(game2);
            GameServices.Games.Add(game3);
            GameServices.Export();
            //GameServices.Import();
           
           
            foreach (Game game in GameServices.GetGamesByPlayer(player3))
            {
                Console.WriteLine(game.Name+"-");
            }

            GameServices.gamesByPlayer();

            //bool d = GameServices.ExistGameByString("ame");
            //Console.WriteLine(d);



            Console.ReadLine();
        }
    }
}
