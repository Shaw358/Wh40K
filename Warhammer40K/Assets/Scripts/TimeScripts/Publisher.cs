﻿using UnityEngine;

public class Publisher : MonoBehaviour
{
    private delegate bool Delegate();
    Delegate del;

    public void AddSubscriber(Subscriber new_sub)
    {
        del += new_sub.Trigger;
    }

    public void RemoveSubscriber(Subscriber sub)
    {
        del -= sub.Trigger;
    }

    public void Publish()
    {
        Debug.Log(gameObject.GetInstanceID() + " publisher");
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