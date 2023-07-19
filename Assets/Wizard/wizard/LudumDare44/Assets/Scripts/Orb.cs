using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Orb : MonoBehaviour {

    public static Orb main;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] CharacterControllerTopDown controller;
    [SerializeField] Transform target;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] [Range(0.1f, 1)] float attackInterval;
    private Vector2 relativePosition;
    private bool isHoldingMouse;
    private int powerUp = 0;


    private void Start() {
        if (main != null) {
            Destroy(gameObject);
        }

        main = this;
        StartCoroutine("Attack");
        HandleTextField();
    }

    private void HandleTextField() {
        if (null == text) {
            return;
        }

        text.text = "x " + powerUp;
    }

    private IEnumerator Attack() {
        while (true) {
            Vector2 direction = GetDirection();
            GameObject attack = Instantiate(attackPrefab, transform.position, Quaternion.Euler(0, 0, -(Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg))) as GameObject;
            attack.GetComponent<Attack>().AddPower(powerUp);
            yield return new WaitForSeconds(attackInterval);
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            relativePosition = transform.position - target.position;
        }

        isHoldingMouse = Input.GetMouseButton(0);
    }

    private void FixedUpdate() {
        if (isHoldingMouse) {
            transform.position = target.position + (Vector3) relativePosition;

            return;
        }
        controller.MoveToPosition(target.position);
    }

    private Vector2 GetDirection() {
        if (isHoldingMouse) {
            return relativePosition;
        }
        
        return transform.position - target.position;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position, transform.position + (Vector3) GetDirection());
    }

    public void PowerUp() {
        powerUp++;
        HandleTextField();
    }

    public int GetPower() {
        return powerUp;
    }

    public int GetTotalPower() {
        return GetPower();
    }
}
