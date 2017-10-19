using UnityEngine;
using System.Collections;

public class TeslaShockScript : MonoBehaviour {

    public int damage;
    public float duration = 0.2f;
    float timer = 0f;

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

    public int getDamage()
    {
        return damage;
    }
}
