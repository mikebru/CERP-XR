using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BuoysToPlace = 4;
    public int BuoysPlaced = 0;

    public string[] correctBuoyNames;
    public InteractiveMap_State physicalState;

    private Buoy_TextController currentDisplay;

    public TextMesh calibrationFeedback;


    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = FindObjectOfType<Buoy_TextController>();
    }


    public void CalibrationClicked()
    {
        CheckPlacement(currentDisplay.selectedBuoy);
    }

    public void CheckPlacement(Buoy_Object calibratedBuoy)
    {
        if(calibratedBuoy.Status == true)
        {
            //feedback
            calibrationFeedback.color = Color.cyan;
            calibrationFeedback.text = "Already Calibrated!";
            StartCoroutine(feedbackTimer());
        }
        //if the name of the buoy matches on the confirm button 
        //and the phyiscal buoy is in place
        else if(calibratedBuoy.buoyInfo.name == correctBuoyNames[BuoysPlaced] && physicalState.BuoyData[BuoysPlaced] == true)
        {
            Debug.Log("Correctly placed buoy");
            calibratedBuoy.setStatus(true);
            BuoysPlaced += 1;

            //feedback
            calibrationFeedback.color = Color.green;
            calibrationFeedback.text = "Successful Calibration!";
            StartCoroutine(feedbackTimer());


            if (BuoysPlaced >= BuoysToPlace)
            {
                //win state!!!
                Debug.Log("we did it!!!");

                calibrationFeedback.color = Color.cyan;
                calibrationFeedback.text = "Calibration Complete";
            }
        }
        else
        {
            //feedback
            calibrationFeedback.color = Color.red;
            calibrationFeedback.text = "Failed Calibration!";
            StartCoroutine(feedbackTimer());

            Debug.Log("NOT placed correctly");
            calibratedBuoy.setStatus(false);
        }


        IEnumerator feedbackTimer()
        {

            yield return new WaitForSeconds(2f);

            calibrationFeedback.text = "";

        }

    }





}
