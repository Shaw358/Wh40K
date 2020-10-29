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
            DeleteEvent();
            return true;
        }
    }

    public void DeleteEvent()
    {

    }
}
