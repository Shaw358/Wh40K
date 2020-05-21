using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain
{
    private string name;
    private int skill_level;

    private Dictionary<int, int> skill_multiplier = new Dictionary<int, int>(); 
    //1st key, 2nd value

    public string GetCaptainName()
    {
        return name;
    }

    /*public double GetSkillMutliplier()
    {
        return //multiplier;
    }*/
}
