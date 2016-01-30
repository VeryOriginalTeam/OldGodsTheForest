using UnityEngine;
using System.Collections;

public class heroAbilities : MonoBehaviour {

    protected bool doubleJump = false;
    protected bool shadowWalk = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "powerUp-DJ":
                doubleJump = true;
                break;
        }
    }
}
