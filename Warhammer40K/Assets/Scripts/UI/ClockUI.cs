using System;
using UnityEngine;
using System.Globalization;
using TMPro;

public class ClockUI : MonoBehaviour
{
    DateTime date_time = new DateTime(1, 1, 1, new GregorianCalendar());
    [SerializeField] private TextMeshProUGUI tmpro;

    string display_date;

    public void UpdateTime()
    {
        UpdateDateTime(1);
        display_date = "Y: " + (3000 + date_time.Year.ToString()) + " M: " + date_time.Month.ToString() + " D: " + date_time.Day.ToString();
        tmpro.text = display_date;
    }

    private void UpdateDateTime(int days)
    {
        date_time = date_time.AddDays(days);
    }
}
