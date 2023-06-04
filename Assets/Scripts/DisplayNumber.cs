using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // using TextMeshPro

public class DisplayNumber : MonoBehaviour {
    private PlayerKeyCollect playerKeyCollect;
    private TextMeshProUGUI uiTextMeshPro;

    void Start() {
        // Find the GameObject with the PlayerKeyCollect script attached
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerKeyCollect = player.GetComponent<PlayerKeyCollect>();
        uiTextMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        // Update the UI Text or TextMeshPro with the value of the public variable
        uiTextMeshPro.text = playerKeyCollect.keysCollected.ToString();
    }
}
