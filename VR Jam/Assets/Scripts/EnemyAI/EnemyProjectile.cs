using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody body;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    private IEnumerator Start()
    {
        Vector3 velocity = transform.forward * speed;

        while (true)
        {
            body.velocity = velocity;
            yield return new WaitForEndOfFrame();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHealth>().ModifyHealth(-1);
            Debug.Log("health lowered");
        }
        Debug.Log("destroyed");
        Destroy(gameObject);
    }
}
