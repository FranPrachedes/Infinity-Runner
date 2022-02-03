using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public List<GameObject> enemiesList = new List<GameObject>();

    private float timeCount;
    public float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Recebe o tempo assim que se inicia o jogo
        timeCount += Time.deltaTime;

        //Verifica se o tempo que está no timeCount é maior ou igual ao que foi determinado no spawnTime (pré-definido por código)
        if (timeCount >= spawnTime)
        {
            //Instancia inimigos
            SpawnEnemy();
            //Zera o timeCount recomeçando o processo
            timeCount = 0f;
        }
    }

    void SpawnEnemy()
    {
        //Cria um inimigo     //Cria um inimigo aleatório que exista na lista                          //Cria em um lugar randômico sorteando entre 0 e 4 no eixo y
        Instantiate(enemiesList[Random.Range(0, enemiesList.Count)], transform.position + new Vector3(0, Random.Range(-3f, 1f), 0), transform.rotation);
    }

}
