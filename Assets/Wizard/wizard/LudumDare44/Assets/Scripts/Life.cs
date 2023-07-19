using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        Health otherHealth = collision.gameObject.GetComponent<Health>();

        if (null == otherHealth) {
            return;
        }

        otherHealth.AddHealth(1);
        SFXPlayer.main.PlayLifeClip();

        Destroy(gameObject);
    }
}
