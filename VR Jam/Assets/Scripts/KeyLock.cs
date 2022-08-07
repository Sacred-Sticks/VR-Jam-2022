using UnityEngine;
using Autohand;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [Header("Key Data")]
    [SerializeField] private GameObject key;
    [SerializeField] private float keyDistance;
    [Space]
    [SerializeField] UnityEvent OnKeyActivation;
    private Grabbable grab;
    private Rigidbody keyBody;

    private float initialAngle;
    private bool checkKey;
    private float currentDistance;

    private void Awake()
    {
    }

    private void Update()
    {
        if (!checkKey) return;

        currentDistance = Vector3.Distance(transform.position, key.transform.position);
        if (currentDistance > keyDistance) return;

        OnKeyActivation.Invoke();

        keyBody.isKinematic = true;
        checkKey = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("key"))
        {
            key = collision.gameObject;
        }
    }
    public void StartKeyCheck()
    {
        grab = key.GetComponent<Grabbable>();
        grab.isGrabbable = true;
        keyBody = key.GetComponent<Rigidbody>();
        checkKey = true;
        initialAngle = key.transform.rotation.eulerAngles.y;
        if (initialAngle > 180) initialAngle -= 180;
    }

    public void StopKeyCheck()
    {
        checkKey = false;
    }
}
