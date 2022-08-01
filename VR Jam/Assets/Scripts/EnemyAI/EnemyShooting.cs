using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform gunTransform;
    [SerializeField] private float timePerBullet;
    [SerializeField] private int gunRange;

    private EnemyVision vision;

    private bool playerSpotted;

    private void Awake()
    {
        vision = GetComponentInChildren<EnemyVision>();
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
        if (Physics.Raycast(gunTransform.position, directionTowardPlayer, out RaycastHit hit, float.PositiveInfinity))
        {
            if (hit.collider.gameObject.transform == playerTransform)
            {
                playerTransform.parent.gameObject.GetComponent<PlayerHealth>().ModifyHealth(-1);
            }
        }
    }
}
