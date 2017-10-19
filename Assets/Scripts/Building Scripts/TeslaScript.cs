using UnityEngine;
using System.Collections;

public class TeslaScript : MonoBehaviour {

    public GameObject shock;

    public float interval;
    float timer = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && timer >= interval)
        {
            Instantiate(shock, transform.position, transform.rotation);
            timer = 0f;
        }
    }
}
