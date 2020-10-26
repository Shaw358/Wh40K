public class Branch : BranchAction
{
    int power = 20;
    BranchBonuses branch_bonusus = new BranchBonuses();

    public int GetPower()
    {
        return power;
    }

    public override void SpecialisedBranchActionEffect()
    {

    }
}