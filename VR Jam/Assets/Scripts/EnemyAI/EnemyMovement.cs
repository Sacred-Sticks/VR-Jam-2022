using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] mainRoute;
    [SerializeField] private Transform[] combatPoints;

    [SerializeField] private float stoppingDistance;

    private EnemyVision vision;
    private NavMeshAgent agent;

    private int currentRoutePoint = 0;
    private bool playerSpotted = false;

    private void Awake()
    {
        vision = GetComponentInChildren<EnemyVision>();
        agent = GetComponent<NavMeshAgent>();
    }

    private IEnumerator Start()
    {
        agent.destination = mainRoute[currentRoutePoint].position;
        while (!playerSpotted)
        {
            if (agent.remainingDistance < stoppingDistance)
            {
                currentRoutePoint++;
                if (currentRoutePoint == mainRoute.Length) currentRoutePoint = 0;
                agent.destination = mainRoute[currentRoutePoint].position;
            }
            playerSpotted = vision.GetPlayerSpotted();
            yield return new WaitForEndOfFrame();
        }

        int nearestPoint = FindClosestPoint();
        agent.destination = combatPoints[nearestPoint].position;
    }

    private int FindClosestPoint()
    {
        int closestPoint = 0;
        float distanceFromClosestPoint = -1;
        float distance;
        for (int i = 0; i < combatPoints.Length; i++)
        {
            distance = Vector3.Distance(transform.position, combatPoints[i].position);
            if (distance < distanceFromClosestPoint || distanceFromClosestPoint == -1)
            {
                distanceFromClosestPoint = distance;
                closestPoint = i;
            }
        }
        return closestPoint;
    }
}
