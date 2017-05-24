using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IActionable
{
    void OnFirstAction(Vector3 point);
    void OnSecondAction(Vector3 point);
}
