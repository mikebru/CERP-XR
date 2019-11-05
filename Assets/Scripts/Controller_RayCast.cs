using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class Controller_RayCast : MonoBehaviour
{

    public SteamVR_Action_Boolean GrabPinch;
    public SteamVR_Input_Sources handType;

    Camera local_cam;

    public GameObject[] Walls;
    public Camera[] CaptureCameras;

    public InteractiveUI currentUI;

    public GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {

        GrabPinch.AddOnStateDownListener(TriggerDown, handType);
        GrabPinch.AddOnStateUpListener(TriggerUp, handType);

        local_cam = this.GetComponent<Camera>();
    }


    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger is up");
        //Sphere.GetComponent<MeshRenderer>().enabled = false;
    }
    
    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //Debug.Log("Trigger is down");
        //Sphere.GetComponent<MeshRenderer>().enabled = true;

        if (currentUI != null)
        {
            currentUI.OnClick();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(currentUI != null)
            {
                currentUI.OnClick();
            }
        }
      
            RaycastHit hit;

            if(Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Vector3 hitPosition = hit.point - hit.transform.position;
                //change axis
                if (hitPosition.x <= .025f && hitPosition.x >= -.025f)
                {
                    //Debug.Log("here");
                    hitPosition = new Vector3(hitPosition.z, hitPosition.y, 0);
                }
                //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 10);

                //re-project cast
                for (int i = 0; i < Walls.Length; i++)
                {
                    if (hit.collider.gameObject == Walls[i])
                    {
                        RaycastHit cam_hit;

                        Vector3 origin = CaptureCameras[i].transform.position + hitPosition;

                        if (Physics.Raycast(origin, CaptureCameras[i].transform.forward, out cam_hit))
                        {
                        //Debug.DrawRay(origin, CaptureCameras[i].transform.forward * cam_hit.distance, Color.green, 10);

                            cursor.transform.position = cam_hit.point - new Vector3(0,0,.1f);

                            if(cam_hit.collider.gameObject.GetComponent<InteractiveUI>() != null && currentUI != cam_hit.collider.gameObject.GetComponent<InteractiveUI>())
                            {
                                if (currentUI != null)
                                {
                                    currentUI.OnHoverExit();
                                }

                                currentUI = cam_hit.collider.gameObject.GetComponent<InteractiveUI>();
                                currentUI.OnHoverEnter();
                            }
                            else if(currentUI != null && cam_hit.collider.gameObject.GetComponent<InteractiveUI>() == null)
                            {
                                currentUI.OnHoverExit();
                                currentUI = null;
                            }

                        }
                        else if(currentUI != null)
                        {
                            currentUI.OnHoverExit();
                            currentUI = null;
                        }
                    }
                }
             }
            else if (currentUI != null)
            {
                currentUI.OnHoverExit();
                currentUI = null;
            }



    }
}
