using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUiManager : DaySubscriber
{
    List<Event> active_evs = new List<Event>();

    public override bool Trigger()
    {
        return false;
    }
}
