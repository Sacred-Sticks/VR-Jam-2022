using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEvent : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] objs;
    [SerializeField] Pulser objectivePulser;
    [SerializeField] private int keysNeeded;
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

    public void AddKey()
    {
        keysNeeded -= 1;
        Debug.Log(gameObject.name + " needs " + keysNeeded);
        if (keysNeeded == 0)
        {
            Unlock();
        }
    }
}
