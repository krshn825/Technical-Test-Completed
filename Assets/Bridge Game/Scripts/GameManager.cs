using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public GameObject bomb;
	public GameObject dup;
	public int max_Bombs =5;
	public int unUsed_Bombs;
	public int bombs_Count;
	private Vector3 cur_position;
	public bool reff_bomb;
	public bool _ready;
	int i;
	public int bombsOnHand;
	Transform hittedObj;
	public bool sm;
	Vector3 fin_position;

	public bool man; 
	InGame inGame;
	public bool soun;


	void Start(){
		
		soun = false;
		man = false;
		unUsed_Bombs = max_Bombs;
		_ready = false;
		bombs_Count = 0;
		bombsOnHand = max_Bombs;
		inGame = FindObjectOfType<InGame> ();
		//SoundController.instance.walking.Stop ();
	}

	void Update () {
		
		if ((GameObject.FindGameObjectsWithTag ("Player").Length > 0)&&(FindObjectOfType<InGame>().so == true)) {
			soun = true;

		} else {
			soun = false;
			//SoundController.instance.walking.Stop ();
		}
		if (soun == false) {
			//SoundController.instance.walking.Stop ();
		}
		if (GameObject.FindGameObjectsWithTag ("Bomb").Length > 0) {
			man = true;
		} else {
			man = false;
		}

		if (_ready != true) {
		
			if (Input.GetMouseButtonDown (0)) {
				cur_position = (Camera.main.ScreenToWorldPoint (Input.mousePosition));
				cur_position.z = 0;
				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null) {
					if (hit.collider.tag.Contains ("Bridge")) {
					
						if (bombs_Count < max_Bombs) {
							Instantiate (dup, hit.collider.transform.position, hit.collider.transform.rotation);
						}
					}
					if (hit.collider.tag.Contains ("Bomb")) {
						max_Bombs = max_Bombs + 1;
						bombsOnHand = bombsOnHand + 1;
					//	Debug.Log (hit.collider.gameObject);
						Destroy (hit.collider.gameObject);
						Instantiate (dup, cur_position, hit.collider.transform.rotation);                          //works like cursor

					}
				}
			} 
			if (Input.GetMouseButtonUp (0)) {
				reff_bomb = false;

				RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
				if (hit.collider != null) {
					if ((hit.collider.tag.Contains ("Bridge")) || (hit.collider.tag.Contains ("mouse"))) {
//						
						//Debug.Log ("count  " + bombs_Count);
						if (bombs_Count < max_Bombs) {
							fin_position =Camera.main.ScreenToWorldPoint (Input.mousePosition) ;
							if (hit.collider.transform.localEulerAngles.z < 40) {
								fin_position.x = hit.collider.transform.position.x;
							}if ((hit.collider.transform.localEulerAngles.z < 50)&&(gameObject.transform.localEulerAngles.z > 40)) {
								//fin_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
								fin_position.x = hit.collider.transform.position.x;
								//fin_position.y = hit.collider.transform.position.y;
							}
							if ((hit.collider.transform.localEulerAngles.z >250)) {
								fin_position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
								fin_position.x = hit.collider.transform.position.x;
								//fin_position.y = hit.collider.transform.position.y;
							}if (hit.collider.transform.localEulerAngles.z > 50) {
								fin_position.y = hit.collider.transform.position.y;

							}
							fin_position.z = -2;

							GameObject obj = Instantiate (bomb,fin_position, hit.collider.transform.rotation);	//Instantiate Bomb on Bridge
							//FindObjectOfType<SoundController>().bombFix.Play();
							hittedObj = hit.collider.gameObject.transform;
							obj.transform.SetParent(hittedObj);																		//set bridge as a parent of bomb
							bombsOnHand = bombsOnHand - 1;
							obj.name = "Bomb" + i;
						    	i++;
							bombs_Count = bombs_Count + 1;


						}
					}
				}
			}

		}
	}

	public void Ready(){
		if (man == true) {
			_ready = true;                  //set ready to explose the bomb
			inGame.help.SetActive (false);
			if (soun == true) {
				//SoundController.instance.walking.Play ();
			}

		}else{
			inGame.help.SetActive (true);
		}
	}
	public void Restart(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);//Restart the scene
	}
}

