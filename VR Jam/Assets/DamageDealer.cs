using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int dmg;
    [SerializeField] float cooldown;
    Rigidbody rb;
    float t;
    void Start()
    {
        t = cooldown;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void  OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") && t < 0)
        {
            Debug.Log("Attacking " + other.gameObject.name);
            // only hit enemy if cooldown is done then reset cooldown
            Vector3 v = rb.velocity;

            Debug.Log("Weapon hit enemy");
            other.gameObject.SendMessage("TakeDamage", dmg * v.magnitude);
            t = cooldown;
        }
    }

    void Update()
    {
        if (t > 0)
        {
            t -= Time.deltaTime;

        }
    }
}
