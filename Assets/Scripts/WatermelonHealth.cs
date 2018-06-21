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
    public const int NUM_MELONS = 14;

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
        currMelon = (GameObject)Instantiate(melons[melonInd], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
        if (melonInd == melons.Length - 1) //empty melon rind just spawned, game over
        {
            SceneManager.LoadScene("GameFinish");

        }
    }

    public static int getMelonInd()
    {
        return melonInd;
    }

    /**
     * Reset melon health. Called on new game
     */
    public static void resetMelon()
    {
        melonInd = 0;
    }
}
