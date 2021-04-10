using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour {
	
	private float click;
	private float clickTime;
	private float tappedTime;
	private bool tapped = false;
	[SerializeField]
	float xMin =-8;
	[SerializeField]
	float xMax= 8;
	[SerializeField]
	float yMin = -4;
	[SerializeField]
	float yMax =3;
	Vector3 finPos;
	bool trig;

	void Start(){
		trig = false;
	}

	void Update () {
		if (Input.GetMouseButton(0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

			if (hit.collider != null) {
				
				if (hit.collider.name == this.gameObject.name) {					
					tappedTime += Time.deltaTime;
		
				}
			}
		}
		if (click == 1 && clickTime < .5) {
			clickTime += Time.deltaTime;
		}
		if (click == 1 && clickTime >= .5) {
			click = 0;
			clickTime = 0;
		}
		if (click == 2 && clickTime < .5) {
			click = 0;
			this.transform.Rotate (0, 0,180);
		}
		if (click == 2 && clickTime >= .5) {
			click = 0;
			clickTime = 0;
		}		
		if (tapped == true && tappedTime >= .4f) {	
			Time.timeScale = .5f;
			if (trig !=false) {
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				this.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition) + new Vector3 (0, 0, 10) - finPos;
				transform.position = new Vector3 (Mathf.Clamp (transform.position.x, xMin, xMax), Mathf.Clamp (transform.position.y, yMin, yMax), transform.position.z);


			}
		}
	}
	void OnMouseDown(){
		if(trig ==true){
		Vector3 Mos = Camera.main.ScreenToWorldPoint (Input.mousePosition)+ new Vector3 (0,0,10);
		Vector3 Obj = this.transform.position;
		finPos = Mos - Obj;
		click += 1;
		tapped = true;
	  }
	}

	void OnMouseUp(){	
		Time.timeScale = 1;		
		tapped = false;
		tappedTime = 0;

	}
	void OnTriggerEnter2D(Collider2D hit){
		
		if (hit.tag.Contains ("Bridge")) {
			trig = true;

		} 
	}
	void OnTriggerStay2D(Collider2D hit){

		if (hit.tag.Contains ("Bridge")) {
			trig = true;
			//Debug.Log ("true");
		} 
	}
	void OnTriggerExit2D(Collider2D hit){

		if (hit.tag.Contains ("Bridge")) {
			//trig = false;
			//Debug.Log ("false");
		} 
	}
}
