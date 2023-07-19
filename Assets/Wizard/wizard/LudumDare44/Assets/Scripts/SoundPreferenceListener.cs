using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPreferenceListener : MonoBehaviour {

    [SerializeField] private AudioListener listener;

	private void Start () {
        int volume = PlayerPrefs.GetInt("sound");
    }
}
