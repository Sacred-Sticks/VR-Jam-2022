using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int currentHealth;

    public void ModifyHealth(int healthModification)
    {
        currentHealth += healthModification;
        Debug.Log("Player Health now at " + currentHealth);
    }
}
