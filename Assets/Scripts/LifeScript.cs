using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public GameObject Invent;
    public GameObject Anchor;
    public GameObject Invent2;
    public GameObject Anchor2;
    bool UIActive;
    bool UIActive2;

    private void Start()
    {
        Invent.SetActive(false);
        UIActive = false;
        UIActive2 = false;
        Invent2.SetActive(false);
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            UIActive = !UIActive;
            Invent.SetActive(UIActive);
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            UIActive2 = !UIActive2;
            Invent2.SetActive(UIActive2);
            
        }
            if (UIActive)
        {
            Invent.transform.position = Anchor.transform.position;
            Invent.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        }
            if (UIActive2)
        {
            Invent2.transform.position = Anchor2.transform.position;
            Invent2.transform.eulerAngles = new Vector3(Anchor2.transform.eulerAngles.x, Anchor2.transform.eulerAngles.y , Anchor2.transform.eulerAngles.z);
        }
        if (UIActive2 && OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("Quit");
            Application.Quit();

        }
    }
}
