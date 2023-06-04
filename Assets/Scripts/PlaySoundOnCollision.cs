using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnCollision : MonoBehaviour {
    public float impactThreshold = 1.0f;
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collision detected: " + collision.relativeVelocity.magnitude);
        // Check if the impact force is above the threshold
        if (collision.relativeVelocity.magnitude > impactThreshold) {
            Debug.Log("Playing sound effect");
            // Play the sound effect
            audioSource.Play();
        }
    }
}
