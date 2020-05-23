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
    private TextMeshProUGUI card_name;
    private TextMeshProUGUI card_class;
    private TextMeshProUGUI card_health;

    private void Awake()
    {
        //ship_image = GetComponentInChildren<Image>();
        card_name = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        
    }

    public void GetDescription()
    {

    }

    public void CardSetup(string temp_card_name)
    {
        card_name.text = temp_card_name;
    }
}
