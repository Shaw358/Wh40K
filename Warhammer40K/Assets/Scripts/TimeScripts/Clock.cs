using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField] private Publisher pub;
    [SerializeField] private ClockUI clock_ui;

    [SerializeField] private float speed_level = 1;
    float timer;
    bool pause;

    private void Awake()
    {
        GetComponent<ClockUI>();
        pub = new Publisher();
    }

    public void Pause()
    {
        if(pause)
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
        if(speed_level < 11)
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
                clock_ui.UpdateTime();
            }
        }
    }
}
