using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoLocation : MonoBehaviour
{
    [SerializeField] private GameObject lightPrefab;
    [Space]
    [SerializeField] private int[] lightLayers;
    [Space]
    [SerializeField] private float intensity;
    [SerializeField] private float red;
    [SerializeField] private float green;
    [SerializeField] private float blue;
    [Space]
    [SerializeField] private float speed;

    GameObject lightObject;
    Light lightComponent;
    Rigidbody bodyComponent;
    Quaternion rotation;
    Color color;

    float x;
    float y;

    private void Start()
    {
        red /= 255;
        green /= 255;
        blue /= 255;
        color = Color.red * red + Color.blue * blue + Color.green * green;
    }

    public void CreateVisuals()
    {
        for (int i = 0; i < lightLayers.Length; i++)
        {
            x = 180 / (lightLayers.Length - 1) * i - 90;
            for (int j = 0; j < lightLayers[i]; j++)
            {
                y = 360 / (lightLayers[i]) * j;
                rotation = Quaternion.Euler(x, y, 0);
                lightObject = Instantiate(lightPrefab, transform.position, rotation);
                lightComponent = lightObject.GetComponent<Light>();
                bodyComponent = lightObject.GetComponent<Rigidbody>();
                lightComponent.color = color;
                lightComponent.intensity = intensity;
                bodyComponent.velocity = lightObject.transform.forward * speed;
            }
        }
    }
}
