﻿using UnityEngine;
using Planets;

public class Publisher : MonoBehaviour
{
    private delegate bool DelegateDay();
    DelegateDay day_countdown_del;
    private delegate void DelegateTick();
    DelegateTick normal_tick_del;

    private void Awake()
    {
        
    }

    public void AddDaySubscriber(DaySubscriber new_sub)
    {
        day_countdown_del += new_sub.Trigger;
    }

    public void AddSubscriber(Subscriber new_sub)
    {
        normal_tick_del += new_sub.Trigger;
    }

    public void RemoveDaySubscriber(DaySubscriber sub)
    {
        day_countdown_del -= sub.Trigger;
    }

    public void Publish()
    {
        normal_tick_del?.Invoke();

        if (day_countdown_del != null)
        {
            foreach (DelegateDay individual in day_countdown_del.GetInvocationList())
            {
                bool result = individual();
                if (result)
                {
                    day_countdown_del -= individual;
                }
            }
        }
    }
}