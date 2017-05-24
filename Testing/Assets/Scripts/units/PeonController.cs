using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeonController : MonoBehaviour, IActionable, ISelectable, ICanBuild
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

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsWalking", nav.hasPath);
    }

    public void OnFirstAction(Vector3 point)
    {
    }

    public void OnSecondAction(Vector3 point)
    {
        nav.SetDestination(point);
    }
}
