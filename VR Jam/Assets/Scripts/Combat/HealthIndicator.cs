using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    [SerializeField] private AudioSource[] source;
    [SerializeField] private PlayerHealth health;
    [Space]
    [SerializeField] private float shortDelay;
    [SerializeField] private float longDelayMultiplier;
    [SerializeField] private float longDelay;

    private int previousHealth;
    private int currentHealth;
    private float maxHealth;

    private IEnumerator Start()
    {
        maxHealth = health.GetHealth();

        while (true)
        {
            source[0].Play();
            yield return new WaitForSeconds(shortDelay);
            source[1].Play();
            previousHealth = currentHealth;
            currentHealth = health.GetHealth();
            if (previousHealth != currentHealth)
            {
                longDelay = 1 / (maxHealth - currentHealth + 1);
                longDelay *= longDelayMultiplier;
            }
            yield return new WaitForSeconds(longDelay);
        }
    }
}
