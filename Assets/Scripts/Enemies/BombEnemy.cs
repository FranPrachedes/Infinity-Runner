using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{

    public GameObject bombPrefab;
    public Transform firePoint;
    public float throwTime;
    private float throwCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Contador
        throwCount += Time.deltaTime;

        //Verifica se é maior ou igual ao tempo definido
        if (throwCount >= throwTime)
        {
            //Arremessa a bomba
            Instantiate(bombPrefab, firePoint.position, firePoint.rotation);
            //Zera o contador
            throwCount = 0f;
        }
    }
}
