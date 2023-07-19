using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEnable : MonoBehaviour {

    [SerializeField] private int buildIndex = 0;

    private void OnEnable() {
        SceneManager.LoadScene(buildIndex);
    }
}
