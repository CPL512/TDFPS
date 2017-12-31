using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Handles upgrade menu functionality
 */
public class UpgradeMenu : MonoBehaviour {

    Controller control;

    /* All the texts on the menu */
    public Text insuffFundsText;
    public Text currDmgText;
    public Text currSpdText;
    public Text dmgCostText;
    public Text spdCostText;
    public Text nextDmgText;
    public Text nextSpdText;

    float warningTime = 0.75f;
    bool timing = false;
    float timer = 0f;

    // Use this for initialization
    void Start () {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        insuffFundsText.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (timing)
        {
            timer += Time.deltaTime;

            if (timer >= warningTime) //insuffFundsText duration reached
            {
                insuffFundsText.enabled = false; //disable it
                timer = 0f;
                timing = false;
            }
        }
    }

    /**
     * Upgrade player's damage
     */
    public void upgradeDmg()
    {
        if(!control.upgradeDmg()) //let control upgrade the damage, false if not enough seeds
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    /**
     * Upgrade player's shoot speed
     */
    public void upgradeSpd()
    {
        if (!control.upgradeSpd()) //let control upgrade the speed, false if not enoughs seeds
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    /**
     * Update all the texts on the menu
     */
    public void updateMenu()
    {
        currDmgText.text = "Dmg: " + control.getDamage();
        currSpdText.text = "Spd: " + control.getRate() + "/sec";
        dmgCostText.text = "Cost: " + control.getDmgUpCost();
        spdCostText.text = "Cost: " + control.getSpdUpCost();
        nextDmgText.text = "Next: " + control.getNextDamage();
        nextSpdText.text = "Next: " + control.getNextRate() + "/sec";
    }
}
