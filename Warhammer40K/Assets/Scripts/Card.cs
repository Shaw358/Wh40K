using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : Ship
{
    private Shader card_shader;
    private Material card_material;
    private Image ship_image;
    private Image background_image;
    private Image ship_level_icon;
    private Sprite[] ship_level_icon_sprites;
    private Text card_description;

    private void Awake()
    {
        ship_image = GetComponentInChildren<Image>();
    }

    private void Start()
    {
        switch ((int)ship_class)
        {

        }
    }

    public void GetDescription()
    {

    }

    public void CardSetup(string temp_card_description)
    {
        card_description.text = temp_card_description;
    }
}
