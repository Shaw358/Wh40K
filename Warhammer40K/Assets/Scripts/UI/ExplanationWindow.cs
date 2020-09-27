using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExplanationWindow : MonoBehaviour
{
    private PointerEventData pointer;
    private Vector2 position_correction;

    private ExplanationWindowText expl_win_text;
    TextResizeManager txt_manager;

    GameObject previous_obj;
    private bool is_active;


    private void Awake()
    {
        txt_manager = GetComponent<TextResizeManager>();
        expl_win_text = GetComponent<ExplanationWindowText>();
        position_correction = new Vector2(60,0);
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
            if (raycastResults[0].gameObject.TryGetComponent(out HoverInformation obj))
            {
                TrackMouse();
                if(previous_obj != obj.gameObject)
                {
                    expl_win_text.SetText(obj.GetInfoText());
                    txt_manager.Resize();
                    previous_obj = obj.gameObject;
                }
                else
                {
                    //expl_win_text.SetText(string.Empty);
                }
            }
        }
    }

    private void TrackMouse()
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + position_correction;
    }
}