using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    private bool isActive;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!collision.gameObject.Equals(Player.main.gameObject)) {
            return;
        }

        isActive = false;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!collision.gameObject.Equals(Player.main.gameObject)) {
            return;
        }

        isActive = true;
    }

    public bool IsActive() {
        return isActive;
    }

    public Vector3 GetRandomSpawnPosition() {
        return new Vector3(
            transform.position.x + Random.Range(-1.8f, 1.8f),
            transform.position.y + Random.Range(-1.8f, 1.8f),
            0
        );
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
