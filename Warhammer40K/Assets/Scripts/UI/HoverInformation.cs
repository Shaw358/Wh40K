using UnityEngine;

public class HoverInformation : MonoBehaviour
{
    [SerializeField] Color positive_buff;
    [SerializeField] Color negative_buff;

    [SerializeField] private string info_text;

    public string GetInfoText()
    {
        return info_text;
    }
}