using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float range;
    RaycastHit hit;
    public LayerMask layerGround;
    public LineRenderer line;
    public Transform player;


    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.enabled = false;

    }

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerGround))
            {
                //Tomamos el componente LineRenderer 
                line.enabled = true;
                //Posición inicial del LineRender
                line.SetPosition(0, transform.position);
                //Posición final del LineRender
                line.SetPosition(1, hit.point);
                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {

                    player.GetComponent<CharacterController>().enabled = false;
                    player.GetComponent<OVRPlayerController>().enabled = false;

                    player.transform.position = new Vector3(hit.point.x, 1, hit.point.z);


                    player.GetComponent<CharacterController>().enabled = true;
                    player.GetComponent<OVRPlayerController>().enabled = true;
                }
            }
            else
            {
                line.enabled = false;

            }
        }
        else
        {
            line.enabled = false;

        }
    }
}