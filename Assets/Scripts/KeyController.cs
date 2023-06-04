using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // promimity where the player can press button to destroy the key
    public float proximityThreshold = 2.0f;
    public KeyCode destructionKey = KeyCode.E;

    private GameObject player;
    private PlayerKeyCollect playerKeyCollect;

    void Start()
    {
        // the player must be tagged Player
        player = GameObject.FindGameObjectWithTag("Player");
        // player class playerKeyCollect must contain the IncrementKeysCollected method
        playerKeyCollect = player.GetComponent<PlayerKeyCollect>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= proximityThreshold && Input.GetKeyDown(destructionKey))
        {
            playerKeyCollect.IncrementKeysCollected();
            Debug.Log("object destroyed");
            Destroy(gameObject);
        }
    }
}
