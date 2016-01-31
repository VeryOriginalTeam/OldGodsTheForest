using UnityEngine;
using System.Collections;

public class pwrUpBase : MonoBehaviour {

    bool pickedUp;
    float respawnTimer = 20f;
    Sprite defaultSprite;
	// Use this for initialization
	void Start () {
        defaultSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        //Resspawn timer

        if (pickedUp)
        {

            respawnTimer -= Time.deltaTime;
            if (respawnTimer < 0)
            {
                pickedUp = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
            }
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Hero")
        {
            //let's hide this object
            gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameObject.GetComponent<Collider2D>().enabled = false;
            pickedUp = true;
        }
    }
}
