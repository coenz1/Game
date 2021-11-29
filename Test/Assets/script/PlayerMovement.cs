using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    walk, attack
}
public class PlayerMovement : MonoBehaviour
{
    public PlayerState currentState;
    public float movementSpeed;
    private Rigidbody2D rb;
    private Vector3 movement;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentState = PlayerState.walk;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Vector3.zero;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && currentState != PlayerState.attack)
        {
            StartCoroutine(Attack());
        }
        else if(currentState == PlayerState.walk)
        {
            UpdateAnimation();
        }
        

    }

    private IEnumerator Attack()
    {
        animator.SetBool("isAttack", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("isAttack", false);
        yield return new WaitForSeconds(.3f);
        currentState = PlayerState.walk;

    }
    void UpdateAnimation()
    {
        if (movement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", movement.x);
            animator.SetFloat("moveY", movement.y);
            animator.SetBool("isMove", true);
        }
        else
        {
            animator.SetBool("isMove", false);
        }
    }
    void MoveCharacter()
    {
        rb.MovePosition(transform.position + movement * movementSpeed * Time.deltaTime);
    }






}
