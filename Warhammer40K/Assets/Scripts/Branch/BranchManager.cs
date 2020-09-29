using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchManager : MonoBehaviour
{
    Branch[] branches;

    public enum ACTION
    {
        NONE,
        ADD_POWER,
        REMOVE_POWER,
        PURGE
    }

    private void Awake()
    {
        for(int i = 0; i < 5; i++)
        {
            branches[i] = new Branch();
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
