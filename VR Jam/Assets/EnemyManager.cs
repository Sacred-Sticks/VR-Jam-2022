using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    // add sfx for being hit
    // add other fx

    public float hp;
    
    void Start()
    {
            
    }
    
    public void TakeDamage(float dmg)
    {
        Debug.Log(gameObject.name + " took " + dmg + " dmg");
        hp -= dmg;

        if (hp <= 0)
            DeathRoutine();
    }

    private void DeathRoutine()
    {
        Destroy(gameObject);
    }
}
