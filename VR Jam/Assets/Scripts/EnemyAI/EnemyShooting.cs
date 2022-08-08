using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private float timePerBullet;
    [SerializeField] private int gunRange;
    [SerializeField] Pulser audiopulser;
    [SerializeField] Animator anim; // optional
    NavMeshAgent nma;
    private EnemyVision vision;

    private bool playerSpotted;

    private void Awake()
    {
        vision = GetComponentInChildren<EnemyVision>();
        nma = GetComponent<NavMeshAgent>();
    }

    private IEnumerator Start()
    {
        while (!playerSpotted)
        {
            CheckForPlayer();
            yield return new WaitForEndOfFrame();
        }
        while (true)
        {
            LookAtPlayer();
            ShootAtPlayer();
            yield return new WaitForSeconds(timePerBullet);
        }
    }

    private void CheckForPlayer()
    {
        playerSpotted = vision.GetPlayerSpotted();
    }

    private void LookAtPlayer()
    {
        Vector3 lookAtPlayer = new(playerTransform.position.x, transform.position.y, playerTransform.position.z);
        transform.LookAt(lookAtPlayer);
        gunTransform.LookAt(playerTransform.position);
    }

    private void ShootAtPlayer()
    {
        Vector3 directionTowardPlayer = playerTransform.position - gunTransform.position;

        //first send audio pulse to signify the enemy firing
        audiopulser.SetEchoLocationSourcePos(gunTransform.position);
        audiopulser.Pulse();
        if (anim)
        {
            anim.StopPlayback();
            anim.Play("Shoot");
        }

        if (Physics.Raycast(gunTransform.position, directionTowardPlayer, out RaycastHit hit, float.PositiveInfinity))
        {
            if (hit.collider.gameObject.transform == playerTransform)
            {
                playerTransform.parent.gameObject.GetComponent<PlayerHealth>().ModifyHealth(-1);
            }
        }
    }
}
