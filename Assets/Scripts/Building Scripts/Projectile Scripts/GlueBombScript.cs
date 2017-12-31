using UnityEngine;
using System.Collections;

/**
 * Handles glue bomb behavior
 */
public class GlueBombScript : MonoBehaviour {

    public GameObject glueSheet; //the glue sheet to spawn after this collides
    public float speed; //speed at which to fly
    public float rangeTime; //how long to fly
    public float wallTop; //top of world

    float timer = 0f;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //move forward
        timer += Time.deltaTime;

        if (transform.position.y > wallTop) //top of world reached, destroy this
        {
            Destroy(this.gameObject);
        }

        if (timer > rangeTime) //end of range reached, destroy this
        {
            Destroy(this.gameObject);
        }
    }

    /**
     * Collision event
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")) //hit wall, destroy this
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Enemy")) //hit enemy, spawn glue sheet, then destroy this
        {
            Instantiate(glueSheet, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
