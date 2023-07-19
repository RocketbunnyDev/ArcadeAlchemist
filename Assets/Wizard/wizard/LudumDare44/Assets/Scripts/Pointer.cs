using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
		transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void Deactivate() {
        Cursor.visible = true;
    }
}
