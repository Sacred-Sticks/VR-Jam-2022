using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Autohand;
public class FsManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]Pulser p;
    float t;
    [SerializeField] float interval;
    bool isWalking;
    [SerializeField] AutoHandPlayer player;
    Camera mc;
    void Start()
    {
        isWalking = false;
        //p = GetComponentInChildren<Pulser>();
        mc = player.headCamera;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 v = mc.velocity;
        float m = v.magnitude;
        //Debug.Log(m);

        if (m > 1)
            isWalking = true;
        else
            isWalking = false;

        if (!isWalking)
            return;

        if (t > 0 )
        {
            t -= Time.deltaTime;
        }
        else
        {
            p.Pulse();
            t = interval;
        }
    }
}
