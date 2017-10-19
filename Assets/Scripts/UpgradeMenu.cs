using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeMenu : MonoBehaviour {

    Controller control;

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

            if (timer >= warningTime)
            {
                insuffFundsText.enabled = false;
                timer = 0f;
                timing = false;
            }
        }
    }

    public void upgradeDmg()
    {
        if(!control.upgradeDmg())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    public void upgradeSpd()
    {
        if (!control.upgradeSpd())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

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
