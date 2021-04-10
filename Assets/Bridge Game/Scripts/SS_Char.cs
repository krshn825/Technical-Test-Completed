using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SS_Char : MonoBehaviour 
{
	
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
	void Awake()
	{
		gameManager = FindObjectOfType<GameManager> ();
		this.tag = "Enemy";

	}
	void Start(){
		col = GetComponent<CapsuleCollider2D> ();
	}
	void FixedUpdate ()
	{
		if(gameManager._ready == true){
		if (gameManager.sm == true) {
			IsRight = false;
		}
		if (gameManager.sm == false) {
			//IsRight = true;
		}
		if(IsRight)
		{
		RaycastDirection = new Vector3(1,0,0);
				if ((move)&&(IsRight)) {		
				Thisanimator.SetBool ("ISRight", true);	

				//	RaycastHit2D hit2 = Physics2D.Raycast(RayposR.position,new Vector3(1,-1,0),Range);
				
				RaycastHit2D hit = Physics2D.Raycast (RayposR.position, new Vector3 (1, 0, 0), range2);					//Raycasting for turn direction
					Debug.DrawRay (transform.position, new Vector3 (1, 0, 0));
				transform.position += Vector3.right * Time.deltaTime * MoveSpeed;
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
			Thisanimator.SetBool("ISRight",false);
			RaycastHit2D  hit  = Physics2D.Raycast(RayposL.position,new Vector3(-1,0,0),range2);                         //Raycasting for turn direction
			Debug.DrawRay(transform.position,new Vector3(-1,0,0));
			transform.position += -Vector3.right * Time.deltaTime * MoveSpeed;
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
		{
			Thisanimator.SetBool ("ISRight",false);
			Thisanimator.SetBool ("Dead",true);                                                                              //Destroy Player
			Debug.Log (incoming.gameObject.name);                                                                                    
			Invoke ("Destroy",1);

		}
	}
	void OnCollisionEnter2D(Collision2D incoming){
		
	}
	void Destroy(){
		col.isTrigger = true;
	}
}
