using UnityEngine;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    List<GameObject> windows = new List<GameObject>();
    [SerializeField] private GameObject window_container;
    [SerializeField] private GameObject back_button;

    private void Awake()
    {
        windows.Add(GameObject.Find("sub_branches"));   //branch selection
        windows.Add(GameObject.Find("branch"));         //branch options
        windows[1].SetActive(false);

        back_button.SetActive(false);
    }

    public void ActivateWindowContainer(bool state)
    {
        window_container.SetActive(state);
    }

    public void Openbranches()
    {
        back_button.SetActive(false);
        for (int i = 0; i < windows.Count - 1; i++)
        {
            windows[i].SetActive(false);
        }
        windows[0].SetActive(true);
    }

    public void OpenBranchOptions()
    {
        back_button.SetActive(true);
        for (int i = 0; i < windows.Count - 1; i++)
        {
            windows[i].SetActive(false);
        }
        windows[1].SetActive(true);
    }
}