using UnityEngine;
using System.Collections;

/**
 * Closes whatever Canvas this exit button is on
 */
public class ExitButton : MonoBehaviour {

    public Canvas menu; //the menu this button is on
    Controller control; //the controller

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))//escape also works to close
        {
            closeMenu();
        }
    }

    /**
     * Handles menu closing
     */
    public void closeMenu()
    {
        menu.enabled = false; //close menu
        control.lockPlayerInput(false); //menu is closed so unlock player input
        Cursor.visible = false;
    }
}
