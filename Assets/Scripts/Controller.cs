using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Controller : MonoBehaviour {

    TerminalScript buildTarget;
    PlayerShoot shootScript;
    PlayerMove moveScript;

    public static int wavesSurvived = 0;

    public string nextSceneName;

    public Text seedText;
    public Text nextWaveText;

    AntNode head;
    AntNode tail;

    public int seeds;

    public bool[] spawnerWaiting;
    bool waiting = true;

    int shootDmg;
    int shootSpd;

    int dmgUpCost = 5;
    int dmgCostIncrease = 5;
    int dmgUp = 5;
    int dmgUpIncrease = 1;
    int spdUpCost = 5;
    int spdCostIncrease = 5;
    float spdUp = .9f;
    float spdUpIncrease = .05f;

    public int T1Cost = 5;
    public int T2Cost = 10;
    public int T3Cost = 20;

    const int T1Ind = -1;
    const int T2Ind = 0;
    const int T3Ind = 1;

    // Use this for initialization
    void Start() {
        nextWaveText.enabled = true;

        head = gameObject.AddComponent<AntNode>();
        tail = gameObject.AddComponent<AntNode>();

        head.setNextAnt(tail);
        tail.setPrevAnt(head);

        shootScript = GameObject.FindGameObjectWithTag("Shooter").GetComponent<PlayerShoot>();
        moveScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update() {
        seedText.text = "Seeds: " + seeds;

        if(head.getNextAnt() != tail)
        {
            return;
        }

        if (!waiting)
        {
            for (int i = 0; i < spawnerWaiting.Length; i++)
            {
                if (!spawnerWaiting[i])
                {
                    return;
                }
            }

            wavesSurvived++;
            waiting = true;
            nextWaveText.enabled = true;
        }

        if(waiting && Input.GetKeyDown(KeyCode.N))
        {
            GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawn");
            for(int i = 0; i < spawners.Length; i++)
            {
                if(spawners[i].GetComponent<Spawner>().next())
                {
                    SceneManager.LoadScene(nextSceneName);
                }
            }
            for(int i = 0; i < spawnerWaiting.Length; i++)
            {
                spawnerWaiting[i] = false;
            }
            nextWaveText.enabled = false;
            waiting = false;
        }
    }

    public void setSpawnerDone(int ind)
    {
        spawnerWaiting[ind] = true;
    }

    public void lockPlayerInput(bool stop)
    {
        moveScript.lockInput(stop);
        shootScript.lockInput(stop);
    }

    public AntNode getFirstAnt()
    {
        if (head.getNextAnt() != tail)
        {
            return head.getNextAnt();
        }
        else
        {
            return null;
        }
    }

    public AntNode getTail()
    {
        return tail;
    }

    public void addAnt(AntNode ant)
    {
        tail.getPrevAnt().setNextAnt(ant);
        ant.setPrevAnt(tail.getPrevAnt());
        tail.setPrevAnt(ant);
        ant.setNextAnt(tail);
    }

    public void addSeeds(int toAdd)
    {
        seeds += toAdd;
    }

    public void setSeeds(int toSet)
    {
        seeds = toSet;
    }

    public int getSeeds()
    {
        return seeds;
    }

    public int getDamage()
    {
        return shootScript.getDamage();
    }

    public float getRate()
    {
        float unrounded = 1 / shootScript.getInterval();
        int rounded = (int)(unrounded * 100);
        return (float)rounded / 100;
    }

    public int getNextDamage()
    {
        return shootScript.getDamage() + dmgUp;
    }

    public float getNextRate()
    {
        float unrounded = 1 / (shootScript.getInterval() * spdUp);
        int rounded = (int)(unrounded * 100);
        return (float)rounded / 100;
    }

    public int getDmgUpCost()
    {
        return dmgUpCost;
    }

    public int getSpdUpCost()
    {
        return spdUpCost;
    }

    public bool upgradeDmg()
    {
        if(seeds < dmgUpCost)
        {
            return false;
        }

        seeds -= dmgUpCost;
        dmgUpCost += dmgCostIncrease;
        shootScript.upgradeDmg(dmgUp);
        dmgUp += dmgUpIncrease;
        return true;
    }

    public bool upgradeSpd()
    {
        if (seeds < spdUpCost)
        {
            return false;
        }

        seeds -= spdUpCost;
        spdUpCost += spdCostIncrease;
        shootScript.upgradeSpd(spdUp);
        spdUp -= spdUpIncrease;
        return true;
    }

    public void setBuildTarget(TerminalScript target)
    {
        buildTarget = target;
    }

    public TerminalScript getBuildTarget()
    {
        return buildTarget;
    }

    public int getTurretLevel()
    {
        return buildTarget.getTurretLevel();
    }

    public int getTeslaLevel()
    {
        return buildTarget.getTeslaLevel();
    }

    public int getGlueLevel()
    {
        return buildTarget.getGlueLevel();
    }

    public int getT1Cost()
    {
        return T1Cost;
    }

    public int getT2Cost()
    {
        return T2Cost;
    }

    public int getT3Cost()
    {
        return T3Cost;
    }

    public bool buildTurret()
    {
        int level = buildTarget.getTurretLevel();
        int cost = 0;
        switch(level)
        {
            case T1Ind:
                cost = T1Cost;
                break;
            case T2Ind:
                cost = T2Cost;
                break;
            case T3Ind:
                cost = T3Cost;
                break;
        }

        if (seeds >= cost)
        {
            buildTarget.buildTurret();
            seeds -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool buildTesla()
    {
        int level = buildTarget.getTeslaLevel();
        int cost = 0;
        switch (level)
        {
            case T1Ind:
                cost = T1Cost;
                break;
            case T2Ind:
                cost = T2Cost;
                break;
            case T3Ind:
                cost = T3Cost;
                break;
        }

        if (seeds >= cost)
        {
            buildTarget.buildTesla();
            seeds -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool buildGlue()
    {
        int level = buildTarget.getGlueLevel();
        int cost = 0;
        switch (level)
        {
            case T1Ind:
                cost = T1Cost;
                break;
            case T2Ind:
                cost = T2Cost;
                break;
            case T3Ind:
                cost = T3Cost;
                break;
        }

        if (seeds >= cost)
        {
            buildTarget.buildGlue();
            seeds -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void destroy()
    {
        buildTarget.destroy();
    }
}
