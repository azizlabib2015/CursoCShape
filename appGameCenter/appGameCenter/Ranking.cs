
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

    public Ranking(string data)
    {
        string[] splitData = data.Split('-');

        this.name = splitData[0];
        string[] splitDataScores= splitData[1].Split(',');
        foreach (string dataScore in splitDataScores)
        {
            if (dataScore!="")
            {
                string[] splitDataScore = dataScore.Split('=');
                Player p = GameServices.getPlayer(splitDataScore[0]);
                int pointData = int.Parse(splitDataScore[1]);
                Score s = new Score(p, pointData);
                List<Score> listScore = new List<Score>();
                listScore.Add(s);
                this.scores=listScore;
            }
            
        }
        
    }
    #endregion
}

