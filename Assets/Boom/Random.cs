using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour {
	public Transform boom;
	public float delay;
	public float minY;
	public float maxY;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn", 1, delay);
	}

	// Update is called once per frame
	void Spawn () {
		
		Vector3 position = boom.position;
		position.y = UnityEngine.Random.Range (minY, maxY);
		GameObject.Instantiate (boom, position, Quaternion.identity);
	}
}
