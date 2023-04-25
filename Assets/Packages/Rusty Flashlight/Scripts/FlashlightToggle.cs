using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightToggle : MonoBehaviour
{
    public GameObject lightGO; //light gameObject to work with
    public bool isOn = false; //is flashlight on or off?
    private bool trigger = false;
    private AudioSource source;
    public AudioClip click;
    public AudioClip whisper;
    public bool whisperFlag = true;

    // Use this for initialization
    void Start()
    {
        //set default off
        lightGO.SetActive(isOn);

        //get audio source
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //toggle flashlight on key down
        trigger = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch); // for right hand
        if (trigger)
        {
            
            //toggle light
            isOn = !isOn;
            source.PlayOneShot(click, 1);
            if (whisperFlag){
                source.PlayOneShot(whisper, 1);
                whisperFlag = false;
            }
        
            //turn light on
            if (isOn)
            {
                lightGO.SetActive(true);
            }
            //turn light off
            else
            {
                lightGO.SetActive(false);

            }
        }
    }
}
