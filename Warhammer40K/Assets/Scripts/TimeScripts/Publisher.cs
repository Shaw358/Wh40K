using UnityEngine;

public class Publisher : ScriptableObject
{
    private delegate bool Delegate();
    Delegate del;

    public void AddSubscriber(Event new_sub)
    {
        del += new_sub.EventTrigger;
    }

    public void RemoveSubscriber(Event sub)
    {
        del -= sub.EventTrigger;
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