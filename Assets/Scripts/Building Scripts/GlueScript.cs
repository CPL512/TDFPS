using UnityEngine;
using System.Collections;

/**
 * Handles glue launcher behavior
 */
public class GlueScript : MonoBehaviour {

    Controller control;

    public GameObject spawnPoint; //point at which to spawn glue bombs
    public GameObject gluebomb; //the glue bomb to spawn
    AntNode target; //current target
    public float range = 40f; //maximum range of this launcher
    float timer = 0f;
    public float interval;

    // Use this for initialization
    void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (target == null && control.getFirstAnt() != control.getTail()) //no target and control has ants to target
        {
            target = control.getFirstAnt(); //get first ant
        }

        while (target != null && Vector3.Distance(transform.position, target.transform.position) > range) //loop until a target in range is found or end of list reached
        {
            target = target.getNextAnt(); //move to next ant

            if (target == control.getTail()) //reached end of list
            {
                target = null; //set target to null
            }
        }

        if (target != null) //have a valid target
        {
            transform.LookAt(target.getCenterMass()); //look at target

            if (timer >= interval)
            {
                Instantiate(gluebomb, spawnPoint.transform.position, spawnPoint.transform.rotation); //spawn a glue bomb
                timer = 0;
            }
        }
    }
}
