
using System.Collections.Generic;

public class Ranking
{
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    private List<Score> scores;

   

    public List<Score> Scores
    {
        get { return this.scores; }
    }

    public override string ToString()
    {
        string res = "";
        res = string.Format("Ranking:{0}\n",this.Name);
        for (int i = 0; i < Scores.Count; i++)
        {
            res += string.Format("{0}.{1}\n",Scores[i].ToString());
        }
        return res;
    }

    #region Constructores
    public Ranking(string name, List<Score> scores)
    {
        this.name = name;
        this.scores = scores;
    }
    public Ranking()
    {
        this.name = "";
        this.scores = null;
    }
    #endregion
}

