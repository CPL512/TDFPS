using UnityEngine;
using System.Collections;

public class AntNode : MonoBehaviour{

    AntNode nextAnt;
    AntNode prevAnt;

    public AntNode getNextAnt()
    {
        return nextAnt;
    }

    public void setNextAnt(AntNode toSet)
    {
        nextAnt = toSet;
    }

    public AntNode getPrevAnt()
    {
        return prevAnt;
    }

    public void setPrevAnt(AntNode toSet)
    {
        prevAnt = toSet;
    }

    public void die(int seedsToAdd)
    {
        nextAnt.setPrevAnt(prevAnt);
        prevAnt.setNextAnt(nextAnt);
        Destroy(this.gameObject);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Controller>().addSeeds(seedsToAdd);
    }
}
