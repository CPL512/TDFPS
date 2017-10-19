using UnityEngine;
using System.Collections;

public class TutorialSpawn : MonoBehaviour {

    Controller control;

    public GameObject ant;
    GameObject currAnt;
    public float interval = 3f;
    private float timer = 0f;
    private int spawnCount = 0;
    public int maxSpawn = 3;
    public bool spawning = true;

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (spawning)
        {
            timer += Time.deltaTime;
            if (timer >= interval && spawnCount < maxSpawn)
            {
                currAnt = (GameObject)Instantiate(ant, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                control.addAnt(currAnt.GetComponent<AntNode>());
                spawnCount++;
                timer = 0f;
            }
            else if(spawnCount == maxSpawn)
            {
                spawning = false;
            }
        }
	}
}
