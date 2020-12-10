using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventUiManager : Subscriber
{
    List<GameObject> active_evs = new List<GameObject>();
    [SerializeField] private int max_one_line;

    [SerializeField] private Transform start_pos;
    [SerializeField] private Image box;

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
        int j = 0;
        float x_position = 0;
        float y_position = 0;

        x_position += start_pos.position.x;
        y_position += start_pos.position.y;

        for (int i = 0; i < active_evs.Count; i++)
        {
            if (j == max_one_line)
            {
                j = 0;
                x_position = start_pos.position.x;
                y_position -= box.rectTransform.rect.height / 5;
            }
            j++;
            active_evs[i].transform.position = new Vector2(x_position, y_position);
            x_position += box.rectTransform.rect.height / 7;
        }
    }
}
