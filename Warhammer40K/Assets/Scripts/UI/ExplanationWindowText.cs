using UnityEngine;
using TMPro;

public class ExplanationWindowText : MonoBehaviour
{
    TextMeshProUGUI txt_mesh;

    private void Awake()
    {
        txt_mesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string new_text)
    {
        txt_mesh.text = new_text;
    }
}