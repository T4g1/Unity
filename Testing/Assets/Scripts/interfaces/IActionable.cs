using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IActionable
{
    void OnMainAction(Vector3 point);
    void OnSecondaryAction(Vector3 point);
}
