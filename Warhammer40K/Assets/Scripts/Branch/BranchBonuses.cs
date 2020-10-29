using UnityEngine;
using System.Collections.Generic;
using BranchEnums;

public class BranchBonuses
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

    BRANCHES branch;

    Dictionary<BONUS_TYPES, int> branch_stats = new Dictionary<BONUS_TYPES, int>();

    public void Constructor(BRANCHES temp_branch, List<int> stats)
    {
        branch = temp_branch;

        branch_stats.Add(BONUS_TYPES.DAMAGE, stats[0]);
        branch_stats.Add(BONUS_TYPES.PRODUCTION, stats[1]);
        branch_stats.Add(BONUS_TYPES.RESOURCE_COST, stats[2]);
        branch_stats.Add(BONUS_TYPES.LEADER_COST, stats[3]);
        branch_stats.Add(BONUS_TYPES.UPKEEP, stats[4]);
        branch_stats.Add(BONUS_TYPES.SPEED, stats[5]);
        branch_stats.Add(BONUS_TYPES.SUPPLY_CONSUMPTION, stats[6]);
    }

    public int GetBranchBonus(BONUS_TYPES type)
    {
        return branch_stats[type];
    }

    public void SetBranchPower(BONUS_TYPES type, int value)
    {
        branch_stats[type] = value;
    }
}