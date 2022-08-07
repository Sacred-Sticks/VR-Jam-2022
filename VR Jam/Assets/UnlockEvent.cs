using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] objs;
    [SerializeField] Pulser objectivePulser;
    public void Unlock()
    {
        foreach (GameObject o in objs)
        {
            o.SetActive(!o.activeSelf);
        }

        //play unlock sound
        if (objectivePulser)
        {
            objectivePulser.transform.position = gameObject.transform.position;
            objectivePulser.Pulse();
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
