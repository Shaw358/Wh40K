using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExplanationWindowText : MonoBehaviour
{
    TextMeshProUGUI info_text;

    private void Awake()
    {
        info_text = GetComponentInChildren<TextMeshProUGUI>();    
    }

    public void SetText(string new_text)
    {
        info_text.text = new_text;
    }
    
    public void ClearText()
    {
        info_text.text = string.Empty;
    }
}