using UnityEngine;
using System.Collections;

public class pwrUpBase : MonoBehaviour {

    bool pickedUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "player")
        {
            //let's hide this object
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameObject.GetComponent<Collider2D>().enabled = false;
            pickedUp = true;
        }
    }
}
