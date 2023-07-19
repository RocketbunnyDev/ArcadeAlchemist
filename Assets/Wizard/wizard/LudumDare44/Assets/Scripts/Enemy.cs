using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] CharacterControllerTopDown controller;
    private bool stunned = false;

    private void FixedUpdate() {
        if (stunned) {
            return;
        }

        controller.MoveToPosition(Player.main.transform.position);
    }

    public void Stun() {
        stunned = true;
        StartCoroutine("UnStun");
    }

    private IEnumerator UnStun() {
        yield return new WaitForSeconds(0.2f);
        stunned = false;
    }
}
