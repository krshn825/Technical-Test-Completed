using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {


	public Animator Thisanimator;
	public Vector3 RaycastDirection;
	public bool move;
	public bool IsRight;
	public float MoveSpeed = 50;
	public float Range;
	public float range2;
	public Transform RayposL;
	public Transform RayposR;
	private GameManager gameManager;
	private CapsuleCollider2D col;
	private GameObject obj;
	public float y = -0.5f;
	public float y1 = 1f;

	public bool so;

	void Awake()

	{
		gameManager = FindObjectOfType<GameManager> ();
		this.tag = "Enemy";

	}
	void Start(){
		so = false;
		col = GetComponent<CapsuleCollider2D> ();
	}
	void FixedUpdate ()
	{if (GameObject.FindGameObjectsWithTag ("Player").Length <= 0) {
			so = false;
		}
		
		if (GameObject.FindGameObjectWithTag ("Reverse") == true) {
			obj = GameObject.FindGameObjectWithTag ("Reverse");
			obj.transform.TransformPoint (Vector3.zero);
			Debug.Log ("obj        "+obj.transform.position.y);
			Debug.Log ("gamebj  car     "+gameObject.transform.position.y);
		}
		if (GameObject.FindGameObjectsWithTag ("Reverse").Length > 0) {
			if ((gameObject.transform.position.x < obj.transform.position.x)&&(obj.transform.position.y > y)&&(obj.transform.position.y < y1)) {
				IsRight = false;
			}
			if((gameObject.transform.position.x > obj.transform.position.x) &&(obj.transform.position.y > y)&&(obj.transform.position.y < y1)){
			IsRight = true;
			}
		}

		if (gameManager._ready == true) {
			if (IsRight) {
				RaycastDirection = new Vector3 (1, 0, 0);
				if ((move) && (IsRight)) {	
					so = true;
					Thisanimator.SetBool ("ISRight", true);
				
					RaycastHit2D hit = Physics2D.Raycast (RayposR.position, new Vector3 (1, 0, 0), range2);					//Raycasting for turn direction
					Debug.DrawRay (transform.position, new Vector3 (1, 0, 0));
					transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
					gameObject.transform.localEulerAngles = new Vector3 (0, 0, 0);
					if (hit.collider != null) {
						if (hit.collider.tag.Contains ("Reverse")) {

							IsRight = false;
							FindObjectOfType<GameManager> ().sm = true;
						}

					}
				}
			} else {
				RaycastDirection = new Vector3 (-1, 0, 0);
				if ((move) && (!IsRight)) {
					Thisanimator.SetBool ("ISLeft", true);
					so = true;

					//RaycastHit2D hit2 = Physics2D.Raycast(RayposL.position,new Vector3(-1,-1,0),Range);
					RaycastHit2D hit = Physics2D.Raycast (RayposL.position, new Vector3 (-1, 0, 0), range2);                         //Raycasting for turn direction
					Debug.DrawRay (transform.position, new Vector3 (-1, 0, 0));
					transform.position += -Vector3.right * Time.deltaTime * MoveSpeed;
					gameObject.transform.localEulerAngles = new Vector3 (0, 180, 0);
					if (hit.collider != null) {
						if (hit.collider.tag.Contains ("Reverse")) {
							IsRight = true;
							FindObjectOfType<GameManager> ().sm = false;
						}
					}

				}
			}	
		}
		}

	//}
	void OnTriggerEnter2D(Collider2D incoming){
		if(incoming.tag.Contains("Trigg"))
		{
			Thisanimator.SetBool ("ISRight",false);
			Thisanimator.SetBool ("ISLeft",false);
			Thisanimator.SetBool ("Dead",true);                                                                              //Destroy Player
			Debug.Log (incoming.gameObject.name);                                                                                    
			Invoke ("Destroy",0.1f);


			gameObject.tag = "Constant";
		}
	}
	void OnCollisionEnter2D(Collision2D incoming){

	}
	void Destroy(){
		col.isTrigger = true;
	}
}
