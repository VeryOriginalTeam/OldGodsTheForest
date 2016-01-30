using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {
	private int health;
	private int maxHealth;
	
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


	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player")
			coll.gameObject.SendMessage("DamageHero", 10);
		
	}


	void DamageMonster(int amount)
	{
		health = health - amount;
		if (health <= 0) alive = false;
		
		Debug.Log("Monster takes damage");
	}
}
