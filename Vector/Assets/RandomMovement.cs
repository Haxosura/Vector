using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomMovement : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float Range;
    public Transform CentrePoint;


    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Agent.remainingDistance <= Agent.stoppingDistance)
        {
            Vector3 point;
            if (randomPoint(CentrePoint.position, Range, out point))
            {
                Agent.SetDestination(point);
            }
        }
    }

    bool randomPoint(Vector3 Center, float Range, out Vector3 Result)
    {
        Vector3 RandPoint = Center + Random.insideUnitSphere * Range;
        NavMeshHit Hit;

        if (NavMesh.SamplePosition(RandPoint, out Hit, 1.0f, NavMesh.AllAreas))
        {
            Result = Hit.position;
            return true;
        }

        Result = Vector3.zero;
        return false;
    }
}