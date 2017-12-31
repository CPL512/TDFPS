using UnityEngine;
using System.Collections;

/**
 * Handles tesla coil behavior
 */
public class TeslaScript : MonoBehaviour {

    public GameObject shock; //the shock to spawn

    public float interval;
    float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    /**
     * Collsion event
     */
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && timer >= interval) //ant entered range and timer reached interval
        {
            Instantiate(shock, transform.position, transform.rotation); //spawn the shock
            timer = 0f;
        }
    }
}
