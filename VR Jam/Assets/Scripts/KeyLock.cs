using UnityEngine;
using Autohand;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [Header("Key Data")]
    [SerializeField] private GameObject key;
    [SerializeField] private float maxKeyDistance;
    [Space]
    [SerializeField] UnityEvent OnKeyActivation;

    private Grabbable grab;
    private Rigidbody keyBody;

    private Vector3 initialEntryPoint;
    private float distanceEntered;
    private bool checkKey;
    private bool triggerEntered;

    private void Awake()
    {
        grab = key.GetComponent<Grabbable>();
        grab.isGrabbable = true;
        keyBody = key.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!checkKey) return;

        Debug.Log("Key inserted");

        distanceEntered = Vector3.Distance(initialEntryPoint, key.transform.position);
        if (distanceEntered < maxKeyDistance) return;

        Debug.Log("Key Accepted");

        OnKeyActivation.Invoke();

        keyBody.isKinematic = true;
        checkKey = false;
    }

    public void StartKeyCheck()
    {
        checkKey = true;
        initialEntryPoint = key.transform.position;
    }

    public void StopKeyCheck()
    {
        checkKey = false;
    }
}
