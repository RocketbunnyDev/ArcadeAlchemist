using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour {

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI powerText;
    [SerializeField] TextMeshProUGUI totalText;

    public void UpdateScoreScreen() {
        int power = Orb.main.GetPower() + 1;
        int powerScore = power * 5;
        powerText.text = "x " + power + " = " + powerScore;

        int health = Player.main.GetComponent<Health>().GetHighestHealth();
        int healthScore = health * 2;
        healthText.text = "x " + health + " = " + healthScore;

        int totalScore = healthScore * powerScore;

        KongregateApi.SendStatistic("score", totalScore);

        totalText.text = "Total = " + totalScore;
    }
}
