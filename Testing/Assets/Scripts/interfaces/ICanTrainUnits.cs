using System.Collections.Generic;
using UnityEngine;

interface ICanTrainUnits
{
    List<GameObject> TrainableUnits { get; }
}