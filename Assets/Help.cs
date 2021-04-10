using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour {

	public GameObject first;
	public GameObject arr;
	public GameObject after_ready;
	GameManager gm;

	void Start () {
		gm = FindObjectOfType<GameManager> ();
		
	}
	

	void Update () {
		if (gm.man) {
			if ((gm.bombsOnHand == 0)) {
				first.SetActive (false);
				arr.SetActive (true);
			}
		}
		if(gm._ready){
			arr.SetActive (false);
			after_ready.SetActive (true);
		}
		
	}
}
