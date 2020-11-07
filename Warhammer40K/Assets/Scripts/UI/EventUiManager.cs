using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUiManager : Subscriber
{
    List<GameObject> active_evs = new List<GameObject>();
    [SerializeField] private int max_one_line;

    private Vector2 start_pos;
    [SerializeField] private Image box;

    private void Awake()
    {
        CalculateBox();
    }

    private void CalculateBox()
    {
        start_pos = new Vector2(box.rectTransform.rect.width / 10 , box.rectTransform.rect.height / 20);
    
        
    }

    public override void Trigger()
    {

    }

    public void AddEvent(GameObject ev)
    {
        active_evs.Add(ev);
        ev.transform.parent = box.gameObject.transform;
        UpdateEventUi();
    }

    public void RemoveEvent(GameObject ev)
    {
        active_evs.Remove(ev);
        UpdateEventUi();
    }

    private void UpdateEventUi()
    {
        Debug.Log("step 1");
        int j = 0;
        float x_position = 0;
        float y_position = 0;

        x_position += start_pos.x;
        y_position += start_pos.y;

        for (int i = 0; i < active_evs.Count; i++)
        {
            Debug.Log("step 2");
            if (j != max_one_line)
            {
                Debug.Log("step 3");
                j++;
                active_evs[i].transform.position = new Vector2(x_position, y_position);
                x_position += box.rectTransform.rect.height / 4;
            }
            else
            {
                j = 0;
                Debug.Log("step 4");
                y_position += box.rectTransform.rect.height / 5;
            }
        }
    }
}
