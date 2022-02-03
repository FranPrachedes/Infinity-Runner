using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    private Transform player;
    public float speed;
    public float offset;

    // Start is called before the first frame update
    void Start()
    {
        //encontra o player pela tag o passando para variável
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //Chama mais suavemente o que estiver dentro dele
    void LateUpdate()
    {
        //define a direção a se seguir colocando a posição do player como prioridade no eixo x
        Vector3 newCamPos = new Vector3(player.position.x + offset, 0f, transform.position.z);
        //movimenta a camera (devido ao Slerp a movimentação é mais suave) e com a velocidade multiplicada com o deltaTime
        //evita que qualquer alteração no FPS não altere a movimentação
        transform.position = Vector3.Slerp(transform.position, newCamPos, speed * Time.deltaTime);
    }
}
