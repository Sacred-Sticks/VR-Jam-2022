using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    [SerializeField] private float delayBursts;

    private Pulser pulse;

    private void Awake()
    {
        pulse = GetComponentInChildren<Pulser>();
    }

    private IEnumerator Start()
    {
        while (true)
        {
            pulse.Pulse();
            yield return new WaitForSeconds(delayBursts);
        }
    }
}
