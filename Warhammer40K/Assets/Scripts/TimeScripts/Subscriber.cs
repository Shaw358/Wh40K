using UnityEngine;

public class Subscriber
{
    public int days;

    public bool EventTrigger()
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
}