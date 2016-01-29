using UnityEngine;
using System.Collections;

public class lvlManager : MonoBehaviour {

	bool init = false;
	bool selfinit;
	public bool eventManagerLoaded;
	public bool enviromentManagerLoaded;

	// Use this for initialization
	void Start () {
	
		//When everything in this object is loaded selfinit is true
		selfinit = true;
		//When other scripts have initialized themselves
		if(eventManagerLoaded && enviromentManagerLoaded){
			init = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
