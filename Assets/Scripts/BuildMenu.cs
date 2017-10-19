using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BuildMenu : MonoBehaviour
{
    Controller control;

    public Text insuffFundsText;
    public Text glueCostText;
    public Text teslaCostText;
    public Text turretCostText;

    public Button glueButton;
    public Button teslaButton;
    public Button turretButton;

    public Image glueImg;
    public Image teslaImg;
    public Image turretImg;

    public Sprite[] glueSprites;
    public Sprite[] teslaSprites;
    public Sprite[] turretSprites;

    const int preT1Ind = -1;
    const int preT2Ind = 0;
    const int preT3Ind = 1;

    float warningTime = 0.75f;
    bool timing = false;
    float timer = 0f;

    void Start()
    {
        control = GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>();
        insuffFundsText.enabled = false;
    }

    void Update()
    {
        if(timing)
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

    public void glueButtonPress()
    {
        if(!control.buildGlue())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    public void teslaButtonPress()
    {
        if(!control.buildTesla())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    public void turretButtonPress()
    {
        if(!control.buildTurret())
        {
            insuffFundsText.enabled = true;
            timing = true;
        }

        updateMenu();
    }

    public void destroyButtonPress()
    {
        control.destroy();

        updateMenu();
    }

    public void updateMenu()
    {
        int glueInd = control.getGlueLevel();
        if(glueInd < glueSprites.Length - 1)
        {
            glueImg.sprite = glueSprites[glueInd + 1];
            switch(glueInd)
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
        else if(glueInd == glueSprites.Length - 1)
        {
            glueImg.sprite = glueSprites[glueInd];
            glueButton.interactable = false;
            glueCostText.text = "";
        }

        int teslaInd = control.getTeslaLevel();
        if (teslaInd < teslaSprites.Length - 1)
        {
            teslaImg.sprite = teslaSprites[teslaInd + 1];
            switch (teslaInd)
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
        else if (teslaInd == teslaSprites.Length - 1)
        {
            teslaImg.sprite = teslaSprites[teslaInd];
            teslaButton.interactable = false;
            teslaCostText.text = "";
        }

        int turretInd = control.getTurretLevel();
        if (turretInd < turretSprites.Length - 1)
        {
            turretImg.sprite = turretSprites[turretInd + 1];
            switch (turretInd)
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
        else if (turretInd == turretSprites.Length - 1)
        {
            turretImg.sprite = turretSprites[turretInd];
            turretButton.interactable = false;
            turretCostText.text = "";
        }

        if(glueInd > -1)
        {
            teslaButton.interactable = false;
            turretButton.interactable = false;

            if(glueInd < glueSprites.Length - 1)
            {
                glueButton.interactable = true;
            }
        }
        else if(teslaInd > -1)
        {
            glueButton.interactable = false;
            turretButton.interactable = false;

            if (teslaInd < teslaSprites.Length - 1)
            {
                teslaButton.interactable = true;
            }
        }
        else if(turretInd > -1)
        {
            glueButton.interactable = false;
            teslaButton.interactable = false;

            if (turretInd < turretSprites.Length - 1)
            {
                turretButton.interactable = true;
            }
        }
        else
        {
            glueButton.interactable = true;
            teslaButton.interactable = true;
            turretButton.interactable = true;
        }
    }
}
