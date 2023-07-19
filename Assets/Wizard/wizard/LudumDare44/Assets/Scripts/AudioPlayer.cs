using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    [SerializeField] private AudioSource audioSource;

    public void PlayWithRandomPitch() {
        audioSource.pitch = Random.Range(0.9f, 1.3f);
        audioSource.Play();
    }
}
