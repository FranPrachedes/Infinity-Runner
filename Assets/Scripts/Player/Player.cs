using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variáveis
    private Rigidbody2D rig;

    public float speed;
    public float jumpForce;
    public int health;

    public Animator anim;
    private bool isJumping;

    public GameObject bulletPrefab;
    public Transform firePoint;


    void Start()
    {
        //recebe o rigidbody atual onde o script está anexado
        rig = GetComponent<Rigidbody2D>();
    }

    //chamado a cada física da Unity
    void FixedUpdate()
    {
        //movimenta o rigidbody no eixo x com velocidade determinada pela variável speed
        rig.velocity = new Vector2(speed, rig.velocity.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            OnShoot();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            OnJump();
        }
    }

    public void OnShoot()
    {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void OnJump()
    {
        if (!isJumping)
        {
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("jumping", true);
            isJumping = true;
        }
            
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //procura os sprites com a layer 8
        if (collision.gameObject.layer == 8)
        {
            //para a animação de pulo passando false para o parâmetro
            anim.SetBool("jumping", false);
            //variável de verificação para permitir pular novamente
            isJumping = false;
        }
    }

    public void OnHit(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }
}
