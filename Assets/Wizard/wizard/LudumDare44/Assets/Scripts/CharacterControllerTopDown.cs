using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterControllerTopDown : MonoBehaviour {
    
    [SerializeField] [Range(0,10)] private float speed;
    [SerializeField] [Range(0, 1.5f)] private float destinationSlack;
    private float actualDestinationSlack;

    [SerializeField] private UnityEvent startMoving;
    [SerializeField] private UnityEvent stopMoving;
    private bool isMoving = false;

    private void Awake() {
        actualDestinationSlack = destinationSlack * destinationSlack;
    }

    public void MoveToPosition(Vector3 position) {
        Vector3 difference = (position - transform.position);
        if (difference.sqrMagnitude < actualDestinationSlack) {
            if (isMoving) {
                stopMoving.Invoke();
                isMoving = false;
            }
            return;
        }
        
        if (!isMoving) {
            isMoving = true;
            startMoving.Invoke();
        }

        Vector3 direction = difference.normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, destinationSlack * destinationSlack);
    }
}
