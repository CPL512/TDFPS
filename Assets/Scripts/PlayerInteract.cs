using UnityEngine;
using System.Collections;

public class PlayerInteract : MonoBehaviour {

    public Canvas buildMenu;
    public Canvas upgradeMenu;
    Controller control;

    int layerMask = 1 << 8;
    int interactDistance = 5;

	// Use this for initialization
	void Start () {
        buildMenu.enabled = false;
        upgradeMenu.enabled = false;
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, forward, out hit, interactDistance, layerMask))
        {
            buildMenu.enabled = true;
            control.lockPlayerInput(true);
            TerminalScript hitTarget = hit.transform.GetComponentInParent<TerminalScript>();
            control.setBuildTarget(hitTarget);
            buildMenu.GetComponent<BuildMenu>().updateMenu();
        }
        else if(Input.GetKeyDown(KeyCode.K))
        {
            upgradeMenu.enabled = true;
            control.lockPlayerInput(true);
            upgradeMenu.GetComponent<UpgradeMenu>().updateMenu();
        }
    }
}
