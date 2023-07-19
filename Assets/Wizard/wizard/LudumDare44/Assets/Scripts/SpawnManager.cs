using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField] private int minimumPower = 0;
    [SerializeField] private int maximumPower = 0;
    [SerializeField] private float interval;
    [SerializeField] private GameObject prefab;
    [SerializeField] private ObjectSpawner[] spawners;
    private float timer = 0;

    private void Start() {
        StartCoroutine("Spawn");
    }

    private IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(
                Mathf.Max(
                    (Random.Range(interval / 4, interval * 2) - timer),
                    (Random.Range(0.1f, 1.5f))
                )
            );
            if (!IsPowerGoodForSpawn()) {
                continue;
            }
            timer += 0.01f;
            Instantiate(prefab, GetRandomActiveSpawner().GetRandomSpawnPosition(), Quaternion.identity);
        }
    }

    private bool IsPowerGoodForSpawn() {
        return Orb.main.GetTotalPower() >= minimumPower && (Orb.main.GetTotalPower() <= maximumPower || maximumPower == 0);
    }

    private ObjectSpawner GetRandomActiveSpawner() {
        int randomIndex = Random.Range(0, spawners.Length);
        return TryToGetActiveSpawner(randomIndex);
    }

    private ObjectSpawner TryToGetActiveSpawner(int i) {
        if (spawners[i].IsActive()) {
            return spawners[i];
        }

        return TryToGetActiveSpawner((i + 1) % spawners.Length);
    }
}
