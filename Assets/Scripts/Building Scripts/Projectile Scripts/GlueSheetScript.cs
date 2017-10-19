using UnityEngine;
using System.Collections;

public class GlueSheetScript : MonoBehaviour {

    float timer;
    public float duration;
    public float slowAmount;
    public float slowDuration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= duration)
        {
            Destroy(this.gameObject);
        }
	}

    public float getSlowAmount()
    {
        return slowAmount;
    }

    public float getSlowDuration()
    {
        return slowDuration;
    }
}
