using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handles game over screen and starting a new game
 */
public class GameRestart : MonoBehaviour {

    public Text finishMessageText; //text displaying the finishing message
    public Text wavesSurvivedText; //text displaying number of waves survived

	// Use this for initialization
	void Start () {
        GameObject light = GameObject.FindGameObjectWithTag("Light");

        wavesSurvivedText.text = "Waves Survived: " + Controller.wavesSurvived; //set text according to number of waves survived

        if(WatermelonHealth.getMelonInd() == WatermelonHealth.NUM_MELONS - 1)
        {
            finishMessageText.text = "Game Over";
            light.transform.Rotate(new Vector3(30, 0, 0));
        }
        else
        {
            finishMessageText.text = "You Win!";
            light.transform.Rotate(new Vector3(-40, 0, 0));
        }
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
