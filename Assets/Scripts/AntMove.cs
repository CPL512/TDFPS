using UnityEngine;
using System.Collections;

public class AntMove : MonoBehaviour {
    
    private WatermelonHealth melonScript;

    public Transform[] pointList;

    public int currPoint = 0;
    Transform target;

    public float speed = 5f;
    public float health = 100f;

    bool glued = false;
    float slowAmount = 0f;
    float slowDuration;
    float gluedSpeed;
    float glueTimer = 0f;

    public int value;

    private bool isColliding = false;

	// Use this for initialization
	void Start () {
        melonScript = GameObject.FindGameObjectWithTag("Finish").GetComponent<WatermelonHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        isColliding = false;

        if(glued)
        {
            glueTimer += Time.deltaTime;
            if(glueTimer >= slowDuration)
            {
                glued = false;
                glueTimer = 0f;
            }
        }

        if(currPoint < pointList.Length)
        {
            if(target == null)
            {
                target = pointList[currPoint];
            }
            walk();
        }
	
	}

    void walk()
    {
        transform.LookAt(target);
        if (glued)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, gluedSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(transform.position == target.position)
        {
            currPoint++;
            target = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TurretBullet"))
        {
            health -= other.GetComponentInParent<TurretBulletScript>().getDamage();
            Debug.Log("hit by turret bullet");
            Destroy(other.gameObject);
            if (health <= 0)
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            health -= other.GetComponentInParent<BulletScript>().getDamage();
            Destroy(other.gameObject);
            if (health <= 0)
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if (other.gameObject.CompareTag("TeslaShock"))
        {
            health -= other.GetComponentInParent<TeslaShockScript>().getDamage();
            if (health <= 0)
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if(other.gameObject.CompareTag("GlueSheet"))
        {
            glued = true;
            if (other.GetComponent<GlueSheetScript>().getSlowAmount() > slowAmount)
            {
                glueTimer = 0f;
                slowAmount = other.GetComponent<GlueSheetScript>().getSlowAmount();
                slowDuration = other.GetComponent<GlueSheetScript>().getSlowDuration();
                gluedSpeed = speed * slowAmount;
            }
        }
        if (other.gameObject.CompareTag("Finish") && !isColliding)
        {
            isColliding = true;
            GetComponentInParent<AntNode>().die(0);
            melonScript.nextMelon();
        }
    }
}
