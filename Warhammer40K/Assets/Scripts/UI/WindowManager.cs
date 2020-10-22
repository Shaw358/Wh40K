using UnityEngine;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    List<GameObject> windows = new List<GameObject>();
    [SerializeField] private GameObject window_container;
    [SerializeField] private GameObject back_button;

    private void Awake()
    {
        windows.Add(GameObject.Find("sub_branches"));
        windows.Add(GameObject.Find("branch"));

        back_button.SetActive(false);
    }

    public void ActivateWindowContainer(bool state)
    {
        window_container.SetActive(state);
    }

    public void Back()
    {
        for (int i = 0; i < windows.Count - 1; i++)
        {
            if(windows[i].activeSelf)
            {
                windows[i].SetActive(false);
                break;
            }
        }
        ActivateSubBranches(true);
        ActivateBackButton(false);
    }

    public void ActivateBackButton(bool state)
    {
        back_button.SetActive(state);
    }

    public void ActivateSubBranches(bool state)
    {
        windows[0].SetActive(state);
    }
}