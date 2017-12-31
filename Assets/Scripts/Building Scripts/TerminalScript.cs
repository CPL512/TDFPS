using UnityEngine;
using System.Collections;

/**
 * Handles building terminal functionality
 */
public class TerminalScript : MonoBehaviour {

    public GameObject buildPoint; //point at which to build
    private GameObject building; //the current building

    /* level of each building */
    int turretLevel = -1;
    int teslaLevel = -1;
    int glueLevel = -1;

    /* array of buildings to create */
    public GameObject[] turrets;
    public GameObject[] teslas;
    public GameObject[] glues;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /**
     * Get current turret level
     */
    public int getTurretLevel()
    {
        return turretLevel;
    }

    /**
     * Get current tesla level
     */
    public int getTeslaLevel()
    {
        return teslaLevel;
    }

    /**
     * Get current glue level
     */
    public int getGlueLevel()
    {
        return glueLevel;
    }

    /**
     * Build the next level of turret
     */
    public void buildTurret()
    {
        if(building != null) //a building already there, destroy it
        {
            Destroy(building.gameObject);
        }

        turretLevel++; //move to next turret
        building = (GameObject)Instantiate(turrets[turretLevel], buildPoint.transform.position, Quaternion.identity); //spawn the next turret
    }

    /**
     * Build the next level of tesla
     */
    public void buildTesla()
    {
        if (building != null) //a building already there, destroy it
        {
            Destroy(building.gameObject);
        }

        teslaLevel++; //move to next tesla
        building = (GameObject)Instantiate(teslas[teslaLevel], buildPoint.transform.position, Quaternion.identity); //spawn the next tesla
    }

    /**
     * Build the next level of glue
     */
    public void buildGlue()
    {
        if (building != null) //a building already there, destroy it
        {
            Destroy(building.gameObject);
        }

        glueLevel++; //move to next glue
        building = (GameObject)Instantiate(glues[glueLevel], buildPoint.transform.position, Quaternion.identity); //spawn the next glue
    }

    /**
     * Destroy the current building
     */
    public void destroy()
    {
        if (building != null) //only destroy if there is a building
        {
            Destroy(building.gameObject);
        }

        /* reset building levels */
        turretLevel = -1;
        teslaLevel = -1;
        glueLevel = -1;
    }
}
