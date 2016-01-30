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

    public GameObject[] powerUps;
    public GameObject[] collectibles;

	// Use this for initialization
	void Start () {
        hero = GameObject.Find("Hero");
        hs = hero.GetComponent<heroScript>();
        Debug.Log("EventManager: Hero and their script found.");
        selfinit = true;

        //powerUps = GameObject.FindGameObjectsWithTag("powerUp");
        //No collectibles yet
        //collectibles = GameObject.FindGameObjectsWithTag("collectibles");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Cancel"))
		{
			Application.Quit();
		}
        
	}

	void PlayParticle(Particle part){
	}

	bool AddParticle(Particle part){

		return true;
	}

	bool RemoveParticle(Particle part){

        return false;
	}

    private void checkForPowerUps()
    {
        
    }
}
