using UnityEngine;
using System.Collections;

/**
 * Handles player shooting functionality
 */
public class PlayerShoot : MonoBehaviour {
    public GameObject bullet; //bullet prefab
    GameObject currBullet; //bulet just spawned
    public float interval = 1f; //interval between shots
    int damage = 10; //damage of bullets
    float timer; //timer of shots
    bool locked; //whether input is locked

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!locked) //only shoot if input not locked
        {
            timer += Time.deltaTime;
            if (Input.GetMouseButton(0) && timer >= interval) //only shoot when left mouse button is down
            {
                currBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation); //spawn a bullet
                currBullet.GetComponent<BulletScript>().setDamage(damage); //set its damage
                timer = 0;
            }
        }
	}

    /**
     * Gets player's bullet damage
     */
    public int getDamage()
    {
        return damage;
    }

    /**
     * Gets player's interval between shots
     */
    public float getInterval()
    {
        return interval;
    }

    /**
     * Increases damage by dmg
     */
    public void upgradeDmg(int dmg)
    {
        damage += dmg;
    }

    /**
     * Decreases interval by reduction, which is guaranteed to be less than 1
     */
    public void upgradeSpd(float reduction)
    {
        interval *= reduction;
    }

    /**
     * Sets whether shooting is locked or not
     */
    public void lockInput(bool stop)
    {
        locked = stop;
    }
}
