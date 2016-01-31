using UnityEngine;
using System.Collections;

public class heroScript : MonoBehaviour {

    public int baseDmg = 50;
    private int health;
    private int maxHealth;

    private int dmgOut;

    private int xtraDamageUses;
    public int xtraDamage;

    public int DamageOutput
    {
        get { return dmgOut; }
        set { dmgOut = value; }
    }

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
        DamageOutput = baseDmg;
	}

    void Update()
    {
       
    }
    public void DamageHero(int amount)
    {
        health = health - amount;
        if (health <= 0) alive = false;

		Debug.Log("Hero takes damage");
    }

    public void HealHero(int amount)
    {
        health = health + amount;
        if (health > maxHealth) health = maxHealth;
    }

    public void SetExtraDamage(int damage, int uses)
    {
        DamageOutput += damage;
        xtraDamageUses = uses;
    }

    public int Attack()
    {
        if(xtraDamageUses > 0)
        {
            return DamageOutput;
        }
        else
        {
            DamageOutput = baseDmg;
            return baseDmg;
        }
    }

}
