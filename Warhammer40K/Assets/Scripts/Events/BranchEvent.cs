using UnityEngine;

public class BranchEvent : Event
{
    private BranchBonuses branch_bonuses;
    private Branch branch;

    public void Constructor(Branch temp_branch, string temp_ev_name, Sprite new_ev_image, BranchBonuses temp_bonus = null)
    {
        ev_image.sprite = new_ev_image;
        event_name = temp_ev_name;
        branch = temp_branch;
        branch_bonuses = temp_bonus;
    }

    public void Execute()
    {

    }
}