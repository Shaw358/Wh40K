using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExplanationWindow : MonoBehaviour
{
    private PointerEventData pointer;
    private Vector2 position_correction;
    private RectTransform rect;

    private ExplanationWindowText expl_win_text;
    private Image image;

    GameObject previous_obj;
    private bool is_active;

    private static int growth_margin = 12;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
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
            if(raycastResults[0].gameObject.TryGetComponent(out HoverInformation obj))
            {
                if(previous_obj == obj)
                {
                    Debug.Log("What the fuck?");
                    expl_win_text.ResetText();
                    rect.sizeDelta = new Vector2(264.5f, 22);
                }
                else
                {
                    expl_win_text.SetText(obj.GetInfoText());
                    previous_obj = obj.gameObject;
                }
            }

            if (is_active == false)
            {
                is_active = true; 
                image.enabled = true;
                expl_win_text.gameObject.SetActive(true);
            }

            if (is_active == true)
            {
                if(expl_win_text.IsTextOverflowing())
                {
                    expl_win_text.SetMargin(5);
                    rect.sizeDelta += new Vector2(0, growth_margin);
                }
                TrackMouse();
            }

        }
        else if(is_active == true)
        {
            is_active = false;
            image.enabled = false;
            expl_win_text.ResetText();
        }
    }

    private void TrackMouse()
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) + position_correction;
    }
}