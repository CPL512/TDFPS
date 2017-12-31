using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handles game over screen and starting a new game
 */
public class GameRestart : MonoBehaviour {

    public Text wavesSurvivedText; //text displaying number of waves survived

	// Use this for initialization
	void Start () {
        wavesSurvivedText.text = "Waves Survived: " + Controller.wavesSurvived; //set text according to number of waves survived
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * New game button pressed, start a new game
     */
    public void newGame()
    {
        WatermelonHealth.resetMelon(); //reset the melon
        SceneManager.LoadScene("Start"); //go back to the start screen
    }
}
