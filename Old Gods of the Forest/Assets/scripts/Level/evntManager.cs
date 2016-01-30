using UnityEngine;
using System.Collections;

public class evntManager : MonoBehaviour {

    private bool selfinit;

    public bool Initialized
    {
        get { return selfinit; }
    }
    Particle[] particles;
	//Enemy[] enemy;
	private GameObject hero;
    private heroScript hs;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero");
        hs = hero.GetComponent<heroScript>();
        Debug.Log("EventManager: Hero and their script found.");
        selfinit = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayParticle(Particle part){
	}

	bool AddParticle(Particle part){

        return false;
	}

	bool RemoveParticle(Particle part){

        return false;
	}

}
