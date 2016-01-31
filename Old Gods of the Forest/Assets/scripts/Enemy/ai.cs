using UnityEngine;
using System.Collections;

public class ai : MonoBehaviour {
	[HideInInspector] public bool facingLeft = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 200f;
	public float maxSpeed = 5f;
	public float jumpForce = 400f;
	public Transform groundCheck;
	public Transform edgeCheck;
	public Transform edgeCheckStart;

	public float fadeOutTime = 1.0f;
	private float fadeOutTimer = 0.0f;

	private float speed = -1.0f;
	
	private bool grounded1 = false;
	private Animator anim;
	private Rigidbody2D rb2d;
	private enemy enemyScript =null;

	// Use this for initialization
	void Start () {
	
	}

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
		enemyScript = gameObject.GetComponent<enemy> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded1 = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));


		//float h = Input.GetAxis("Horizontal");
		float h = 0.0f;
		//Debug.Log ("ene"+enemyScript);
		//Debug.Log("enemy alive "+enemyScript.Alive);
		if(grounded1 && enemyScript.Alive)
			h=speed;
		//anim.SetFloat("Speed", Mathf.Abs(h));
		
		if (h * rb2d.velocity.x < maxSpeed)
			rb2d.AddForce(Vector2.right * h * moveForce);
		
		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed)
			rb2d.velocity = new Vector2(Mathf.Sign (rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

		if(grounded1)
		if(!Physics2D.Linecast(edgeCheckStart.position, edgeCheck.position, 1 << LayerMask.NameToLayer("Ground")))
		{
			Flip ();
		}
		
		if (jump)
		{
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}

		if (fadeOutTimer > 0) {
			fadeOutTimer-=Time.deltaTime;
			if(fadeOutTimer<=0)
			{
				Destroy(gameObject);
			}
		}

		if (enemyScript.Alive == false) {
			anim.SetBool("dead",true);
			if(fadeOutTimer==0){
				fadeOutTimer=fadeOutTime;
			}
		}
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
		speed *= -1.0f;
	}
}
