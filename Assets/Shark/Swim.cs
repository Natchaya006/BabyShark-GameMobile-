using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Swim : MonoBehaviour {
	private Animator animator;
	private Rigidbody2D rigidbody2D;
	private AudioSource audioSource;

	public AudioClip swim;
	public AudioClip die;
	public AudioClip hit;
	public AudioClip collect;
	public bool died = false;
	public UIManager uiManager;

	public Vector2 velocity;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		Invoke ("startPlay",1);
		animator.SetTrigger ("isSwim");
		rigidbody2D.velocity = velocity;
		audioSource.PlayOneShot (swim);
	}
	
	// Update is called once per frame
	void Update () {
		bool mouseDown = Input.GetMouseButtonDown (0);
		if(mouseDown){
			if (died == false) {
				animator.SetTrigger ("isSwim");
				rigidbody2D.velocity = velocity;
				audioSource.PlayOneShot (swim);
			} else {
				return;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if (died == true) {
			return;
		}
		audioSource.PlayOneShot (hit);
		died = true;
		Invoke ("PlayAgin",1);
	}
	void PlayAgin(){
		uiManager.ShowResult ();
	}
	void startPlay(){
		uiManager.startGame ();
	}
		
	void OnTriggerEnter2D (Collider2D c){
		if (died == true) {
			return;
		}
		uiManager.Score ();
		audioSource.PlayOneShot (collect);

	}

}
