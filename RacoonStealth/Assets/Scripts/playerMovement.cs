using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator anim;

    void Update()
    {
        movement = Vector2.zero;
        ProcessInputs();
        if (movement != Vector2.zero){
            anim.SetFloat("Horizontal",movement.x);
            anim.SetFloat("Vertical",movement.y);
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);
       
    }

    void FixedUpdate() 
    {
       Move();
    }
    void ProcessInputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
         rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
