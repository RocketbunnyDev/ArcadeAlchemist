using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Player main;

    [SerializeField] private CharacterControllerTopDown controller;
    private Vector2 targetPosition;

    private void Start() {
        if (main != null) {
            Destroy(gameObject);
        }

        main = this;
    }

    private void Update() {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate () {
        controller.MoveToPosition(targetPosition);
    }
}
