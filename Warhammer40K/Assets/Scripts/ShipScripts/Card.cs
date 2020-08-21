using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ShipEnums;

public class Card : MonoBehaviour
{
    private Material card_material;
    private Image background_image;
    private Image ship_image;
    private Image ship_level_icon;
    private Sprite[] ship_level_icon_sprites;
    private TextMeshProUGUI[] card_text;

    private void Awake()
    {
        //ship_image = GetComponentInChildren<Image>();
        card_text = GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void UpdateCardInfo(Ship ship)
    {
        card_text[0].text = ship.GetShipName();
        card_text[1].text =  ship.GetShipClass().ToString();
        card_text[2].text = ship.GetObjectHealth().GetHealth(); 
    }
}
