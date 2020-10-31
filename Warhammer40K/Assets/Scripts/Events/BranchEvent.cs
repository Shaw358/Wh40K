using UnityEngine;

public class BranchEvent : Event
{
    private BranchBonuses branch_bonuses;
    private Branch branch;

    public void Constructor(Branch temp_branch, BranchBonuses temp_bonus = null )
    {
        branch = temp_branch;
        branch_bonuses = temp_bonus;
    }

    public void Execute()
    {
        //branch.
    }
}