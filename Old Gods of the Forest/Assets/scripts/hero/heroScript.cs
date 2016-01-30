using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {

    private int health;
    private int maxHealth;

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = false;
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public Transform groundCheck;
	
	
	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;


    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private bool alive;

    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }

    // Use this for initialization
    void Start () {
        maxHealth = 3;
        health = maxHealth;
	}


    public void DamageHero(int amount)
    {
        health = health - amount;
        if (health <= 0) alive = false;
    }

    public void HealHero(int amount)
    {
        health = health + amount;
        if (health > maxHealth) health = maxHealth;
    }

	

	
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
		
		if (Input.GetButtonDown("Jump")&& grounded)
		{
			jump = true;
		}
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
			rb2d.AddForce(new Vector2(0f, jumpForce));
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
