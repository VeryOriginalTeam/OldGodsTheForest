using UnityEngine;
using System.Collections;

public class basicSword : MonoBehaviour {

    public int damage = 50;
    private int uses = 35;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncreaseHeroDamage()
    {
        GameObject.FindGameObjectWithTag("player").GetComponent<heroScript>().SetExtraDamage(damage, uses);
        GameObject.FindGameObjectWithTag("player").GetComponent<heroAbilities>().extraDmg = true;
    }
    
}
