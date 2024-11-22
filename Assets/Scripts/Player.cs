using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int Life = 10;
    public Slider lifeSlider;
    public GameObject restart;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lifeSlider.value = Life;
        if (Life <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Life--;

        }
        if (other.gameObject.tag == "EndPoint")
        {
            player.transform.position = restart.transform.position;
        }
    }
}
