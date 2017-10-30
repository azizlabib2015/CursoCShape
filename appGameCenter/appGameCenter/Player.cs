using System;
public enum Genres
{
    Action=0,
    Strategy = 1,
    RPG = 2,
    Puzzles = 3,
    Adventure = 4,
    Simulation = 5,
    SurvivalHorror = 6,
    Sandbox = 7
}
public enum Countries
{
    Spain = 0,
    France = 1,
    USA = 2,
    UnitedKingdom = 3,
    Japan = 4,
    Italy = 5,
    Brazil = 6,
    Germany = 7,
    Australia = 8,
    Canada = 9

}
public enum Platforms
{
    PC = 0,
    MAC = 1,
    LINUX = 2,
    PS4 = 3,
    XBOXONE = 4

}
public class Player
{
    private string nickname;

    public string Nickname
    {
        get { return this.nickname; }
    }

    private string email;

    public string Email
    {
        get { return this.email; }
        set { this.email = value; }
    }

    private Countries country;

    public Countries Country
    {
        get { return this.country; }
        set { this.country = value; }
    }
    #region Constructores
    public Player(string nickname, string email, Countries country)
    {
        this.nickname = nickname;
        this.email = email;
        this.country = country;
    }

    public Player(Player p)
    {
        nickname = p.nickname;
        email = p.email;
        country = p.country;
    }
    public Player()
    {

    }
    public Player(string data)
    {
        data = data.Replace(" ", "");
        string[] splitData = data.Split('-');
        this.nickname = splitData[0];
        this.email = splitData[1];
        this.country = (Countries)Enum.Parse(typeof(Countries), splitData[2]);
    }

    #endregion

    //criterio de igualdad
    public override bool Equals(object player)
    {
        bool res = false;
        if (player is Player)
        {
            Player p = (Player)player;
            res = p.nickname == this.Nickname;
        }
        return res;
    }

    //Representacion de cadena
    public override string ToString()
    {
        string res = "";
        res = string.Format("{0}-{1}-{2}", this.Nickname, this.Email, this.Country);
        return res;
    }



}

