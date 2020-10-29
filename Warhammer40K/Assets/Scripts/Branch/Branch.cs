using UnityEngine;

public abstract class Branch 
{
    int power = 20;
    BranchBonuses branch_bonusus = new BranchBonuses();

    public int GetPower()
    {
        return power;
    }
    public abstract void SpecialisedBranchActionEffect();
}