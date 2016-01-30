using UnityEngine;
using System.Collections;

public class heroAbilities : MonoBehaviour {

    protected bool doubleJump = false;
    protected bool shadowWalk = false;
    protected bool powerActive; //This is true if one of the powers is active

    private int shadowWalkTime = 5; //in seconds

    public Sprite NormalSprite,ShadowWalkSprite,DoubleJumpSprite;
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

            case "powerUp-SW":
                shadowWalk = true;
                break;

            default:
                Debug.Log("No powerup");
                break;
        }

    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="state">If true toggles the ability on, else toggles it off</param>
    public void ActivatePowerUp(bool state)
    {
        if (powerActive) state = false;
        else state = true;

        if (shadowWalk)
        {
            ShadowWalk(state);
        }
        if (doubleJump)
        {
            //TODO
        }
    }

    private void ShadowWalk(bool activated)
    {
        if(activated)
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false; //this isn't good enough
            gameObject.GetComponent<SpriteRenderer>().sprite = ShadowWalkSprite;
        }
        else
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = NormalSprite;

        }
    }
}
