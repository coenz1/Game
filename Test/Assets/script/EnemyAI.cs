using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
	public float checkRadius;
	public float speed;
	public float attackRadius;
	public bool shouldRotate;
	
	public LayerMask whatIsPlayer;
	private Transform target;
	
	private Rigidbody2D rb;
	private Animator anim;
	private Vector2 movement;
	public Vector3 dir;
	private bool chaseRange;
	private bool attackRange;
	
	private void Start()
	{
		rb=GetComponent<Rigidbody2D>();
		anim=GetComponent<Animator>();
		target=GameObject.FindWithTag("Player").transform;
	}
	private void Update()
	{
		anim.SetBool("isRunning",chaseRange);
		chaseRange=Physics2D.OverlapCircle(transform.position,checkRadius,whatIsPlayer);
		attackRange=Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);
		dir=target.position - transform.position;
		float angle=Mathf.Atan2(dir.y,dir.x)*Mathf.Rad2Deg;
		dir.Normalize();
		movement=dir;
		if(shouldRotate){
			anim.SetFloat("X",dir.x);
			anim.SetFloat("Y",dir.y);
		}
	}
	private void FixedUpdate()
	{
		if(chaseRange&&!attackRange)
		{
			MoveCharacter(movement);
		}
		if(attackRange)
		{
			rb.velocity=Vector2.zero;
		}
	}
	private void MoveCharacter(Vector2 dir)
	{
		rb.MovePosition((Vector2)transform.position+(dir*speed*Time.deltaTime));
	}
}