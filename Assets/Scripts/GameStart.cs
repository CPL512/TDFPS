using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handles game start screen and starting a game
 */
public class GameStart : MonoBehaviour {
    const int START_SEEDS = 10;

	// Use this for initialization
	void Start () {
        WatermelonHealth.resetMelon(); //reset melon health
        Controller.resetWavesSurvived(); //reset waves survived
        Controller.setSeeds(START_SEEDS); //reset seed count
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Start game buton pressed, start the game
     */
    public void startGame()
    {
        SceneManager.LoadScene("Map01"); //move to first map
    }
}
