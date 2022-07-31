using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterDelay : MonoBehaviour
{
    private float delay;

    Light lightComponent;
    float initialIntensity;

    private void Awake()
    {
        lightComponent = GetComponent<Light>();
    }

    public void SetDelayTime(float delay)
    {
        this.delay = delay;
    }

    private void Start()
    {
        initialIntensity = lightComponent.intensity;
        StartCoroutine(DestroyObject());
        StartCoroutine(DecreaseIntensity());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    private IEnumerator DecreaseIntensity()
    {
        while (true) {
            lightComponent.intensity -= Time.deltaTime * initialIntensity / delay;
            yield return new WaitForEndOfFrame();
        }
    }
}
