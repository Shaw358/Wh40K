using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptainEnums;

public class Captain
{
    private string name;
    private int skill_level;

    private Dictionary<SKILLS, double> skill_multiplier = new Dictionary<SKILLS, double>();
    //1st key, 2nd value - double is the multiplier for stat boosts

    public void CaptainSetup(string temp_name)
    {
        skill_multiplier[SKILLS.DAMAGE] = 1;
        skill_multiplier[SKILLS.MOVEMENT] = 1;
        skill_multiplier[SKILLS.SUPPORT] = 1;
        name = temp_name;
    }

    public string GetCaptainName()
    {
        return name;
    }

    public double GetSkillMultiplier(SKILLS skill)
    {
        return skill_multiplier[skill];
    }

    public void UpgradeSkill(SKILLS skill)
    {

    }
}
