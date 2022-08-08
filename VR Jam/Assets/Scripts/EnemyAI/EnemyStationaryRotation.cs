using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStationaryRotation : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float timeToRotate;
    [SerializeField] private int degreesToRotate;
    [SerializeField] private int rotationDirection;
    [SerializeField] private Transform headTransform;

    private EnemyVision vision;

    private Vector3 rotation;
    
    private float t = 0;
    private float rotationSpeed;
    private float initialYRot;
    bool playerSpotted;

    private void Awake()
    {
        vision = GetComponentInChildren<EnemyVision>();
    }

    private IEnumerator Start()
    {
        rotationSpeed = degreesToRotate / timeToRotate * rotationDirection;
        initialYRot = transform.rotation.eulerAngles.y;

        while (!playerSpotted)
        {
            Rotate();
            playerSpotted = vision.GetPlayerSpotted();
            yield return new WaitForEndOfFrame();
        }
        Vector3 lookAt;

        while (true)
        {
            lookAt = new(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            transform.LookAt(lookAt);
            yield return new WaitForEndOfFrame();
        }
    }

    private void Rotate()
    {
        headTransform.Rotate(transform.up, rotationSpeed * Time.deltaTime, Space.Self);
        t += Time.deltaTime;
        if (t >= timeToRotate)
        {
            t = -timeToRotate;
            rotationSpeed *= -1;
            rotation = new(transform.rotation.eulerAngles.x, rotationDirection * degreesToRotate + initialYRot, transform.rotation.eulerAngles.z);
            headTransform.rotation = Quaternion.Euler(rotation);
            rotationDirection *= -1;
        }
    }
}
