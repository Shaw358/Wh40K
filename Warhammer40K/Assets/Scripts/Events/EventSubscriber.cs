using UnityEngine;
public class EventSubscriber : Subscriber
{
    BranchEvent b_event;
    private int event_length;
    private int days_left;

    public void Constructor(int temp_event_length, int temp_days_left, BranchEvent temp_b_event)
    {
        b_event = temp_b_event;
        event_length = temp_event_length;
        days_left = temp_days_left;
    }

    protected int days;
    public override bool Trigger()
    {
        if (days > 0)
        {
            days--;
            
            return false;
        }
        else
        {
            return true;
        }
    }

    public int EventLength()
    {
        return event_length;
    }

    public int DaysLeft()
    {
        return days_left;
    }
}