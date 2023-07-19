using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private int health;
    private int highestHealth = 0;
    [SerializeField] private int maxDamage = 0;
    [SerializeField] private UnityEvent onTakeDamage;
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private bool destroyOnDeath = false;
    [SerializeField] private TextMeshProUGUI text;
    private bool invincible = false;
    private Color originalColor;

    private void Awake() {
        originalColor = renderer.color;
    }

    private void Start() {
        HandleTextField();
        highestHealth = health;
    }

    public void TakeDamage(int amount) {
        if (invincible) {
            return;
        }

        if (maxDamage > 0 && amount > maxDamage) {
            health -= maxDamage;
        }
        else {
            health -= amount;
        }
        
        onTakeDamage.Invoke();

        HandleTextField();

        if (health <= 0) {
            health = 0;
            onDie.Invoke();

            if (gameObject.CompareTag("Enemy")) {
                KongregateApi.SendStatistic("killedEnemies", 1);
            }

            if (destroyOnDeath) {
                Destroy(gameObject);
            }
        }
    }

    private void HandleTextField() {
        if (null == text) {
            return;
        }

        text.text = "x " + health;
    }

    public void AddHealth(int amount) {
        health += amount;
        highestHealth = Mathf.Max(highestHealth, health);

        HandleTextField();
    }

    public void Flash() {
        invincible = true;
        renderer.color = Color.red;
        StopAllCoroutines();
        StartCoroutine("StopFlashing");
    }

    private IEnumerator StopFlashing() {
        yield return new WaitForSeconds(0.2f);
        renderer.color = originalColor;
        invincible = false;
    }

    public void RemoveComponent() {
        renderer.color = Color.white;
        Destroy(this);
    }

    public int GetHighestHealth() {
        return highestHealth;
    }
}
