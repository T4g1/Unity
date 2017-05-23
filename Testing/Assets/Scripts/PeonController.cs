using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeonController : MonoBehaviour {

    private NavMeshAgent nav;
    private Animator anim;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        anim.SetBool("IsWalking", nav.hasPath);
    }

    public void SetDestination(Vector3 destination)
    {
        nav.SetDestination(destination);
    }
}
