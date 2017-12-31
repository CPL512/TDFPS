using UnityEngine;
using System.Collections;

/**
 * Handles glue sheet behavior
 */
public class GlueSheetScript : MonoBehaviour {

    float timer;
    public float duration; //duration of glue sheet
    public float slowAmount; //amount to slow
    public float slowDuration; //amount of time to slow

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= duration) //duration reached destroy this
        {
            Destroy(this.gameObject);
        }
	}

    /**
     * Gets amount to slow down
     */
    public float getSlowAmount()
    {
        return slowAmount;
    }

    /**
     * Gets how long to slow down
     */
    public float getSlowDuration()
    {
        return slowDuration;
    }
}
