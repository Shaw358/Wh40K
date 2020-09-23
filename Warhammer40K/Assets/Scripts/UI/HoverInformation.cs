using UnityEngine;

public class HoverInformation : MonoBehaviour
{
    Color positive_buff;
    Color negative_buff;

    [SerializeField] private string info_text;

    public void SetText()
    {

    }

    public string GetInfoText()
    {
        return info_text;
    }
}