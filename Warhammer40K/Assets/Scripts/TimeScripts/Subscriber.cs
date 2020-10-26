using UnityEngine;

public class Subscriber
{
    public int days;

    public bool Trigger()
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