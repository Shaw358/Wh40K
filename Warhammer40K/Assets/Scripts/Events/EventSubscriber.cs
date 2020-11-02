﻿using UnityEngine;
public class EventSubscriber : Subscriber
{
    BranchEvent b_event;
    private int event_length;

    public void Constructor(BranchEvent temp_b_event, int temp_event_length)
    {
        event_length = temp_event_length;
        b_event = temp_b_event;
    }

    protected int days;

    public override bool Trigger()
    {
        Debug.Log("Y'all telling me this bull, Gameobject: " + gameObject.GetInstanceID());
        if (days < event_length)
        {
            days++;
            b_event.Execute();
            return false;
        }
        else
        {
            return true;
        }
    }

    public int GetEventLength()
    {
        return event_length;
    }
}