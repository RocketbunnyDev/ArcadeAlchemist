using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggleListener : MonoBehaviour {

    [SerializeField] private Toggle toggle;

    private void Start() {
        toggle.onValueChanged.AddListener(OnSoundToggleChanged);
        toggle.isOn = AudioListener.volume > 0;
    }

    public void OnSoundToggleChanged(bool value) {
        AudioListener.volume = value ? 1 : 0;
    }
}
