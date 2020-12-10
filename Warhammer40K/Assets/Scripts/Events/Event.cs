using UnityEngine;
using UnityEngine.UI;

public class Event : MonoBehaviour 
{
    protected string event_name;
    protected string event_description;
    [SerializeField] protected Image ev_image;

    private void Awake()
    {
        ev_image = GetComponent<Image>();
    }
}