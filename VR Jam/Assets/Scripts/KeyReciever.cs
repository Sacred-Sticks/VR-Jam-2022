using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyReciever : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool hasKey;
    [SerializeField] GameObject[] toggleObjs; 
    void Start()
    {
        hasKey = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Key"))
            {
            hasKey = true;
            GameObject.Destroy(other.gameObject);

            foreach ( GameObject o in toggleObjs )
            {
                o.SetActive(!o.activeSelf);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
