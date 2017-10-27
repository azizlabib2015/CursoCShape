
public class Score
{
    private string nickname;

    public string Nickname
    {
        get { return this.nickname; }
    }

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
    public Score()
    {

    }

    public Score(string nickname, int points)
    {
        this.nickname = nickname;
        this.points = points;
    }
    #endregion
}

