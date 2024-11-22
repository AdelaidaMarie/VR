using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shoot : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject Bullet;
    public float shootForce;
    public AudioSource shootSound;
    private int ammo = 10;
    public Slider ammoSlider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ammoSlider.value = ammo;
        if (GetComponent<OVRGrabbable>().isGrabbed)
        {
           
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger) && ammo >0)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    shootSound.Play();
                    Instantiate(Bullet, shootPoint.position, shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);
                    ammo--;
                }
            }
        }
        if(ammo < 0)
        {
            ammo = 0;
        }
    }
}
