using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI response;

    private void Awake()
    {
        Debug.Log(transform.GetChild(0).GetChild(0).name);
        description = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        response = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void NewPopup(string new_description, string new_response)
    {
        description.text = new_description;
        response.text = new_description;
    }
}