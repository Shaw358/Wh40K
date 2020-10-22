using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour
{
    Branch[] branches = new Branch[5];

    public enum ACTION
    {
        NONE,
        ADD_POWER,
        REMOVE_POWER,
        PURGE,
        EMERGENCY_POWER,

    }

    private void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            Branch temp = new Branch();
            branches[i] = temp;
        }
    }

    public void BranchAction(int branch, ACTION action, int value)
    {
        switch(action)
        {
            case ACTION.ADD_POWER:
                branches[branch].AddPower(value);
                break;

            case ACTION.REMOVE_POWER:
                branches[branch].RemovePower(value);
                break;

            case ACTION.PURGE:
                break;
        }
    }
}
