using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class BuoyDatabase
{
    public BuoyInfo[] BuoyData;
}

[Serializable]
public class BuoyInfo
{
    public string name;
    public string date;
    public string location;
    public string wind;
    public string airtemp;
    public string watertemp;
    public string dew;
    public string atmosphere;
    public string visibility;
}

public class Buoy_Object : InteractiveUI
{
    //public string Name;
    public BuoyInfo buoyInfo;
    public bool Status;

    private TextMesh text;
    private Buoy_TextController TextDisplay;

    public Color deactiveColor;
    public Color activeColor;

    // Start is called before the first frame update
    void Start()
    {
        TextDisplay = FindObjectOfType<Buoy_TextController>();

        text = GetComponentInChildren<TextMesh>();
        text.text = buoyInfo.name;
        text.gameObject.SetActive(false);

        setStatus(Status);   
    }

    private void OnValidate()
    {
       // setStatus(Status);

    }


    public void SetTextActive(bool isOn)
    {
        text.text = buoyInfo.name;

        text.gameObject.SetActive(isOn);
    }


    public void setStatus(bool status)
    {
        Status = status;

        if(status == true)
        {
            GetComponent<SpriteRenderer>().color = activeColor;
            //text.color = activeColor;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = deactiveColor;
            //text.color = deactiveColor;

        }

    }


    #region Player Input
    public override void OnHoverEnter()
    {
        OnHoverEnterEvent.Invoke();
        SetTextActive(true);
        //Debug.Log("Hovered");
    }

    public override void OnHoverExit()
    {
        OnHoverExitEvent.Invoke();
        SetTextActive(false);

        //Debug.Log("Hovered Off");

    }

    public override void OnClick()
    {
        OnClickEvent.Invoke();

        TextDisplay.selectedBuoy = this;
        TextDisplay.setTextDisplays();

        //Debug.Log("Clicked");
    }

    #endregion

}
