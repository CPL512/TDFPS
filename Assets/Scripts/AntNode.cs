using UnityEngine;
using System.Collections;

/**
 * Node class used for the enemy list LinkedList. Assists LinkedList functionality
 */
public class AntNode : MonoBehaviour{

    AntNode nextAnt;
    AntNode prevAnt;
    public GameObject abdomen;

    /**
     * Gets ant next in line, ie ant behind this ant
     */
    public AntNode getNextAnt()
    {
        return nextAnt;
    }

    /**
     * Sets next ant in line
     */
    public void setNextAnt(AntNode toSet)
    {
        nextAnt = toSet;
    }

    /**
     * Get ant previous in line, ie ant in front of this ant
     */
    public AntNode getPrevAnt()
    {
        return prevAnt;
    }

    /**
     * Sets previous ant in line
     */
    public void setPrevAnt(AntNode toSet) 
    {
        prevAnt = toSet;
    }

    /**
     * Returns position at which turrets should aim
     */
    public Vector3 getCenterMass()
    {
        return abdomen.transform.position;
    }

    /**
     * Removes this ant from LinkedList, sets references, and adds to player's seeds
     */
    public void die(int seedsToAdd) 
    {
        nextAnt.setPrevAnt(prevAnt);
        prevAnt.setNextAnt(nextAnt);
        Destroy(this.gameObject);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>().addSeeds(seedsToAdd);
    }
}
