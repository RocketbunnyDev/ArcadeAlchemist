using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unique : MonoBehaviour {
    private static Unique instance;

    [SerializeField] private string uniqueName;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        if (null != instance) {
            Destroy(instance.gameObject);
        }

        instance = this;
    }
}
