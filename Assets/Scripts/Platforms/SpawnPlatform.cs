using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{

    public List<GameObject> platforms = new List<GameObject>(); //lista dos prefabs das plataformas

    private List<Transform> currentPlatforms = new List<Transform>(); //lista das plataformas geradas na 

    //variáveis
    private Transform player;
    private Transform currentPlatformPoint;
    private int platformIndex;
    public float offset;
    
    void Start()
    {
        //encontra o objeto player pela tag 
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //passa pela lista verificando o valor e fazendo a contagem enquanto acrescenta a variável
        for (int i = 0; i < platforms.Count; i++)
        {
            //faz cópias dos objetos plataforms da lista alterando a posição onde ele vai surgir
            Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.5f), transform.rotation).transform;
            //armazena a atual plataforma criada
            currentPlatforms.Add(p);
            //soma mais 30 a variável adicionando espaço entre a nova plataforma criada e a anterior
            offset += 30f;
        }

        //recebe o ponto final da plataforma armazenando na variável
        currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Método criado para geração das plataformas
    void Move()
    {
        //recebe a diferença de posições do player e da plataforma atual
        float distance = player.position.x - currentPlatformPoint.position.x;

        //verifica se o valor da distância é maior ou igual a 1
        if (distance >= 1)
        {
            //recicla a atual plataforma
            Recycle(currentPlatforms[platformIndex].gameObject);
            //acrescenta a index para alterar a plataforma
            platformIndex++;

            //verifica se a quantidade de plataformas existentes na lista já foram excedidas
            if (platformIndex > currentPlatforms.Count - 1)
            {
                //se sim, volta a contagem para zero, ou seja, para a primeira plataforma
                platformIndex = 0;
            }

            //novamente recebe o ponto final da atual plataforma
            currentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platform>().finalPoint;
        }
    }

    //método criado para reciclagem de plataformas
    public void Recycle(GameObject platform)
    {
        //muda a posição da plataforma no eixo x
        platform.transform.position = new Vector2(offset, -4.5f);

        if (platform.GetComponent<Platform>().spawnObj != null)
        {
            platform.GetComponent<Platform>().spawnObj.Spawn();
        }
        //soma mais 30 a variável adicionando espaço entre a nova plataforma criada e a anterior 
        offset += 30f;
    }
}
