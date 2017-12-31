using UnityEngine;
using System.Collections;

/**
 * Handles player bullet functionality
 */
public class BulletScript : MonoBehaviour {

    public float speed = 50f; //speed of bullet
    public float wallTop = 20f; //top of world

    int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime); //move in direction

        if(transform.position.y > wallTop) //reached top of world, destroy this
        {
            Destroy(this.gameObject);
        }
	
	}

    /**
     * Collision event
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")) //destroy this when colliding with boundary
        {
            Destroy(this.gameObject);
        }

        //ant collisions handled by antMove
    }

    /**
     * Sets the damage of this bullet
     */
    public void setDamage(int dmg)
    {
        damage = dmg;
    }

    /**
     * Gets the damage of this bullet
     */
    public int getDamage()
    {
        return damage;
    }
}
