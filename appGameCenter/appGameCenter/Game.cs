
using System.Collections.Generic;

public class Game
{
    private string name;

    public string Name
    {
        get { return this.name; }
    }

    private Genres genre;

    public Genres Genre
    {
        get { return genre; }
    }

    private List<Platforms> platforms;

    public List<Platforms> Platforms
    {
        get { return platforms; }
    }

    private int releaseDate;

    public int ReleaseDate
    {
        get { return this.releaseDate; }
    }

    private Dictionary<Platforms,Ranking> rankings;

    public Dictionary<Platforms,Ranking> Rankings
    {
        get { return this.rankings; }
    }


    //criterio de Igualdad
    public override bool Equals(object game)
    {
        bool res = false;
        if (game is Game)
        {
            Game g = (Game)game;
            res = g.name == this.Name;
        }
        return res;
    }

    //representacion de cadena

    public override string ToString()
    {
        string res = "";
        res = string.Format("---{0}({1}-)",this.Name,this.ReleaseDate);
        foreach (Platforms plataform in this.Platforms)
        {
            res += string.Format("{0},",plataform);
        }
        res += string.Format("-{0}---",this.Genre);
        foreach (Platforms ranking in this.Rankings.Keys)
        {
            res += string.Format("-{0}({1})",this.Rankings[ranking].Name, this.Rankings[ranking].Scores.Count);
        }
        return res;
    }




    #region Constructores
    public Game(string name, Genres genre, List<Platforms> plataforms, int releaseDate, Dictionary<Platforms, Ranking> rankings)
    {
        this.name = name;
        this.genre = genre;
        this.platforms = plataforms;
        if (releaseDate>=1980&&releaseDate<=2018)
        {
            this.releaseDate = releaseDate;
        }
        else
        {
            System.Console.WriteLine("Error: el rango debe ser entre 1980 y 2018");
        
        }
        
        this.rankings = rankings;
    }

    public Game(string data, List<string> gameDataRankingsLine)
    {
        bool error = false;
        //hacemos el split de la cadena data
        string[] splitDataGame = data.Split('-');
        //almacenar datos del Game

        if (splitDataGame.Length==4)
        {
            if (splitDataGame[3]=="")
            {
                System.Console.WriteLine("Error :list plataform not exist in dataGame");
            }
            else
            {
                string[] splitPlatforms = splitDataGame[3].Split(',');
                if (splitPlatforms.Length>1)
                {
                    foreach (string platfrom in splitPlatforms)
                    {
                        if (platfrom!="")
                        {
                            string res = GameServices.existPlatform(platfrom);
                            if (res!="")
                            {
                                Platforms p = GameServices.getPlatform(res);
                                this.platforms.Add(p);
                            }
                        }
                        else
                        {
                            error = true;
                            System.Console.WriteLine("Error :list plataform not exist in dataGame");
                        }
                    }
                }
                else
                {
                    System.Console.WriteLine("Error :list plataform not exist in dataGame");
                }
            }
        }
        //to doooooooo controlar el error y meter datos ranking
        

    }

    #endregion

}

