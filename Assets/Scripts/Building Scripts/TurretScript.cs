using UnityEngine;
using System.Collections;

/**
 * Handles laser turret behavior
 */
public class TurretScript : MonoBehaviour {

    Controller control;

    public GameObject[] spawnPoints; //array of points at which to spawn bullets
    public GameObject bullet; //bullet just spawned
    AntNode target; //target
    float yOffset = 3.65f;
    public float range = 40f; //maximum target range
    float timer = 0f;
    int currPoint = 0; //index of current spawn point

    public float interval;

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if(target == null && control.getFirstAnt() != control.getTail()) //no target and control has ants to target
        {
            target = control.getFirstAnt(); //get first ant
        }

        while(target != null && Vector3.Distance(transform.position, target.transform.position) > range) //loop until target in range is found or end of list reached
        {
            target = target.getNextAnt(); //move to next ant

            if(target == control.getTail()) //end of list reached
            {
                target = null; //set target to null
            }
        }

        if(target != null) //valid target is found
        {
            transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + yOffset, target.transform.position.z)); //face target

            if(timer >= interval)
            {
                Instantiate(bullet, spawnPoints[currPoint].transform.position, spawnPoints[currPoint].transform.rotation); //spawn bullet at current spawn point 
                currPoint++; //move to next spawn point
                if (currPoint == spawnPoints.Length) //last spawn point reached
                {
                    currPoint = 0; //move back to first spawn point
                }
                timer = 0;
            }
        }
	}
}
