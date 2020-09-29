using UnityEngine;
public class Branch : ScriptableObject
{
    int power = 20;
    BranchBonuses branch_bonusus = new BranchBonuses();

    public void AddPower(int temp_power)
    {
        power += temp_power;
        UpdateBonuses();
    }

    public void RemovePower(int temp_power)
    {
        power += temp_power;
        UpdateBonuses();
    }

    public int GetPower()
    {
        return power;
    }

    public void PurgeBranch()
    {
        power -= power / 4;
    }

    private void UpdateBonuses()
    {

    }    
}
