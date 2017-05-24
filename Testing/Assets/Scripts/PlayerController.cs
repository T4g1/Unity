using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ressources ressources;

    private void Start()
    {
        ressources.Food = ressources.Food;
        ressources.Wood = ressources.Wood;
        ressources.Gold = ressources.Gold;
        ressources.Stone = ressources.Stone;
    }

    private void Update()
    {
        // REMOVEME
        if (Input.GetKey(KeyCode.A))
        {
            ressources.Food += 50;
        }
    }
}
