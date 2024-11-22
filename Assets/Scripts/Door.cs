using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject DoorPrefab;
    private bool activated;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public bool Up;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
            if(!Up)
            {
                DoorPrefab.GetComponent<MovePlanet>().Down();
                activated = true;
                Lights();
            } else if(Up) 
            {
                DoorPrefab.GetComponent<MovePlanet>().Up();
            }
        }
    }
    private void Lights()
    {
    if(activated)
        {
            StartCoroutine(Lighte(3f));
        }
    }

    private IEnumerator Lighte(float time) 
    {
        if (activated)
        {
            light3.SetActive(false);
            yield return new WaitForSeconds(time);
            light1.SetActive(true);
            yield return new WaitForSeconds(time);
            light2.SetActive(true);
            yield return new WaitForSeconds(time);
            activated = false;
        }
    }
}
