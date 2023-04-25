using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script is attached to Maze Exit Gate, and handles endgame and restart scenarios
public class EndGame : MonoBehaviour
{

    //Objects
    public GameManager GameManager;
    public GameObject player;
    public Material Day;
    public Cubemap DayCube;
    public Material Night;
    public Cubemap NightCube;
    public Text endText;
    private AudioSource source;
    public GameObject[] Keys;
    public GameObject[] Lights;
    public GameObject Flashlight;

    // Variables
    private bool buttonA;
    private bool buttonX;
    private bool allKeys;
    private bool keyFlag = true;


    void Start()
    {
        //get audio source
        source = GetComponent<AudioSource>();

        //disable winning message
        endText.enabled = false;
    }

    void Update()
    {
        //Detect if user presses RESTART button
        buttonA = OVRInput.GetDown(OVRInput.Button.One);
        if (buttonA)
        {
            //Move player to original position
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(-13, 2, 46);
            player.GetComponent<CharacterController>().enabled = true;

            //Make maze be dark again
            RenderSettings.skybox = Night;
            RenderSettings.customReflection = NightCube;

            // Reactivate keysS
            int i = 0;
            foreach (GameObject key in Keys){
                key.SetActive(true);
                i++;
            }

            //Turn maze lights off again
            foreach (GameObject light in Lights){
                light.GetComponent<Light>().enabled = false;
            }

            // Update variables and text display
            GameManager.keysCollected = 0;
            GameManager.keyCount.text = "Keys: 0/" + GameManager.keysToWin.ToString();
            GameManager.gameOver = false;
            keyFlag = true;
            Flashlight.GetComponent<FlashlightToggle>().isOn = false;
        }

        //For testing purposes. Teleports user to end of game.
        buttonX = OVRInput.GetDown(OVRInput.Button.Three);
        if (buttonX)
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(-13, 2, -46);
            player.GetComponent<CharacterController>().enabled = true;
        }

        //See if player collected all keys needed, if so deactivate the rest
        allKeys = GameManager.gameOver;
        if (allKeys && keyFlag){
            foreach (GameObject key in Keys){
                key.SetActive(false);
            }

            //Play sound of door opening
            source.Play();
            keyFlag = false;
        }
    }
    
    //When player collides with gate, check if all keys have been collected
    //If player has all keys, light up maze and show endgame text. Otherwise ....
    void OnTriggerEnter(Collider player)
    {
        allKeys = GameManager.gameOver;
        if (allKeys){
            source.Play();
            endText.enabled = true;
            RenderSettings.skybox = Day;
            RenderSettings.customReflection = DayCube;
        }
    }
}
