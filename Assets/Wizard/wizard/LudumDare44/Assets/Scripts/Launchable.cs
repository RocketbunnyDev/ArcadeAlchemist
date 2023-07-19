using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launchable : MonoBehaviour {

    [SerializeField] private CharacterControllerTopDown controller;

    private Vector3 target = Vector3.zero;

    public void Launch(int i) {
        target = transform.position + Quaternion.AngleAxis(i * 37, Vector3.forward) * Vector2.up;
    }

    private void FixedUpdate() {
        if (target == Vector3.zero) {
            return;
        }

        controller.MoveToPosition(target);
    }
}
