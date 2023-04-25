using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject player;
    public GameManager GameManager;

    void OnTriggerEnter(Collider player)
    {
        // Call function to increase key count, then deactivate object
        GameManager.incKeysCollected();
        gameObject.SetActive(false);
    }
}
