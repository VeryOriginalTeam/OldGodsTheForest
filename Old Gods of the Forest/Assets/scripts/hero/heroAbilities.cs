using UnityEngine;
using System.Collections;

public class heroAbilities : MonoBehaviour {

    protected bool doubleJump = false;
    protected bool shadowWalk = false;
    protected bool extraDmg = false;
    protected bool powerActive; //This is true if one of the powers is active

    private float shadowWalkTime = 5f; //in seconds

    private float abilityTimer; //this receives value from specific ability's time

    public Sprite NormalSprite,ShadowWalkSprite,DoubleJumpSprite;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixedUpdate()
    {
        //Ability timer
        
        if (powerActive)
        {
            
            abilityTimer -= Time.deltaTime;
            if (abilityTimer < 0)
            {
                powerActive = false;
            }
        }
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

            case "powerUp-DMG":
                extraDmg = true;
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
            abilityTimer = shadowWalkTime;
            gameObject.GetComponent<PolygonCollider2D>().enabled = false; //this isn't good enough
            gameObject.GetComponent<SpriteRenderer>().sprite = ShadowWalkSprite;
        }
        else
        {
            abilityTimer = 0f;
            gameObject.GetComponent<PolygonCollider2D>().enabled = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = NormalSprite;

        }
    }
}
