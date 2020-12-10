using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    private List<Popup> popup_pool = new List<Popup>();
    [SerializeField] private GameObject popup_prefab;

    private void Awake()
    {
        foreach (Transform child in gameObject.transform)
        {
            popup_pool.Add(child.GetComponent<Popup>());
            child.gameObject.SetActive(false);
        }
    }

    public void ActivatePopup(string description, string response)
    {
        foreach (Popup pop in popup_pool)
        {
            if(!pop.gameObject.activeSelf)
            {
                pop.gameObject.SetActive(true);
                pop.NewPopup(description, response);
            }
            else
            {
                Popup new_pop = Instantiate(popup_prefab, transform.position, transform.rotation).GetComponent<Popup>();
                popup_pool.Add(new_pop);
            }
        }
    }
}
