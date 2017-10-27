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
            Player player1 = new Player("player1","email1",0);
            Player player2 = new Player("player2", "email2", 0);
            Player player3 = new Player("player3", "email3", 0);
            Player player4 = new Player("player4", "email4", 0);
            Player player5 = new Player("player5", "email5", 0);

            List<Platforms> listaPlatform1 = new List<Platforms>(){Platforms.LINUX,Platforms.MAC,Platforms.PS4};

            List<Score> listaScore1 = new List<Score>() { new Score("score1", 5), new Score("score2", 13) };
            List<Score> listaScore2 = new List<Score>() { new Score("score3", 53), new Score("score4", 23) };

            Ranking ranking1 = new Ranking("ranking1",listaScore1);
            Ranking ranking2 = new Ranking("ranking2", listaScore2);
            Dictionary<Platforms, Ranking> diccionarioRanking1 = new Dictionary<Platforms, Ranking>();
            diccionarioRanking1.Add(Platforms.PS4,ranking1);
            diccionarioRanking1.Add(Platforms.PC, ranking2);
            Game game1 = new Game("Game1",Genres.Action,listaPlatform1,2015,diccionarioRanking1);

            
            GameServices.Players.Add(player1);
            GameServices.Players.Add(player2);
            GameServices.Players.Add(player3);
            GameServices.Players.Add(player4);
            GameServices.Players.Add(player5);

            GameServices.Games.Add(game1);
            GameServices.Export();
            GameServices.Import();

            Console.ReadLine();
        }
    }
}
