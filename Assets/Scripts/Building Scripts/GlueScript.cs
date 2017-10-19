using UnityEngine;
using System.Collections;

public class GlueScript : MonoBehaviour {

    Controller control;

    public GameObject spawnPoint;
    public GameObject gluebomb;
    AntNode target;
    float yOffset = 3.65f;
    public float range = 40f;
    float timer = 0f;
    public float interval;

    // Use this for initialization
    void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (target == null && control.getFirstAnt() != control.getTail())
        {
            target = control.getFirstAnt();
        }

        while (target != null && Vector3.Distance(transform.position, target.transform.position) > range)
        {
            target = target.getNextAnt();

            if (target == control.getTail())
            {
                target = null;
            }
        }

        if (target != null)
        {
            transform.LookAt(new Vector3(target.transform.position.x, target.transform.position.y + yOffset, target.transform.position.z));

            if (timer >= interval)
            {
                Instantiate(gluebomb, spawnPoint.transform.position, spawnPoint.transform.rotation);
                timer = 0;
            }
        }
    }
}
