using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {

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

    void Update()
    {
       
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
	


}
