using UnityEngine;
using System.Collections;

/**
 * Handles player interacting with build terminals and the menus
 */
public class PlayerInteract : MonoBehaviour {

    public Canvas buildMenu; //terminal build menu
    public Canvas upgradeMenu; //player upgrade menu
    Controller control;

    int layerMask = 1 << 8; //mask for raycast hits
    int interactDistance = 5;

	// Use this for initialization
	void Start () {
        buildMenu.enabled = false; //disable menus at start
        upgradeMenu.enabled = false;
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.forward); //create the forward vector in direction the player is facing

        RaycastHit hit;
        /* only when e is pressed, cast a ray forward for 5 meters that only detects items on the interact layer, which are all terminals */
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, forward, out hit, interactDistance, layerMask))
        {
            buildMenu.enabled = true; //enable build menu
            control.lockPlayerInput(true); //lock player movement and looking
            TerminalScript hitTarget = hit.transform.GetComponentInParent<TerminalScript>(); //set which terminal was interacted with
            control.setBuildTarget(hitTarget); //tell controller which terminal was hit
            buildMenu.GetComponent<BuildMenu>().updateMenu(); //update build menu
        }
        else if(Input.GetKeyDown(KeyCode.K)) //k press opens upgrade menu
        {
            upgradeMenu.enabled = true; //enable the menu
            control.lockPlayerInput(true); //lock player movement and looking
            upgradeMenu.GetComponent<UpgradeMenu>().updateMenu(); //update upgrade menu
        }
    }
}
