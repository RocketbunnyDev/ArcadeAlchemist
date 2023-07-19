using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItemChance : MonoBehaviour {

    [SerializeField] [Range(1,100)] private int oneIn = 1;
    [SerializeField] private GameObject[] items;

    public void HandleSpawn() {
        int outcome = Random.Range(0, oneIn);

        if (outcome != 1) {
            return;
        }

        Instantiate(items[Random.Range(0, items.Length)], transform.position, Quaternion.identity);
    }
}
