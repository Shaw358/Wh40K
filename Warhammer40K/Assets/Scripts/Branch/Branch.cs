using UnityEngine;

public abstract class Branch 
{
    int power = 20;
    BranchBonuses branch_bonusus = new BranchBonuses();

    public int GetPower()
    {
        return power;
    }

    public void IncreasePower(int power_increase)
    {
        if(power < 100)
        {
            power += power_increase;
        }
    }

    public void DecreasePower(int power_decrease)
    {
        if(power > 0)
        {
            power += power_decrease;
        }
    }

    public abstract void SpecialisedBranchActionEffect();
}