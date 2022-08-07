using UnityEngine;
using Autohand;
using UnityEngine.Events;

public class KeyLock : MonoBehaviour
{
    [Header("Key Data")]
    private GameObject [] allkeys;
    [SerializeField] private float keyDistance;
    private GameObject key;
    
    [Space]
    [SerializeField] UnityEvent OnKeyActivation;
    private Grabbable grab;
    private Rigidbody keyBody;

    private bool checkKey;
    private float currentDistance;

    private void Awake()
    {
        allkeys = GameObject.FindGameObjectsWithTag("Key");
    }

    private void Update()
    {
        if (!checkKey) return;


        currentDistance = Vector3.Distance(transform.position, key.transform.position);
        if (currentDistance < keyDistance) return;

        OnKeyActivation.Invoke();

        keyBody.isKinematic = true;
        checkKey = false;
    }

    public void StartKeyCheck()
    {
        float low = Mathf.Infinity;
        int lidx = -1;
        for (int i = 0; i < allkeys.Length; i++)
        {
            float dist = Vector3.Distance(transform.position, allkeys[i].transform.position);
            if (dist < low)
            {
                low = dist;
                lidx = i;
            }
        }
        key = allkeys[lidx];

        grab = key.GetComponent<Grabbable>();
        grab.isGrabbable = true;
        keyBody = key.GetComponent<Rigidbody>();
        checkKey = true;
    }

    public void StopKeyCheck()
    {
        checkKey = false;
    }
}
