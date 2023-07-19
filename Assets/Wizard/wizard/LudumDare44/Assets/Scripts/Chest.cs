using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    [SerializeField] private Animator animator;
    [SerializeField] private string openSprite;
    [SerializeField] private GameObject[] items;

    public void Open() {
        animator.Play(openSprite);
        GameObject item;

        int j = 0;
        int i1, n1, i2, n2;

        for (i1 = 0, n1 = Random.Range(1, 3); i1 < n1; i1++) {
            foreach (GameObject prefab in items) {
                for (i2 = 0, n2 = Random.Range(0, 2); i2 < n2; i2++) {
                    item = Instantiate(prefab, transform.position, Quaternion.identity) as GameObject;
                    item.GetComponent<Launchable>().Launch(j);
                    j++;
                }
            }
        }

        StartCoroutine("Die");
    }

    private IEnumerator Die() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
