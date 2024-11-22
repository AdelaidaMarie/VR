using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public GameObject Invent;
    public GameObject Anchor;
    bool UIActive;

    private void Start()
    {
        Invent.SetActive(true);
        UIActive = true;
    }

    private void Update()
    {
        /*if (OVRInput.GetDown(OVRInput.Button.One))
        {
            UIActive = !UIActive;
            Invent.SetActive(UIActive);
        }
        if (UIActive)
        {*/
            Invent.transform.position = Anchor.transform.position;
            Invent.transform.eulerAngles = new Vector3(Anchor.transform.eulerAngles.x + 15, Anchor.transform.eulerAngles.y, 0);
        //}
    }
}
