using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy_TextController : MonoBehaviour
{
    public Buoy_Object selectedBuoy { get; set; }

    public TextMesh[] textDisplays;


    // Start is called before the first frame update
    void Start()
    {
        displayChildren(false);
    }

    public void displayChildren(bool isOn)
    {
        transform.GetChild(0).gameObject.SetActive(isOn);
    }

    public void setTextDisplays()
    {
        displayChildren(true);


        textDisplays[0].text = selectedBuoy.buoyInfo.name;
        textDisplays[1].text = "Date:   " + selectedBuoy.buoyInfo.date;
        textDisplays[2].text = "Location:   " + selectedBuoy.buoyInfo.location;
        textDisplays[3].text = "Wind:   " + selectedBuoy.buoyInfo.wind;
        textDisplays[4].text = "Air Temperature:    " + selectedBuoy.buoyInfo.airtemp;
        textDisplays[5].text = "Water Temperature:  " + selectedBuoy.buoyInfo.watertemp;
        textDisplays[6].text = "Dew Point:  " + selectedBuoy.buoyInfo.dew;
        textDisplays[7].text = "Atmospheric Pressure:   " + selectedBuoy.buoyInfo.atmosphere;
        textDisplays[8].text = "Visibility:    " + selectedBuoy.buoyInfo.visibility;
    }


}
