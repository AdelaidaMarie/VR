using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScripts : MonoBehaviour
{
    public bool end;
    public bool quit;
    public bool start;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (GetComponent<OVRGrabbable>().isGrabbed && start)
        {
            SceneManager.LoadScene(1);

        } else if (GetComponent<OVRGrabbable>().isGrabbed && quit)
        {
            Application.Quit();
        }
        else if (GetComponent<OVRGrabbable>().isGrabbed && end)
        {
            SceneManager.LoadScene(0);
        }
    }
}
