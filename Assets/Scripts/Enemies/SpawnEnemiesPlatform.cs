using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPlatform : Enemy
{

    public GameObject enemyPrefabs;
    private GameObject currentEnemy;

    public List<Transform> points = new List<Transform>();

    void Start()
    {
        CreateEnemy();
    }

    void Update()
    {
       
    }

    public void Spawn()
    {
        if (currentEnemy == null)
        {
            CreateEnemy();
        }
        else if (hasEnemy)
        {
            Destroy(currentEnemy);
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        int pos = Random.Range(0, points.Count);
        GameObject e = Instantiate(enemyPrefabs, points[pos].position, points[pos].rotation);
        currentEnemy = e;
        hasEnemy = true;
    }
}
