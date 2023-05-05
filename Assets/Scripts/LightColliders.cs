using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColliders : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Turn off all lights when game starts
        gameObject.GetComponent<Light>().enabled = false;
    }


    void OnTriggerEnter(Collider player)
    {
        //turn on light once collider entered
        gameObject.GetComponent<Light>().enabled = true;
    }
}
