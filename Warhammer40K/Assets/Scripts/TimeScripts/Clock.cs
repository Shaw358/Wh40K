using UnityEngine;
using System.Globalization;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private Publisher pub;
    [SerializeField] private ClockUI clock_ui;

    [SerializeField] private float speed_level = 1;
    float timer;
    bool pause;

    DateTime date_time = new DateTime(1, 1, 1, new GregorianCalendar());
    string display_date;
    int time_correction;

    private void Awake()
    {
        GetComponent<ClockUI>();
        pub = new Publisher();
    }

    public void Pause()
    {
        if (pause)
        {
            pause = false;
        }
        else
        {
            pause = true;
        }
    }

    public void SetSpeedLevel(int lvl)
    {
        speed_level = lvl;
    }
    public void DecreaseSpeedLevel(int lvl)
    {
        if (speed_level > 1)
        {
            speed_level -= lvl;
        }
    }
    public void IncreaseSpeedLevel(int lvl)
    {
        if (speed_level < 11)
        {
            speed_level += lvl;
        }
    }

    private void FixedUpdate()
    {
        if (!pause)
        {
            Debug.Log("step 1");
            timer += Time.deltaTime;
            if (timer > 2 / speed_level)
            {
                Debug.Log("step 2");
                timer -= 2 / speed_level;

                pub.Publish();
                UpdateDateTime(1);
            }
        }
    }
    private void UpdateDateTime(int days)
    {
        date_time = date_time.AddDays(days); 
        time_correction = 30000 + date_time.Year;
        display_date = "Y: " + time_correction + " M: " + date_time.Month.ToString() + " D: " + date_time.Day.ToString();

        clock_ui.UpdateTime(display_date);
    }
}
