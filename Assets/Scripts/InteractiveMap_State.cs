using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMap_State : MonoBehaviour
{
    public bool[] BuoyData;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetBuoy(float placedBuoy)
    {
        int buoyCout = (int)Mathf.Abs(placedBuoy);

            if (placedBuoy == 0)
            {
                for (int i = 0; i < BuoyData.Length; i++)
                {
                    BuoyData[i] = false;
                }
            }

            if (placedBuoy > 0)
            {
                BuoyData[buoyCout-1] = true;
            }
            else
            {
                BuoyData[buoyCout+1] = false;
            }
        
    }

}
