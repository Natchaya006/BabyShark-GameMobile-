using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tran : MonoBehaviour {

	public float speed;
	public float left;

	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;
		if (position.x < left) {
			Destroy (gameObject);
			return;
		}
		transform.Translate (-speed * Time.deltaTime, 0, 0);
	}
}
