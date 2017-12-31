using UnityEngine;
using System.Collections;

/**
 * Handles movement of ants. Moves ants along path of GameObjects designated in editor
 */
public class AntMove : MonoBehaviour {
    
    private WatermelonHealth melonScript; //the script handling melon health

    public Transform[] pointList; //the path of Transforms

    public int currPoint = 0; //tracks index of current target
    Transform target; //current target

    public float speed = 5f; //speed of ant's movement
    public float health = 100f; //ant's health

    bool glued = false; //vars pertaining to glue
    float slowAmount = 0f;
    float slowDuration;
    float gluedSpeed;
    float glueTimer = 0f;

    public int value; //amount of seeds awarded for killing this ant

    private bool isColliding = false; //makes sure ant doesn't collide with watermelon twice

	// Use this for initialization
	void Start () {
        melonScript = GameObject.FindGameObjectWithTag("Finish").GetComponent<WatermelonHealth>();
    }
	
	// Update is called once per frame
	void Update () {
        isColliding = false;

        if(glued) //when glued duration is over, unglue
        {
            glueTimer += Time.deltaTime;
            if(glueTimer >= slowDuration) //duration over
            {
                glued = false;
                glueTimer = 0f;
            }
        }

        if(currPoint < pointList.Length) //haven't reached end of pointList
        {
            if(target == null)
            {
                target = pointList[currPoint];
            }
            walk();
        }
	
	}

    /**
     * Makes the ant walk by turning to look at target then moving the transform towards target
     */
    void walk()
    {
        transform.LookAt(target); //look at movement direction
        if (glued) //move at glued speed
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, gluedSpeed * Time.deltaTime);
        }
        else //move at normal speed
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if(transform.position == target.position) //if target reached after movement, move to next target
        {
            currPoint++;
            target = null;
        }
    }

    /**
     * Collision event
     */
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TurretBullet")) //hit by turret bullet
        {
            health -= other.GetComponentInParent<TurretBulletScript>().getDamage(); //get turret's damage
            Destroy(other.gameObject); //destroy the bullet
            if (health <= 0) //die when health reaches 0
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if (other.gameObject.CompareTag("PlayerBullet")) //hit by player bullet
        {
            health -= other.GetComponentInParent<BulletScript>().getDamage();
            Destroy(other.gameObject);
            if (health <= 0)
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if (other.gameObject.CompareTag("TeslaShock")) //hit by tesla shock
        {
            health -= other.GetComponentInParent<TeslaShockScript>().getDamage();
            if (health <= 0)
            {
                GetComponentInParent<AntNode>().die(value);
            }
        }
        if(other.gameObject.CompareTag("GlueSheet")) //hit by glue
        {
            glued = true;
            if (other.GetComponent<GlueSheetScript>().getSlowAmount() > slowAmount) //only change when hit by a stronger glue
            {
                glueTimer = 0f;
                slowAmount = other.GetComponent<GlueSheetScript>().getSlowAmount();
                slowDuration = other.GetComponent<GlueSheetScript>().getSlowDuration();
                gluedSpeed = speed * slowAmount;
            }
        }
        if (other.gameObject.CompareTag("Finish") && !isColliding) //hit watermelon
        {
            isColliding = true;
            GetComponentInParent<AntNode>().die(0);
            melonScript.nextMelon();
        }
    }
}
