using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundPulser : MonoBehaviour
{
    // Start is called before the first frame update
    public float threshold;
    [SerializeField] AudioSource asc;
    [SerializeField] Pulser p;
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision c)
    {
        float m = c.impulse.magnitude;
        if ( m > threshold )
        {
            asc.Play();
            p.Pulse();
        }
        //Debug.Log(c.impulse.magnitude);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
