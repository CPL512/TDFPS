using UnityEngine;
using System.Collections;

/**
 * Handles tesla shock behavior
 */
public class TeslaShockScript : MonoBehaviour {

    public int damage; //damage of this shock
    public float duration = 0.2f; //duration of this shock
    float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= duration) //duration reached
        {
            Destroy(this.gameObject); //destroy this
        }
	}

    /**
     * Get damage of this shock
     */
    public int getDamage()
    {
        return damage;
    }
}
