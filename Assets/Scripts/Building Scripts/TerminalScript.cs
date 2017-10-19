using UnityEngine;
using System.Collections;

public class TerminalScript : MonoBehaviour {

    public GameObject buildPoint;
    private GameObject building;

    int turretLevel = -1;
    int teslaLevel = -1;
    int glueLevel = -1;

    public GameObject[] turrets;
    public GameObject[] teslas;
    public GameObject[] glues;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getTurretLevel()
    {
        return turretLevel;
    }

    public int getTeslaLevel()
    {
        return teslaLevel;
    }

    public int getGlueLevel()
    {
        return glueLevel;
    }

    public void buildTurret()
    {
        if(building != null)
        {
            Destroy(building.gameObject);
        }

        turretLevel++;
        building = (GameObject)Instantiate(turrets[turretLevel], buildPoint.transform.position, Quaternion.identity);
    }

    public void buildTesla()
    {
        if (building != null)
        {
            Destroy(building.gameObject);
        }

        teslaLevel++;
        building = (GameObject)Instantiate(teslas[teslaLevel], buildPoint.transform.position, Quaternion.identity);
    }

    public void buildGlue()
    {
        if (building != null)
        {
            Destroy(building.gameObject);
        }

        glueLevel++;
        building = (GameObject)Instantiate(glues[glueLevel], buildPoint.transform.position, Quaternion.identity);
    }

    public void destroy()
    {
        if (building != null)
        {
            Destroy(building.gameObject);
        }
        turretLevel = -1;
        teslaLevel = -1;
        glueLevel = -1;
    }
}
