using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : Ship
{
    private Shader card_shader;
    private Material card_material;
    private Image background_image;
    private Image ship_image;
    private Image ship_level_icon;
    private Sprite[] ship_level_icon_sprites;
    private TextMeshProUGUI[] card_text;
    //card_text[0] = name of the ship
    //card_text[1] = ship class
    //card_text[2] = ship health

    private void Awake()
    {
        //ship_image = GetComponentInChildren<Image>();
        card_text = GetComponentsInChildren<TextMeshProUGUI>();
    }

    public void CardSetup()
    {
        card_text[0].text = ship_name;
        card_text[1].text = ship_class.ToString();
        card_text[2].text = object_health.GetHealth(); 
    }

    //TODO: Select Multiple ships
    private void OnMouseDown()
    {
        
    }
}
