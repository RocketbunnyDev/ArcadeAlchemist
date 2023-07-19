using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour {

    [SerializeField] private UnityEvent onPickup;

    private void OnTriggerEnter2D(Collider2D collision) {
        Health otherHealth = collision.gameObject.GetComponent<Health>();

        if (null == otherHealth) {
            return;
        }

        onPickup.Invoke();
        otherHealth.TakeDamage(1);
        Orb.main.PowerUp();
        SFXPlayer.main.PlayPowerClip();

        Destroy(gameObject);
    }
}
