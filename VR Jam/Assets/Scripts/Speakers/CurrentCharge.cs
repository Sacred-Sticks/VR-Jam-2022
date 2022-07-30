using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCharge : MonoBehaviour
{
    [SerializeField] private int charge;

    private Pulser pulser;

    private void Awake()
    {
        pulser = GetComponentInChildren<Pulser>();
    }

    private IEnumerator Start()
    {
        while (true) {
            yield return new WaitForSeconds(1);
            if (charge > 0)
            {
                pulser.Pulse();
                charge--;
            }
        }
    }

    public void SetCharge(int charge)
    {
        this.charge = charge;
    }
}
