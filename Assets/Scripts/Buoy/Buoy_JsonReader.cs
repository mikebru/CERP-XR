using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoy_JsonReader : MonoBehaviour
{
    public BuoyDatabase allData;
    public TextAsset JsonData;

    public Buoy_Object[] buoy_Objects;

    // Start is called before the first frame update
    void Start()
    {
        allData = JsonUtility.FromJson<BuoyDatabase>(JsonData.text);
        buoy_Objects = GetComponentsInChildren<Buoy_Object>();


        assignData();
    }


    void assignData()
    {
        for(int i=0; i< allData.BuoyData.Length; i++)
        {
            buoy_Objects[i].buoyInfo = allData.BuoyData[i];
        }
    }


}
