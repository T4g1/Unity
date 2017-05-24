using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Ressources
{
    public int Food
    {
        get
        {
            return food;
        }
        set
        {
            food = value;

            foodField.text = food.ToString();
        }
    }

    public int Wood
    {
        get
        {
            return wood;
        }
        set
        {
            wood = value;

            woodField.text = wood.ToString();
        }
    }

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;

            goldField.text = gold.ToString();
        }
    }

    public int Stone
    {
        get
        {
            return stone;
        }
        set
        {
            stone = value;

            stoneField.text = stone.ToString();
        }
    }

    public Text foodField;
    public Text woodField;
    public Text goldField;
    public Text stoneField;

    [SerializeField]
    private int food;
    [SerializeField]
    private int wood;
    [SerializeField]
    private int gold;
    [SerializeField]
    private int stone;
}
