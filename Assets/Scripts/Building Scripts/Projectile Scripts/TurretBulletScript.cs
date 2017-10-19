using UnityEngine;
using System.Collections;

public class TurretBulletScript : MonoBehaviour {

    public float speed;
    public int damage;
    public float rangeTime;
    public float wallTop = 20f;

    float timer = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (transform.position.y > wallTop)
        {
            Destroy(this.gameObject);
        }

        if(timer > rangeTime)
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

    public int getDamage()
    {
        return damage;
    }
}
