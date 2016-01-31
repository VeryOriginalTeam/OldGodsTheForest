using UnityEngine;
using System.Collections;

public class lvlManager : MonoBehaviour {

	bool init = false;
	bool selfinit;
    public GameObject EventManager;
    public GameObject EnviromentManager;
    private evntManager evntManager;
    private envManager envManager;
    // Use this for initialization
    void Start () {

        evntManager = EventManager.GetComponent<evntManager>();
        envManager = EnviromentManager.GetComponent<envManager>();
		//When everything in this object is loaded selfinit is true
		selfinit = true;

        
        while (!envManager.Initialized)
        {
            Debug.Log("LevelManager: waiting for enviromentManager");
        }
        while(!evntManager.Initialized)
        {
            Debug.Log("LevelManager: waiting for eventManager");
        }
        
        //When other scripts have initialized themselves
        if (envManager.Initialized && evntManager.Initialized){
            Debug.Log("Managers are up, let's get this rolling");
			init = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
