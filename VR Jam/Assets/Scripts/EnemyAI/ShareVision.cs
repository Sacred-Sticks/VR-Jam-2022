using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareVision : MonoBehaviour
{
    [SerializeField] private int range;
    [SerializeField] private string enemyTag;

    private EnemyVision enemySight;

    private bool playerSpotted = false;
    [SerializeField] private List<GameObject> enemies;

    private void Awake()
    {
        enemySight = GetComponent<EnemyVision>();
    }

    private IEnumerator Start()
    {
        while (!playerSpotted)
        {
            playerSpotted = enemySight.GetPlayerSpotted();
            yield return new WaitForEndOfFrame();
        }
        FindEnemies();
        for (int i = 0; i < enemies.Count; i++)
        {
            Debug.Log(transform.parent.name + " shared with " + enemies[i].name);
            enemies[i].GetComponent<EnemyVision>().SetPlayerSpotted(true);
        }
    }

    private void FindEnemies()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag(enemyTag);
        foreach (GameObject enemy in allEnemies)
        {
            if ((enemy.transform.position - transform.position).magnitude < range)
            {
                if (enemy != gameObject) enemies.Add(enemy);
            }
        }
    }
}
