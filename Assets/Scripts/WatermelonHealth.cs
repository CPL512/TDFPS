using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WatermelonHealth : MonoBehaviour {

    public GameObject[] melons;
    private GameObject currMelon;
    private int melonInd = 0;
    private float offset = 3.5f;

	// Use this for initialization
	void Start () {
        currMelon = (GameObject) Instantiate(melons[melonInd], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void nextMelon()
    {
        Destroy(currMelon.gameObject);
        melonInd++; //move to next melon state
        if(melonInd < melons.Length - 1) //more melon left
        {
            currMelon = (GameObject) Instantiate(melons[melonInd], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
        }
        else //empty melon rind
        {
            currMelon = (GameObject) Instantiate(melons[melons.Length - 1], new Vector3(transform.position.x, transform.position.y + offset, transform.position.z), Quaternion.identity);
            /* TODO  game over */
            SceneManager.LoadScene("GameOver");
        }
    }
}
