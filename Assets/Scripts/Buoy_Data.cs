using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy_Data : MonoBehaviour
{
    public string Name;
    public bool Status;

    public float Latitude;
    public float Longitude;


    private TextMesh text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponentInChildren<TextMesh>();
        text.text = Name;
        text.gameObject.SetActive(false);
    }


    public void SetTextActive(bool isOn)
    {
        text.gameObject.SetActive(isOn);
    }

}
