using UnityEngine;

public class Publisher
{
    private delegate bool Delegate();
    Delegate del;

    public void AddSubscriber(Event new_sub)
    {
        del += new_sub.Trigger;
    }

    public void RemoveSubscriber(Event sub)
    {
        del -= sub.Trigger;
    }

    public void Publish()
    {
        if (del != null)
        {
            del.Invoke();
            foreach (Delegate individual in del.GetInvocationList())
            {
                bool result = individual();
                Debug.Log(result);
                if (result)
                {
                    del -= individual;
                }
            }
        }
    }
}