using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public GameObject bullet;
    GameObject currBullet;
    public float interval = 1f;
    int damage = 10;
    float timer;
    bool locked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!locked)
        {
            timer += Time.deltaTime;
            if (Input.GetMouseButton(0) && timer >= interval)
            {
                currBullet = (GameObject)Instantiate(bullet, transform.position, transform.rotation);
                currBullet.GetComponent<BulletScript>().setDamage(damage);
                timer = 0;
            }
        }
	}

    public int getDamage()
    {
        return damage;
    }

    public float getInterval()
    {
        return interval;
    }

    public void upgradeDmg(int dmg)
    {
        damage += dmg;
    }

    public void upgradeSpd(float reduction)
    {
        interval *= reduction;
    }

    public void lockInput(bool stop)
    {
        locked = stop;
    }
}
