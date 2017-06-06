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

    public void OnMainAction(Vector3 point)
    {
    }

    public void OnSecondaryAction(Vector3 point)
    {
    }
}
