using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour {
    
    public static SFXPlayer main;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip lifeClip;
    [SerializeField] private AudioClip powerClip;

    private void Start() {
        if (main != null) {
            Destroy(gameObject);
        }

        main = this;
    }

    public void PlayLifeClip() {
        PlayClip(lifeClip);
    }

    public void PlayPowerClip() {
        PlayClip(powerClip);
    }

    private void PlayClip(AudioClip clip) {
        audioSource.pitch = Random.Range(0.9f, 1.3f);
        audioSource.clip = clip;
        audioSource.Play();
    }
}
