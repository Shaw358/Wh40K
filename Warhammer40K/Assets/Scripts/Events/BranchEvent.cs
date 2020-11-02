using UnityEngine;

public class BranchEvent : Event
{
    private BranchBonuses branch_bonuses;
    private Branch branch;

    public void Constructor(Branch temp_branch, string temp_ev_name, BranchBonuses temp_bonus = null)
    {
        event_name = temp_ev_name;
        branch = temp_branch;
        branch_bonuses = temp_bonus;
    }

    public void Execute()
    {
        //branch.
    }
}