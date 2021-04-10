using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour {

	public Vector3 RaycastDirection;
	public bool move;
	public bool IsRight;
	public float MoveSpeed = 2;
	//public float Range;
	public float range2;
	public Transform RayposR;
	private GameManager gameManager;
	private GameObject obj;
	public float y;
	public float y1;
	private PolygonCollider2D col;
	private int r = 0;
	private int l = 180;

	void Awake()
	{
		gameManager = FindObjectOfType<GameManager> ();

	}
	void Start(){
		col = GetComponent<PolygonCollider2D> ();
		//Thisanimator.
	}
	void FixedUpdate ()
	{
		if (GameObject.FindGameObjectWithTag ("Reverse") == true) {
			obj = GameObject.FindGameObjectWithTag ("Reverse");
			obj.transform.TransformPoint (Vector3.zero);
			Debug.Log ("obj        "+obj.transform.position.y);
			Debug.Log ("gamebj  car     "+gameObject.transform.position.y);
		}if (GameObject.FindGameObjectsWithTag ("Reverse").Length > 0) {

			if ((gameObject.transform.position.x < obj.transform.position.x) && (obj.transform.position.y > y)&&(obj.transform.position.y < y1)) {
				IsRight = false;
				Debug.Log ("yeap");
			}
			if ((gameObject.transform.position.x > obj.transform.position.x) && (obj.transform.position.y > y)&&(obj.transform.position.y < y1)) {
				IsRight = true;
			}
		}
		if(gameManager._ready == true){
			if(IsRight)
			{
				RaycastDirection = new Vector3(1,0,0);
				if ((move)&&(IsRight)) {		
					//	RaycastHit2D hit2 = Physics2D.Raycast(RayposR.position,new Vector3(1,-1,0),Range);

					RaycastHit2D hit = Physics2D.Raycast (RayposR.position, new Vector3 (1, 0, 0), range2);					//Raycasting for turn direction
					Debug.DrawRay (RayposR.position, new Vector3 (1, 0, 0));
					transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
					gameObject.transform.localEulerAngles = new Vector3 (0, 0, 0);
					if (hit.collider != null) {
						if (hit.collider.tag.Contains ("Reverse")) {
							
							IsRight = false;
							FindObjectOfType<GameManager> ().sm = true;
						}

					}
				}
			}
			else
			{
				RaycastDirection = new Vector3(-1,0,0);
				if((move)&&(!IsRight))
				{
					//RaycastHit2D hit2 = Physics2D.Raycast(RayposL.position,new Vector3(-1,-1,0),Range);
					RaycastHit2D  hit  = Physics2D.Raycast(RayposR.position,new Vector3(-1,0,0),range2);                         //Raycasting for turn direction
					Debug.DrawRay(RayposR.position,new Vector3(-1,0,0));
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
	void OnTriggerEnter2D(Collider2D incoming){
		if(incoming.tag.Contains("Trigg"))
		{                                                                            //Destroy Player
			//Debug.Log (incoming.gameObject.name);                                                                                    
			//Debug.Log ("veh triggered");

			//Thisanimator.SetBool ("Blast",true);
			col.isTrigger = true;
			gameObject.tag = "Constant";
			//Destroy(this.gameObject);
		}
	}
	void OnCollisionEnter2D(Collision2D incoming){

	}
	void Destroy(){
		//
	}
}
