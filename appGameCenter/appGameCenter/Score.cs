
public class Score:Player
{
    //private string nickname;

    //public string Nickname
    //{
    //    get { return this.nickname; }
    //}

    private int points;

    public int Points
    {
        get { return this.points; }
        set
        {
            if (value >= 0)
            {
                points = value;
            }
            else
            {
                System.Console.WriteLine("Error: pionts debe ser mayor o igual que cero");
            }
        }
    }

    //representacion por cadena
    public override string ToString()
    {
        string res = "";
        res = string.Format("{0}-{1}",this.Nickname,this.Points);
        return res;
    }

    #region Contrsuctores
    

    public Score(string nickname, string email, Countries country,int points) : base(nickname, email, country)
    {
        this.points = points;
    }

    public Score():base()
    {
      
    }

    public Score(Player player1, int points):base(player1)
    {
        
        this.points = points;
    }




    #endregion
}

