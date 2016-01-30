﻿using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	
	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 200f;
	public float maxSpeed = 5f;
	public float jumpForce = 400f;
	public Transform groundCheck;
	private float jumpTimer;
	public float jumpTime=0.5f;
	public bool doubleJumpEnabled = true;
	private int jumpCounter =0;
	
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private bool hit = false;
	private float hitTimer = 0.0f;
	public float hitTime = 3.0f;
	
	// Use this for initialization
	void Start () {
        //Get the starting position from EventManager.
        //posX = EventManager.eventManager.heroStartPosX;
        //posY = EventManager.eventManager.heroStartPosY;
    }
	

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		
		anim.SetFloat("Speed", Mathf.Abs(h));
		
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		
		if (h > 0 && !facingRight)
			Flip ();
		else if (h < 0 && facingRight)
			Flip ();
		
		if (jump)
		{
			anim.SetTrigger("Jump");
			//rb2d.AddForce(new Vector2(0f, jumpForce));
			rb2d.velocity = new Vector2(rb2d.velocity.x,maxSpeed);
			//jump = false;
		}

		if (Input.GetButtonDown ("Fire1") && !hit) 
		{
			anim.SetBool("hit",true);
			hit =true;
			hitTimer=hitTime;
			Debug.Log ("Hitttttt");
		}
	}

	
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		anim.SetBool ("hit",false);
	}
	
	// Update is called once per frame
	void Update () 
	{


		if ( jumpTimer > 0 )
		{
			jumpTimer -= Time.deltaTime;
			if(jumpTimer<=0)
				jump= false;
		}


		if (hitTimer > 0) {
			hitTimer -= hitTime;
			if(hitTimer<= 0)
			{
				hit=false;
				anim.SetBool ("hit",false);
			}
		}

		bool groundedBefore = grounded;
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		if (groundedBefore != grounded && grounded == true) {
			jumpCounter=0;
		}

		if (Input.GetButtonDown("Jump")&& (grounded || (!jump &&doubleJumpEnabled && jumpCounter <2)))
		{
			jumpTimer = jumpTime;
			jumpCounter++;
			jump = true;
		}
		if(Input.GetButtonUp("Jump"))
		{
			jump = false;
		}


	}
	
	
	
	
	void Flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
