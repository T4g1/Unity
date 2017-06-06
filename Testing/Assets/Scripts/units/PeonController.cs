using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeonController : BasicController, IActionable, ISelectable, ICanBuild, IQueuable
{
    private Navigation navigation;
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

        navigation = new Navigation();
        anim = GetComponent<Animator>();
    }

    private new void Update()
    {
        base.Update();

        anim.SetBool("IsWalking", navigation.HasPath());

        UpdateQueue();
    }

    public void OnMainAction(Vector3 point)
    {
    }

    public void OnSecondaryAction(Vector3 point)
    {
        navigation.SetDestination(point);
    }
}
