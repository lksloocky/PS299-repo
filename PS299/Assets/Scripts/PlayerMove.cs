using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerMove : MonoBehaviour
{

    public float speed = 5;

    public Rigidbody2D rb2d;

    public LayerMask camadaObstaculos; // Camada para verificar colisões com obstáculos


    private void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

private void FixedUpdate() 
{
   MovePlayer();
}
   void MovePlayer()
   {
    float horizontalMove = Input.GetAxisRaw("Horizontal");
    float verticalMove = Input.GetAxisRaw("Vertical");

    rb2d.linearVelocity = new Vector2(horizontalMove * speed, verticalMove * speed);

    // Quando movemos no eixo Y, também queremos mover no eixo Z.
        if (verticalMove != 0)
        {
           
           // Realiza um Raycast para verificar se há algo no caminho
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * Mathf.Sign(verticalMove), Mathf.Abs(verticalMove), camadaObstaculos);

        if (hit.collider == null) // Se não houver colisão no eixo Y
        {
           // Move o personagem no eixo Z dependendo da direção do movimento no Y
                if (verticalMove < 0) // Movimento para cima no Y
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed * Time.deltaTime);
                }
                else if (verticalMove > 0) // Movimento para baixo no Y
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
                }
        }
           
           
        }
   
   }
}
