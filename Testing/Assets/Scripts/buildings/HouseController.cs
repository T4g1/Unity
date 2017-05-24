using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour, IActionable, IBuildable
{
    public void OnFirstAction(Vector3 point)
    {
    }

    public void OnSecondAction(Vector3 point)
    {
        Debug.Log("You CANT move a house !");
    }
}
