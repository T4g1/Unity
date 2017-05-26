using UnityEngine;

public class QueuedItem
{
    public float elapsedTime;
    public GameObject obj;

    public bool Update()
    {
        elapsedTime += Time.deltaTime;

        return IsFinished();
    }

    public bool IsFinished()
    {
        return elapsedTime >= 5;
    }
}
