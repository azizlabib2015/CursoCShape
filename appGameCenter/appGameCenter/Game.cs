
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
        List<Platforms> listP = new List<Platforms>();
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

                    this.platforms = GameServices.getPlatform(splitPlatforms);
                    this.name = splitDataGame[0];
                    foreach (Genres genre in System.Enum.GetValues(typeof(Genres)))
                    {
                        if (genre.ToString().ToLower()== splitDataGame[1].ToLower())
                        {
                            this.genre = genre;
                        }
                    }
                    this.releaseDate = int.Parse(splitDataGame[2]);

                }
                else
                {
                    System.Console.WriteLine("Error :list plataform not exist in dataGame");
                }
            }
        }
        //to doooooooo controlar el error y meter datos ranking
        if (error!=true)
        {
            foreach (string gameData in gameDataRankingsLine)
            {
                string[] splitData = gameData.Split('-');
                foreach (Platforms platform in this.Platforms)
                {
                    string ss = splitData[0].ToLower();
                    if (ss==platform.ToString().ToLower())
                    {

                        string dataR = string.Format("{0}-{1}",splitData[1],splitData[2]);
                        Ranking r = new Ranking(dataR);
                        Dictionary<Platforms, Ranking> dictionaryData = new Dictionary<Platforms, Ranking>();
                        dictionaryData.Add(platform, r);
                        this.rankings = dictionaryData;
                    }
                }

            }
        }
        else
        {
            System.Console.WriteLine("Error :can not save dataGame");
        }
        

    }

    #endregion

}

