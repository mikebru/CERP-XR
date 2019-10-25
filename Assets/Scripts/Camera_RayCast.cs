using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_RayCast : MonoBehaviour
{

    Camera local_cam;

    public GameObject[] Walls;
    public Camera[] CaptureCameras;



    // Start is called before the first frame update
    void Start()
    {
        local_cam = this.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = local_cam.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 hitPosition = hit.point - hit.transform.position;

                Debug.Log(hitPosition.x);

                //change axis
                if (hitPosition.x <= .025f && hitPosition.x >= -.025f)
                {
                    Debug.Log("here");
                    hitPosition = new Vector3(hitPosition.z, hitPosition.y, 0);
                }

                print(hitPosition);

                Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red, 10);

                //re-project cast
                for (int i = 0; i < Walls.Length; i++)
                {
                    if (hit.collider.gameObject == Walls[i])
                    {
                        RaycastHit cam_hit;

                        Vector3 origin = CaptureCameras[i].transform.position + hitPosition;

                        if (Physics.Raycast(origin, CaptureCameras[i].transform.forward, out cam_hit))
                        {
                            Debug.DrawRay(origin, CaptureCameras[i].transform.forward * cam_hit.distance, Color.green, 10);

                        }
                    }
                }
            }

        }



    }
}
