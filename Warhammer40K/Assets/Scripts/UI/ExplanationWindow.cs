using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExplanationWindow : MonoBehaviour
{
    private PointerEventData pointer;
    private Vector2 position_correction;
    ExplanationWindowText expl_win_text;
    GameObject previous_obj;
    private bool is_active;

    private void Awake()
    {
        expl_win_text = GetComponent<ExplanationWindowText>();
        position_correction = new Vector2(60,60);
    }

    private void Update()
    {
        pointer = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        if (raycastResults.Count > 0)
        {
            if(raycastResults[0].gameObject.TryGetComponent(out HoverInformation obj))
            {
                previous_obj = obj.gameObject;
            }

            if (is_active == false)
            {
                is_active = true;
                 
            }

            if (is_active == true)
            {
                TrackMouse();
            }
        }
        else if(is_active == true)
        {
            is_active = false;
        }
    }

    private void TrackMouse()
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + position_correction;
    }
}