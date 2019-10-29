using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BuoysToPlace = 4;
    public int BuoysPlaced = 0;

    public string[] correctBuoyNames;
    public InteractiveMap_State physicalState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckPlacement(Buoy_Object calibratedBuoy)
    {

        //if the name of the buoy matches on the confirm button 
        //and the phyiscal buoy is in place
        if(calibratedBuoy.buoyInfo.name == correctBuoyNames[BuoysPlaced] && physicalState.BuoyData[BuoysPlaced] == true)
        {
            Debug.Log("Correctly placed buoy");
            calibratedBuoy.setStatus(true);
            BuoysPlaced += 1;

            if(BuoysPlaced >= BuoysToPlace)
            {
                //win state!!!
                Debug.Log("we did it!!!");
            }
        }
        else
        {
            Debug.Log("NOT placed correctly");
            calibratedBuoy.setStatus(false);
        }


    }





}
