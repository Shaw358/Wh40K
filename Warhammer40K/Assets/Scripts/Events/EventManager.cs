using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] Publisher pub;

    public void GenerateNewEvent()
    {
        Event ev = new Event();
        ev.Constructor();
        pub.AddSubscriber(ev);
    }
}
