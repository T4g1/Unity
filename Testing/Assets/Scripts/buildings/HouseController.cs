using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : BasicController, IActionable, IBuildable, ICanTrainUnits
{
    [SerializeField]
    private List<GameObject> trainableUnits;
    public List<GameObject> TrainableUnits
    {
        get
        {
            return trainableUnits;
        }
    }

    public void OnFirstAction(Vector3 point)
    {
    }

    public void OnSecondAction(Vector3 point)
    {
    }
}
