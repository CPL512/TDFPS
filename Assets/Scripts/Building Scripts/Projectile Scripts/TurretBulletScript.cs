using UnityEngine;
using System.Collections;

/**
 * Handles turret bullet behavior
 */
public class TurretBulletScript : MonoBehaviour {

    public float speed; //speed of bullet
    public int damage; //damage of bullet
    public float rangeTime; //time to fly
    public float wallTop = 20f; //top of world

    float timer = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //move forward
        timer += Time.deltaTime;

        if (transform.position.y > wallTop) //top of world reached, destroy this
        {
            Destroy(this.gameObject);
        }

        if(timer > rangeTime) //end of range reached, destroy this
        {
            Destroy(this.gameObject);
        }

    }

    /**
     * Collision event
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")) //collide with environment, destroy this
        {
            Destroy(this.gameObject);
        }
    }

    /**
     * Gets the damage of this bullet
     */
    public int getDamage()
    {
        return damage;
    }
}
