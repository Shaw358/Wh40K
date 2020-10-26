using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class BranchBonuses : ScriptableObject
{
    public enum BONUS_TYPES
    {
        NONE,
        DAMAGE,
        PRODUCTION,
        RESOURCE_COST,
        LEADER_COST,
        UPKEEP,
        SPEED,
        SUPPLY_CONSUMPTION
    }

    public enum BRANCHES
    {

    }

    Dictionary<BONUS_TYPES, int> branch_stats = new Dictionary<BONUS_TYPES, int>();

}