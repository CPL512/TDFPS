using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handles game start screen and starting a game
 */
public class GameStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Start game buton pressed, start the game
     */
    public void startGame()
    {
        Controller.wavesSurvived = 0; //reset waves survived
        SceneManager.LoadScene("Map01"); //move to first map
    }
}
