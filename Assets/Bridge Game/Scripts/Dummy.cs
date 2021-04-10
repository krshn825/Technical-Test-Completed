using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour {
	
	Vector3 objPositions;
	public GameManager gameManager;

	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		gameManager.reff_bomb = true;
	}
	

	void Update () {
		if(gameManager.reff_bomb == true){
		if (Input.GetMouseButton (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
			if (hit.collider != null) {
				if (hit.collider.tag.Contains ("Bridge")) {
						objPositions = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						if (gameObject.transform.localEulerAngles.z > 45) {
							objPositions.y = hit.collider.transform.position.y;
						}if (gameObject.transform.localEulerAngles.z < 40) {
							objPositions.x = hit.collider.transform.position.x;
						}if ((gameObject.transform.localEulerAngles.z < 45)&&(gameObject.transform.localEulerAngles.z > 40)) {
							objPositions= Camera.main.ScreenToWorldPoint (Input.mousePosition);
						}
						if ((gameObject.transform.localEulerAngles.z >250)) {
							objPositions = Camera.main.ScreenToWorldPoint (Input.mousePosition);
						}

						objPositions.z = 0;
						gameObject.transform.position = objPositions;
					gameObject.transform.rotation = hit.collider.gameObject.transform.rotation;                                       //works like cursor
		
				}
			}
		}
	}
		if(gameManager.reff_bomb ==false){
			Destroy (gameObject);
		}
  }

}
