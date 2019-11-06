using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public int BuoysToPlace = 4;
    public int BuoysPlaced = 0;

    public string[] correctBuoyNames;
    public InteractiveMap_State physicalState;

    private Buoy_TextController currentDisplay;

    public TextMesh calibrationFeedback;
    public TextMesh calibrationFeedback_Map;

    public UnityEvent[] placementEvents;

    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = FindObjectOfType<Buoy_TextController>();


        calibrationFeedback_Map.color = Color.red;
        calibrationFeedback_Map.text = "Calibrate Buoy: " + correctBuoyNames[BuoysPlaced];
    }


    public void CalibrationClicked()
    {
        CheckPlacement(currentDisplay.selectedBuoy);
    }

    public void CheckPlacement(Buoy_Object calibratedBuoy)
    {
        //if we haven't already completed the calibrations
        if (BuoysPlaced < BuoysToPlace)
        {
            if (calibratedBuoy.Status == true)
            {
                //feedback
                calibrationFeedback.color = Color.cyan;
                calibrationFeedback.text = "Already Calibrated!";
                StartCoroutine(feedbackTimer());
            }

            //if the name of the buoy matches on the confirm button 
            //and the phyiscal buoy is in place
            else if (calibratedBuoy.buoyInfo.name == correctBuoyNames[BuoysPlaced] && physicalState.BuoyData[BuoysPlaced] == true)
            {
                Debug.Log("Correctly placed buoy");
                calibratedBuoy.setStatus(true);

                placementEvents[BuoysPlaced].Invoke();

                BuoysPlaced += 1;

                if (BuoysPlaced >= BuoysToPlace)
                {
                    //win state!!!
                    Debug.Log("we did it!!!");

                    calibrationFeedback.color = Color.cyan;
                    calibrationFeedback.text = "Calibration     Complete!";

                    calibrationFeedback_Map.color = Color.cyan;
                    calibrationFeedback_Map.text = "Calibration Complete!";
                }
                else
                {
                   

                    //feedback
                    calibrationFeedback.color = Color.green;
                    calibrationFeedback.text = "Successful     Calibration!";

                    calibrationFeedback_Map.color = Color.green;
                    calibrationFeedback_Map.text = "Successful Calibration!";

                    StartCoroutine(feedbackTimer());
                }
            }

            //not correctly placed
            else
            {
                //feedback
                calibrationFeedback.color = Color.red;
                calibrationFeedback.text = "Failed     Calibration!";

                calibrationFeedback_Map.color = Color.red;
                calibrationFeedback_Map.text = "Failed Calibration!";

                StartCoroutine(feedbackTimer());

                Debug.Log("NOT placed correctly");
                calibratedBuoy.setStatus(false);
            }

        }
    }

        IEnumerator feedbackTimer()
        {
            yield return new WaitForSeconds(2f);

            calibrationFeedback.text = "";

            calibrationFeedback_Map.color = Color.red;
            calibrationFeedback_Map.text = "Locate Buoy: " + correctBuoyNames[BuoysPlaced];

        }


}
