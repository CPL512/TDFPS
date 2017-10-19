using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float speed = 50f;
    public float wallTop = 20f;

    int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if(transform.position.y > wallTop)
        {
            Destroy(this.gameObject);
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
    }

    public void setDamage(int dmg)
    {
        damage = dmg;
    }

    public int getDamage()
    {
        return damage;
    }
}
