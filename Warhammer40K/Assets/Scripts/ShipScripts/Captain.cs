using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CaptainEnums;

public class Captain : ScriptableObject
{
    private string captain_name;
    private int skill_level;
    private double skill_gain = 0.02;

    private Dictionary<SKILLS, double> skill_multiplier = new Dictionary<SKILLS, double>();
    //1st key, 2nd value - double is the multiplier for stat boosts

    public void CaptainSetup(string temp_name)
    {
        skill_multiplier[SKILLS.DAMAGE] = 1;
        skill_multiplier[SKILLS.MOVEMENT] = 1;
        skill_multiplier[SKILLS.SUPPORT] = 1;
        captain_name = temp_name;
    }

    //returns the name of the ship
    public string GetCaptainName()
    {
        return captain_name;
    }

    //returns x skill's double to be multiplied
    public double GetSkillMultiplier(SKILLS skill)
    {
        return skill_multiplier[skill];
    }

    public void UpgradeSkill(SKILLS skill)
    {
        skill_multiplier[skill] += skill_gain;
    }
}
