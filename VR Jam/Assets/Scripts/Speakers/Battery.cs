using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Battery : MonoBehaviour
{
    [SerializeField] private string speakerTag;
    [SerializeField] private int fullCharge;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name);
        if (collision.gameObject.tag == speakerTag)
        {
            collision.gameObject.GetComponent<CurrentCharge>().SetCharge(fullCharge);
            Destroy(gameObject);
        }
    }
}
