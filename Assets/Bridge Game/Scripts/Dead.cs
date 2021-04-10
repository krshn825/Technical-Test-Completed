using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour {


	void Start () {
		
	}
	

	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D hit){
		Destroy (hit.gameObject);

	}
	void OnTriggerEnter2D(Collider2D hit){
		//Debug.Log ("triiiiiiiiiiiii");
		Destroy (hit.gameObject);
	}
}
