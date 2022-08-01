using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Sightline Data")]
    [SerializeField] private int maxAngleRange;
    [SerializeField] private float sightRange;
    [Space]
    [Header("Player Data")]
    [SerializeField] private string playerTag;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private bool playerSpotted = false;
    private Vector3 lookAt;

    private void Update()
    {
        if (!playerSpotted) 
        {
            playerSpotted = CheckForPlayer();
        }
    }

    private bool CheckForPlayer()
    {
        lookAt = playerTransform.position - transform.position;
        float angle = Vector3.Angle(transform.forward, lookAt);
        if (angle > maxAngleRange)
        {
            return false;
        }
        if (!FireRaycast(lookAt))
        {
            return false;
        }
        return true;
    }

    private bool FireRaycast(Vector3 direction)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, sightRange))
        {
            return hit.collider.gameObject.CompareTag(playerTag);
        }
        return false;
    }

    public bool GetPlayerSpotted()
    {
        return playerSpotted;
    }

    public void SetPlayerSpotted(bool playerSpotted)
    {
        this.playerSpotted = playerSpotted;
    }
}
