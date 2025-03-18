using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Vector2 movement;

    public float speed = 5;

    public Rigidbody2D rb2d;

    private void start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

private void FixedUpdate() 
{
    rb2d.AddForce(movement * speed);
}
    public void OnMove(InputValue inputValue)
    {
        movement = inputValue.Get<Vector2>();
    }
}
