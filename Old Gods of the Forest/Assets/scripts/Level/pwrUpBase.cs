using UnityEngine;
using System.Collections;

public class pwrUpBase : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.tag == "player")
        {
            //let's hide this object
            gameObject.SetActive(false);
        }
    }
}
