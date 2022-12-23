using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        // l'agent insegue il player (Target)
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = Target.position;
    }
}
