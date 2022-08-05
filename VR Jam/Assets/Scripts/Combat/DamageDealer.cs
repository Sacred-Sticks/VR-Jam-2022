using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int dmg;
    [SerializeField] float cooldown;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] Pulser pulser; 
    Rigidbody rb;
    float t;
    void Start()
    {
        t = cooldown;
        rb = GetComponent<Rigidbody>();
        //hitParticles = GameObject.Find("HitParticles") ;
    }

    // Update is called once per frame
    void  OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") && t < 0)
        {
            Vector3 point = collision.contacts[0].point;
            Vector3 normal = collision.contacts[0].normal;
            
            Debug.Log("normal " + normal);
            Debug.Log("Attacking " + collision.gameObject.name);
            // only hit enemy if cooldown is done then reset cooldown
            Vector3 v = rb.velocity;

            Debug.Log("Weapon hit enemy");
            collision.gameObject.SendMessageUpwards("TakeDamage", dmg * v.magnitude);
            t = cooldown;

            // FX

            pulser.gameObject.transform.position = point;
            pulser.Pulse();

            ParticleSystem fx = Instantiate(hitParticles, point, Quaternion.LookRotation(normal, Vector3.up));
            fx.Emit(10);
            Destroy(fx, 2f);
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
