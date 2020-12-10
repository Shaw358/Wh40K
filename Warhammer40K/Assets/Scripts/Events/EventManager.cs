using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BranchEnums;

public class EventManager : MonoBehaviour
{
    [SerializeField] BranchManager br_manager;
    [SerializeField] private GameObject b_event;

    [SerializeField] private Publisher pub;
    private List<GameObject> active_events = new List<GameObject>();
    [SerializeField] private Sprite[] branch_event_images = new Sprite[10];

    [SerializeField] EventUiManager ev_ui_manager;

    private void Start()
    {
        List<int> tempe = new List<int>();

        for (int i = 0; i < 7; i++)
        {
            tempe.Add(i);
        }
        for (int i = 0; i < 7; i++)
        {
            GenerateNewBranchEvent(365, tempe, "EXTERMINATUS");
        }
    }

    public BranchManager GetBranchManager()
    {
        return br_manager;
    }

    public void GenerateNewBranchEvent(int event_length, List<int> bonuses, string event_name)
    {
        BranchBonuses bonus = new BranchBonuses();

        bonus.Constructor(bonuses);

        GameObject new_event = Instantiate(b_event);
        new_event.name = "branch_event";
        BranchEvent temp_b_ev = new_event.AddComponent<BranchEvent>();
        EventSubscriber temp_sub_ev = new_event.AddComponent<EventSubscriber>();

        temp_b_ev.Constructor(br_manager.GetCurrentBranch(), event_name, branch_event_images[0], bonus);
        temp_sub_ev.Constructor(temp_b_ev, event_length);

        active_events.Add(new_event);
        pub.AddDaySubscriber(temp_sub_ev);
        ev_ui_manager.AddEvent(new_event);
    }
}