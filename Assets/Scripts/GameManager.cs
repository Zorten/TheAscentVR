using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool buttonB = false;
    public GameObject player;
    public int keysCollected = 0;
    public bool gameOver = false;
    public int keysToWin = 3;
    public Text keyCount;
    //private AudioSource source;

    //Original player postion: (-24, 1.5, 95)

    // Update is called once per frame
    void Update()
    {

        buttonB = OVRInput.GetDown(OVRInput.Button.Two);
        if (buttonB || Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        keyCount.text = "Keys: " + keysCollected.ToString() + "/" + keysToWin.ToString();

    }

    public void incKeysCollected () {
        if (keysCollected == keysToWin){
            gameOver = true;
        }
        else
        {
            keysCollected++;
        }
    }

}
