using UnityEngine;
using System.Linq;
using BranchEnums;

public class BranchEventPreset : MonoBehaviour
{
    [SerializeField] EventManager ev_manager;
    [SerializeField] BRANCHES branch;
    [SerializeField] int length;
    [SerializeField] string ev_name;
    [SerializeField] string description;

    [SerializeField] private int[] effects = new int[7];

    public void SetBranch(BRANCHES temp_branch)
    {
        branch = temp_branch;
    }

    public void Generate()
    {
        ev_manager.GenerateNewBranchEvent(length, effects.ToList(), ev_name);
    }
}