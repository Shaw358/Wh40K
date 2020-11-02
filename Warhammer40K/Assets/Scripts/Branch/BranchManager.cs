using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour
{
    private Branch[] branches = new Branch[6];

    public enum POWER_LEVEL
    {
        some_power = 5,
        sizeable_power = 10,
        substantial_power = 25
    }
    
    /*public enum ACTION
    {
        NONE,
        PARADE, //add power
        EMERGENCY_POWER, //increases substantial amount of power
        RAID, //remove some power
        PURGE, //remove sizeable power
        EXTERMINATE, //remove a lot of power + 20% chance of rebellion
        SABOTAGE // prevent branch from getting events what increases their power for some time
    }*/

    private void Awake()
    {
        branches[0] = new AdministratumBranch();
        branches[1] = new NavyBranch();
        branches[2] = new ArmyBranch();
        branches[3] = new MechanicusBranch();
        branches[4] = new EcclesiarchyBranch();
    }

    public Branch GetBranch(int branch)
    {
        return branches[branch];
    }
}