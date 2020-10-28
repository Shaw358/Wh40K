public class EventSubscriber : Subscriber
{
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
}
