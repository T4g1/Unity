using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeonController : BasicController, IActionable, ISelectable, ICanBuild, IQueuable
{
    private NavMeshAgent nav;
    private Animator anim;

    [SerializeField]
    private List<GameObject> buildings;
    public List<GameObject> Buildings
    {
        get
        {
            return buildings;
        }
    }

    [SerializeField]
    private float queueTime;
    public float QueueTime
    {
        get
        {
            return QueueTime;
        }
    }

    private new void Awake()
    {
        base.Awake();

        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private new void Update()
    {
        base.Update();

        anim.SetBool("IsWalking", nav.hasPath);

        UpdateQueue();
    }

    public void OnFirstAction(Vector3 point)
    {
    }

    public void OnSecondAction(Vector3 point)
    {
        nav.SetDestination(point);
    }
}
