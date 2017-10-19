using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {

    public Canvas menu;
    Controller control;

	// Use this for initialization
	void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.enabled = false;
            control.lockPlayerInput(false);
        }
    }

    public void closeMenu()
    {
        menu.enabled = false;
        control.lockPlayerInput(false);
    }
}
