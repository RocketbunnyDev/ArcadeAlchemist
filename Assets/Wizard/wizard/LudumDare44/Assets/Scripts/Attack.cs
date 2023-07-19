using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour {

    [SerializeField] [Range(0, 1)] private float lifeTime;
    [SerializeField] [Range(0, 10)] private int power;
    [SerializeField] private Collider2D collider;
    [SerializeField] private UnityEvent onHit;
    private bool alreadyHit = false;

	private void Start() {
        if (lifeTime > 0) {
            StartCoroutine("Live");
            StartCoroutine("DisableCollider");
        }
	}

    private IEnumerator Live() {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

    private IEnumerator DisableCollider() {
        yield return new WaitForSeconds(0.1f);
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Health otherHealth = collision.gameObject.GetComponent<Health>();

        if (null == otherHealth) {
            return;
        }

        otherHealth.TakeDamage(power);

        if (alreadyHit) {
            return;
        }

        alreadyHit = true;
        onHit.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag(gameObject.tag)) {
            return;
        }

        Health otherHealth = collision.gameObject.GetComponent<Health>();

        if (null == otherHealth) {
            return;
        }

        otherHealth.TakeDamage(power);
    }

    public void AddPower(int power) {
        this.power += power;
    }
}
