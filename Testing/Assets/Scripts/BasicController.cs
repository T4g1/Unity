using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    public List<QueuedItem> workQueue;
    public Transform spawnPoint;

    protected void Awake()
    {
        workQueue = new List<QueuedItem>();
    }

    protected void Update()
    {
        UpdateQueue();
    }

    public void UpdateQueue()
    {
        if (workQueue.Count <= 0)
        {
            return;
        }

        QueuedItem item = workQueue[0];

        bool finished = item.Update();

        if (finished)
        {
            Instantiate(item.obj, spawnPoint.position, spawnPoint.rotation);

            workQueue.RemoveAt(0);
        }
    }

    public void AddToQueue(GameObject obj)
    {
        QueuedItem item = new QueuedItem();
        item.obj = obj;
        item.elapsedTime = 0;

        workQueue.Add(item);
    }
}
