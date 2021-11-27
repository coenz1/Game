using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Animator animator;
    private float horizontal = 0.0f;
    private float speed = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        horizontal = movement.x >0.01f ? movement.x: movement.x <-0.01f ? 1 : 0;
        speed = movement.y > 0.01f ? movement.y : movement.y < -0.01f ? 1 : 0;

        if (movement.x < -0.01f)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", speed);
    }




    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + movement * movementSpeed * Time.deltaTime);
    }
}
