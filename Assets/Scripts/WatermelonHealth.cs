using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handes watermelon health and game over condition
 */
public class WatermelonHealth : MonoBehaviour {

    public GameObject[] melons; //array of melons to iterate through
    private GameObject currMelon; //current melon to spawn
    private static int melonInd = 0; //index of current melon, static to persist through maps
    private float offset = 3.5f;

	// Use this for initialization
	void Start () {
        //spawn current melon
        currMelon = (GameObject) Instantiate(melons[melonInd], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Moves to next melon. Called by ant upon collision
     */
    public void nextMelon()
    {
        Destroy(currMelon.gameObject); //destroy the current melon
        melonInd++; //move to next melon state
        if(melonInd < melons.Length - 1) //more melon left, spawn the next one
        {
            currMelon = (GameObject) Instantiate(melons[melonInd], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
        }
        else //empty melon rind
        {
            currMelon = (GameObject) Instantiate(melons[melons.Length - 1], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
            SceneManager.LoadScene("GameOver");
        }
    }

    /**
     * Reset melon health. Called on new game
     */
    public static void resetMelon()
    {
        melonInd = 0;
    }
}
