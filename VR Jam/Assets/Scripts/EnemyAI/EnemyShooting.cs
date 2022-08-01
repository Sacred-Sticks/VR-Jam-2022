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
        Vector3 directionTowardPlayer = playerTransform.position - gunTransform.position;
        Vector3 enemyLookAtPlayer = new Vector3 (playerTransform.position.x, transform.position.y, playerTransform.position.z);
        while (true)
        {
            transform.LookAt(enemyLookAtPlayer);
            gunTransform.LookAt(playerTransform.position);
            ShootAtPlayer(directionTowardPlayer);
            yield return new WaitForSeconds(timePerBullet);
        }
    }

    private void CheckForPlayer()
    {
        playerSpotted = vision.GetPlayerSpotted();
    }

    private void ShootAtPlayer(Vector3 directionTowardPlayer)
    {
        if (Physics.Raycast(gunTransform.position, directionTowardPlayer, out RaycastHit hit))
        {
            if (hit.collider.gameObject.transform == playerTransform)
            {
                playerTransform.parent.gameObject.GetComponent<Health>().ModifyHealth(-1);
                Debug.Log("Dealt Damage");
            }
        }
    }
}
