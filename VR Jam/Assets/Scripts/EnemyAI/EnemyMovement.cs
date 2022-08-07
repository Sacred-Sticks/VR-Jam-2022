using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Positions")]
    [SerializeField] private Transform[] mainRoute;
    [SerializeField] private Transform[] combatPoints;
    [SerializeField] Animator anim;
    [Space]
    [Header("Stopping Values")]
    [SerializeField] private float stoppingDistance;

    private EnemyVision vision;
    private NavMeshAgent agent;

    [SerializeField] private int currentRoutePoint = 0;
    private bool playerSpotted = false;

    private void Awake()
    {
        vision = GetComponentInChildren<EnemyVision>();
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating("UpdateAnim", 0.5f, 0.5f);
    }

    private void UpdateAnim()
    {
        bool isShooting = anim.GetCurrentAnimatorStateInfo(0).IsName("Shoot");
        if (isShooting)
            return;

        if ( agent.remainingDistance > 0 && agent.velocity.magnitude > 0 )
        {
            float r = agent.velocity.magnitude / agent.speed;
            // get ratio of vel to spd and 
            if (anim)
            {
                anim.Play("Walk");
                //anim.SetFloat("locomotion",r);
            }
        }

        if (agent.remainingDistance <= stoppingDistance )
        {
            //Debug.Log("agent is stopped");
            if (anim)
                anim.Play("Idle");
        }
    }

    private IEnumerator Start()
    {
        agent.destination = mainRoute[currentRoutePoint].position;
        yield return new WaitForEndOfFrame();
        while (!playerSpotted)
        {
            if (agent.remainingDistance <= stoppingDistance)
            {
                Debug.Log(gameObject.name + " reached destination ");
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
