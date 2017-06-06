using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation
{
    private bool hasPath;
    private Vector3 destination;

    public bool HasPath()
    {
        return hasPath;
    }

    public void SetDestination(Vector3 _destination)
    {
        destination = _destination;

        hasPath = true;
    }
}