using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private GameObject b_event;
    [SerializeField] private GameObject b_event_parent;

    [SerializeField] private Publisher pub;
    private List<GameObject> active_events = new List<GameObject>();

    public void GenerateNewBranchEvent(int event_length, int event_strength, Branch temp_branch)
    {
        GameObject new_event = Instantiate(b_event);
        BranchEvent temp_b_ev = new_event.AddComponent<BranchEvent>();
        EventSubscriber temp_sub_ev = new_event.AddComponent<EventSubscriber>();

        //temp_b_ev.Constructor(temp_branch, );
        //temp_sub_ev.Constructor();

        new_event.transform.parent = b_event_parent.transform;

        active_events.Add(new_event);
    }
}