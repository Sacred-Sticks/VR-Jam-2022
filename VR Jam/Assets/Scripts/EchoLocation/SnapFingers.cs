using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapFingers : MonoBehaviour
{
    [SerializeField] private float timeBetweenSnaps;
    [SerializeField] private float inputDeadzone;
    
    private InputSystem inputs;
    private Pulser pulse;

    private float heldInput = 0;
    private float tappedInput = 0;
    private float tappedPrevious;
    private float badInput = 0;
    private bool isGrabbing;
    private bool isSnapping = false;

    private void Awake()
    {
        inputs = GetComponent<InputSystem>();
        pulse = GetComponentInChildren<Pulser>();
    }

    private void Update()
    {
        if (isGrabbing) return;
        if (isSnapping) return;

        heldInput = inputs.GetGrip();

        if (heldInput < inputDeadzone) return;

        badInput = inputs.GetTrigger();

        if (badInput > inputDeadzone) return;

        tappedPrevious = tappedInput;
        tappedInput = inputs.GetPrimary();

        if (tappedPrevious != 0) return;
        if (tappedInput < inputDeadzone) return;
        if (isSnapping) return;
        StartCoroutine(Snap());
    }

    private IEnumerator Snap()
    {
        pulse.Pulse();
        Debug.Log("Held: " + heldInput);
        Debug.Log("Tapped: " + tappedInput);
        yield return new WaitForSeconds(timeBetweenSnaps);
        isSnapping = false;
    }

    public void SetIsGrabbing(bool isGrabbing)
    {
        this.isGrabbing = isGrabbing;
    }
}
