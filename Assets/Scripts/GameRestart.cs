using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/**
 * Handles game over screen and starting a new game
 */
public class GameRestart : MonoBehaviour {

    const int WAVES_SCORE_FACTOR = 10;
    const int SEEDS_SCORE_FACTOR = 1;
    const int MELON_HEALTH_SCORE_FACTOR = 100;

    public Text finishMessageText; //text displaying the finishing message
    public Text infoText; //text displaying waves survived, seeds, and watermelon health
    public Text scoreText; //text displaying player's score

	// Use this for initialization
	void Start () {
        GameObject light = GameObject.FindGameObjectWithTag("Light");

        int waves = Controller.getWavesSurvived();
        int seeds = Controller.getSeeds();
        int health = WatermelonHealth.NUM_MELONS - 1 - WatermelonHealth.getMelonInd();

        infoText.text = "Waves Survived: " + waves + " Seeds: " + seeds + " Watermelon Health: " + health; //set text according to number of waves survived
        scoreText.text = "Score: " + ((WAVES_SCORE_FACTOR * waves) + (SEEDS_SCORE_FACTOR * seeds) + (MELON_HEALTH_SCORE_FACTOR * health));

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

        Cursor.visible = true;
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
