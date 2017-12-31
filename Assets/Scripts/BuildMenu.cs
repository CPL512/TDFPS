using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/**
 * Manages the builiding menu functionality
 */
public class BuildMenu : MonoBehaviour
{
    Controller control; //controller stores which terminal was targetted

    /* Texts on the build menu */
    public Text insuffFundsText;
    public Text glueCostText;
    public Text teslaCostText;
    public Text turretCostText;

    /* Buttons on the build menu */
    public Button glueButton;
    public Button teslaButton;
    public Button turretButton;

    /* Images on the build menu */
    public Image glueImg;
    public Image teslaImg;
    public Image turretImg;

    /* Arrays of building sprites to put on the menu */
    public Sprite[] glueSprites;
    public Sprite[] teslaSprites;
    public Sprite[] turretSprites;

    /* Indices of which sprite to load */
    const int preT1Ind = -1;
    const int preT2Ind = 0;
    const int preT3Ind = 1;

    /* Systems values */
    float warningTime = 0.75f;
    bool timing = false;
    float timer = 0f;

    // Use this for initialization
    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        insuffFundsText.enabled = false;
    }

    //Update is called once per frame
    void Update()
    {
        if(timing) //insuffFundsText should only be enabled for a little bit
        {
            timer += Time.deltaTime;

            if(timer >= warningTime)
            {
                insuffFundsText.enabled = false;
                timer = 0f;
                timing = false;
            }
        }
    }

    /**
     * On glue button press, call function
     */
    public void glueButtonPress()
    {
        if(!control.buildGlue()) //not enough seeds
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    /**
     * On tesla button press, call function
     */
    public void teslaButtonPress()
    {
        if(!control.buildTesla())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    /**
     * On turret button press, call function
     */
    public void turretButtonPress()
    {
        if(!control.buildTurret())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    /**
     * On destroy button press, destroy the build target
     */
    public void destroyButtonPress()
    {
        control.destroy();

        updateMenu();
    }

    /**
     * Updates all sprites, texts, and buttons on the menu
     */
    public void updateMenu()
    {
        int glueInd = control.getGlueLevel(); //check level of glue at build target
        if(glueInd < glueSprites.Length - 1) //not last level yet
        {
            glueImg.sprite = glueSprites[glueInd + 1]; //move to next sprite
            switch(glueInd) //change glue cost text according to cost of next level
            {
                case preT1Ind:
                    glueCostText.text = "Cost: " + control.getT1Cost();
                    break;
                case preT2Ind:
                    glueCostText.text = "Cost: " + control.getT2Cost();
                    break;
                case preT3Ind:
                    glueCostText.text = "Cost: " + control.getT3Cost();
                    break;
            }
        }
        else if(glueInd == glueSprites.Length - 1) //reached last level
        {
            glueImg.sprite = glueSprites[glueInd]; //stay on last sprite
            glueButton.interactable = false; //disable button
            glueCostText.text = ""; //make cost text empty
        }

        int teslaInd = control.getTeslaLevel(); //check level of tesla at build target
        if (teslaInd < teslaSprites.Length - 1) //not last level yet
        {
            teslaImg.sprite = teslaSprites[teslaInd + 1]; //move to next sprite
            switch (teslaInd) //change tesla cost text according to cost of next level
            {
                case preT1Ind:
                    teslaCostText.text = "Cost: " + control.getT1Cost();
                    break;
                case preT2Ind:
                    teslaCostText.text = "Cost: " + control.getT2Cost();
                    break;
                case preT3Ind:
                    teslaCostText.text = "Cost: " + control.getT3Cost();
                    break;
            }
        }
        else if (teslaInd == teslaSprites.Length - 1) //reached last level
        {
            teslaImg.sprite = teslaSprites[teslaInd]; //stay on last sprite
            teslaButton.interactable = false; //disable button
            teslaCostText.text = ""; //make cost text empty
        }

        int turretInd = control.getTurretLevel(); //check level of turret at build target
        if (turretInd < turretSprites.Length - 1) //not last level yet
        {
            turretImg.sprite = turretSprites[turretInd + 1]; //move to next sprite
            switch (turretInd) //change turret cost text according to cost of next level
            {
                case preT1Ind:
                    turretCostText.text = "Cost: " + control.getT1Cost();
                    break;
                case preT2Ind:
                    turretCostText.text = "Cost: " + control.getT2Cost();
                    break;
                case preT3Ind:
                    turretCostText.text = "Cost: " + control.getT3Cost();
                    break;
            }
        }
        else if (turretInd == turretSprites.Length - 1) //reached last level
        {
            turretImg.sprite = turretSprites[turretInd]; //stay on last sprite
            turretButton.interactable = false; //disable button
            turretCostText.text = ""; //make cost text empty
        }

        if(glueInd > -1) //glue launcher is currently built
        {
            teslaButton.interactable = false; //disable tesla and turret buttons
            turretButton.interactable = false;

            if(glueInd < glueSprites.Length - 1) //not last glue, enable glue button
            {
                glueButton.interactable = true;
            }
        }
        else if(teslaInd > -1) //tesla coil is currently built
        {
            glueButton.interactable = false; //disable glue and turret buttons
            turretButton.interactable = false;

            if (teslaInd < teslaSprites.Length - 1) //not last tesla, enable tesla button
            {
                teslaButton.interactable = true;
            }
        }
        else if(turretInd > -1) //laser turret is currently built
        {
            glueButton.interactable = false; //disable glue and tesla buttons
            teslaButton.interactable = false;

            if (turretInd < turretSprites.Length - 1) //not last turret, enable turret button
            {
                turretButton.interactable = true;
            }
        }
        else //nothing built, enable all buttons
        {
            glueButton.interactable = true;
            teslaButton.interactable = true;
            turretButton.interactable = true;
        }
    }
}
