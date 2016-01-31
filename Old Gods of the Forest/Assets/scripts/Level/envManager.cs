using UnityEngine;
using System.Collections;

public class envManager : MonoBehaviour {

    private bool selfinit;

    public bool Initialized
    {
        get { return selfinit; }
    }

    // Use this for initialization
    void Start () {
        
        selfinit = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
