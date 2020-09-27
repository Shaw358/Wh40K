using UnityEngine;
using TMPro;

public class TextResizeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text_mesh;
    [SerializeField] RectTransform rect;

    public void Resize()
    {
        rect.sizeDelta = new Vector2(250, 25);
        rect.sizeDelta += new Vector2(0, text_mesh.preferredHeight);
    }
}
