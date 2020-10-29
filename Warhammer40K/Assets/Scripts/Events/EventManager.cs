using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private Publisher pub;
    private List<Event> active_events = new List<Event>();

    public void GenerateNewEvent(/* still needs parameters */)
    {
        Event ev = new Event();
        ev.Constructor();
        pub.AddSubscriber(ev);

        active_events.Add(ev);
    }
}
