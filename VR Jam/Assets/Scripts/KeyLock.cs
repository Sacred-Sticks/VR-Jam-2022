using UnityEngine;
using Autohand;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [Header("Key Data")]
    [SerializeField] private GameObject key;
    [SerializeField] private float keyDistance;
    [Space]
    [Header("Hand Information")]
    [SerializeField] private Hand leftHand;
    [SerializeField] private Hand rightHand;
    [Space]
    [SerializeField] UnityEvent OnKeyActivation;

    private Grabbable grab;
    private Rigidbody keyBody;

    private float initialAngle;
    private bool checkKey;
    private float currentDistance;

    private void Awake()
    {
        grab = key.GetComponent<Grabbable>();
        grab.isGrabbable = true;
        keyBody = key.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!checkKey) return;

        currentDistance = Vector3.Distance(transform.position, key.transform.position);
        if (currentDistance > keyDistance) return;

        OnKeyActivation.Invoke();

        grab.ForceHandRelease(leftHand);
        grab.ForceHandRelease(rightHand);
        keyBody.isKinematic = true;
        grab.isGrabbable = false;
        checkKey = false;
    }

    public void StartKeyCheck()
    {
        checkKey = true;
        initialAngle = key.transform.rotation.eulerAngles.y;
        if (initialAngle > 180) initialAngle -= 180;
    }

    public void StopKeyCheck()
    {
        checkKey = false;
    }
}
