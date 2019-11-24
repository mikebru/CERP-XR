using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurricaneStates : MonoBehaviour
{
    public Material hurricane_Mat;
    public Texture2D[] masks;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void setMask(int index)
    {

        hurricane_Mat.SetTexture("_maskTexture", masks[index]);

    }


}
