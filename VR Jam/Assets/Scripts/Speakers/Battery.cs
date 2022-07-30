using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Battery : MonoBehaviour
{
    [SerializeField] private int speakerLayer;
    [SerializeField] private int fullCharge;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
        if (collision.gameObject.layer == speakerLayer)
        {
            collision.gameObject.GetComponent<CurrentCharge>().SetCharge(fullCharge);
            Destroy(gameObject);
        }
    }
}
