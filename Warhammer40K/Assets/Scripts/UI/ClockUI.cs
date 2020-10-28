using UnityEngine;
using TMPro;

public class ClockUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmpro;

    public void UpdateTime(string display_date)
    {
        tmpro.text = display_date;
    }
}
