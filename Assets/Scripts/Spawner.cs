using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Spawns ants
 */
public class Spawner : MonoBehaviour {

    Controller control;
    public int arrInd; //index of this spawner in controller's boolean array

    GameObject currAnt; //ant most recently spawned
    public float interval = 3f; //interval between spawns
    private float timer = 0f;
    public GameObject[] toSpawn; //array of ants to spawn, each index is a wave
    public int[] numToSpawn; //number to spawn of each ant in toSpawn
    public bool spawning = false; //whether this spawner is spawning
    public int wave = -1; //current wave/index in arrays, start before first
    private int antNum = 0; //number of ants spawned this wave

    public GameObject path;
    GameObject pathInstance;

    // Use this for initialization
    void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
	}
	
	// Update is called once per frame
	void Update () {
        if (spawning) //only do things when spawning
        {
            timer += Time.deltaTime;
            if (timer >= interval && antNum < numToSpawn[wave]) //interval time has passed and ants to spawn remain
            {
                //spawn ant
                currAnt = (GameObject)Instantiate(toSpawn[wave], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                control.addAnt(currAnt.GetComponent<AntNode>()); //add ant to LinkedList of ants
                antNum++;
                timer = 0f;
            }
            else if (antNum == numToSpawn[wave]) //spawned all the ants to spawn this wave
            {
                spawning = false; //spawning done
                control.setSpawnerDone(arrInd); //set bool at arrInd in control's array to true
            }
        }
    }

    /**
     * Attempts to move to next wave. Returns false when there are waves left, true when need to move to next map
     */
    public bool next()
    {
        if (wave < toSpawn.Length - 1) //not last wave yet
        {
            wave++; //advance wave
            antNum = 0; //reset num ants spawned
            spawning = true; //start spawning
            return false;
        }

        return true; //last wave just finished, return true to indicate move to next map
    }

    /**
     * Spawns or destroys path indicator depending on if this spawner is active next wave
     */
    public void updatePath()
    {
        if(wave < toSpawn.Length - 1 && numToSpawn[wave + 1] > 0)
        {
            if (pathInstance == null)
            {
                pathInstance = (GameObject)Instantiate(path, new Vector3(0, 0, 0), Quaternion.identity);
            }
        }
        else
        {
            Destroy(pathInstance);
        }
    }
}
