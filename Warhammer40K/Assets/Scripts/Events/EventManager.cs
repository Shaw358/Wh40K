﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BranchEnums;

public class EventManager : MonoBehaviour
{
    [SerializeField] BranchManager br_manager;
    [SerializeField] private GameObject b_event;

    [SerializeField] private Publisher pub;
    private List<GameObject> active_events = new List<GameObject>();
    [SerializeField] private Image[] branch_event_images = new Image[10];

    private void Start()
    {
        List<int> tempe = new List<int>();

        for (int i = 0; i < 7; i++)
        {
            tempe.Add(i);
        }
        GenerateNewBranchEvent(365, BRANCHES.NAVY, tempe, "EXTERMINATUS");
    }

    public void GenerateNewBranchEvent(int event_length, BRANCHES branch, List<int> bonuses, string event_name)
    {
        BranchBonuses bonus = new BranchBonuses();

        bonus.Constructor(bonuses);

        GameObject new_event = Instantiate(b_event);
        new_event.name = "branch_event";
        BranchEvent temp_b_ev = new_event.AddComponent<BranchEvent>();
        EventSubscriber temp_sub_ev = new_event.AddComponent<EventSubscriber>();

        temp_b_ev.Constructor(br_manager.GetBranch((int)branch), event_name, bonus);
        temp_sub_ev.Constructor(temp_b_ev, event_length);

        active_events.Add(new_event);
        pub.AddSubscriber(temp_sub_ev);
    }
}