using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimation : MonoBehaviour {

    [SerializeField] private SpriteRenderer renderer;
    [SerializeField] private Animator animator;
    [SerializeField] private string runAnimation;
    [SerializeField] private string standAnimation;
    [SerializeField] private bool inverted = false;

    private Vector3 lastPosition = Vector3.zero;

	void LateUpdate() {
        if (lastPosition.x != transform.position.x) {
            renderer.flipX = (lastPosition.x > transform.position.x) ^ inverted;
        }

        lastPosition = transform.position;
	}

    public void StartMoving() {
        if ("" == runAnimation) {
            return;
        }
        
        animator.Play(runAnimation);
    }

    public void StopMoving() {
        if ("" == runAnimation) {
            return;
        }

        animator.Play(standAnimation);
    }
}
