using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour {
	
	public GameObject levelCompleted;
	public GameObject levelFail;
	public GameObject pauseMenu;
	public Text levelCompScr;
	public Text levelFailScr;
	public Text levelCompTarget;
	public Text levelFailTarget;

	public Text bombs;
	public Text score;
	public Text target;
	public int targetScore =1500;
	public int mul_Value =35;
	private int i;
	private int players;
	private int active_Players;
	private int player_Score;

	private int bombsCount;

	private int b;
	private GameManager gameManager;
	private int score_Hint;
	private int curr_score;
	private int unUsedBombs;
	private int bombScore;

	private int cars;
	private int presentCars;
	private int carScr;

	private int weapons;
	private int presentWeapons;
	private int weaponScr;

	private int veh;
	private int presentveh;
	private int vehScr;

	private bool levelComp;
	public GameObject help;
	public bool so;




	void Start () {
		
		so = true;
		Time.timeScale = 1;
		gameManager = FindObjectOfType<GameManager> ();
		i = GameObject.FindGameObjectsWithTag ("Bridge").Length;   						//total Bridge pieces
		players = GameObject.FindGameObjectsWithTag ("Player").Length;  
		cars = GameObject.FindGameObjectsWithTag ("Car").Length;           //no of stickmans
		weapons = GameObject.FindGameObjectsWithTag ("Weapon").Length;
		veh= GameObject.FindGameObjectsWithTag ("Vehicle").Length;
		target.text = targetScore.ToString ();
		levelCompTarget.text = targetScore.ToString ();
		levelFailTarget.text = targetScore.ToString ();
		levelFail.SetActive (false);
		levelCompleted.SetActive (false);
		levelComp = false;

	}
	

	void Update () {

		bombsCount = GameObject.FindGameObjectsWithTag ("Bomb").Length;
		//Debug.Log (GameObject.FindGameObjectsWithTag("Bomb").Length);
		active_Players = GameObject.FindGameObjectsWithTag ("Player").Length;       // alive players
		player_Score = (players - active_Players) * 50;                               //Score through Players

		presentCars = GameObject.FindGameObjectsWithTag ("Car").Length;             //Activated Cars 
		carScr = (cars - presentCars)*70;                                           //Calculate car score

		b=  GameObject.FindGameObjectsWithTag ("Bridge").Length;                     //Activated Bridges
		score_Hint = (i - b)*mul_Value;

		presentWeapons = GameObject.FindGameObjectsWithTag ("Weapon").Length;             //Activated Weapons
		weaponScr = (weapons - presentWeapons)*95;                                           //Calculate Weapon score

		presentveh = GameObject.FindGameObjectsWithTag ("Vehicle").Length;             //Activated Veh 
		vehScr = (veh - presentveh)*80;                                           //Calculate Veh score

		bombs.text = gameManager.bombsOnHand.ToString ();                                          
		unUsedBombs = gameManager.bombsOnHand ;
		bombScore = unUsedBombs * 100;                                                //score through un used bombs

		curr_score = score_Hint + player_Score+bombScore+carScr+weaponScr+vehScr;                            
		score.text = curr_score .ToString ();
		levelCompScr.text = curr_score .ToString ();
		levelFailScr.text = curr_score .ToString ();

		if (curr_score >= targetScore) {
			Invoke ("LevelCompletedMethod",1);
			levelComp = true;

		}
		if ((bombsCount == 0)&&(curr_score <=targetScore)&&(gameManager._ready == true)){
			Invoke ("LevelFailedMethod",3);
		}
	}


	public void NextScene(){
		
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	}
	public void Retry(){

		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}
	public void Home(){

		SceneManager.LoadScene ("MainMenu");

	}
	public void LevelCompletedMethod(){
		PlayerPrefs.SetInt (SceneManager.GetActiveScene().name,1);
		levelCompleted.SetActive (true);
	}
	public void LevelFailedMethod(){
		if (levelComp == false) {
			so = false;
			levelFail.SetActive (true);
		}
	}
	public void PauseMenu(){
		so = false;

		pauseMenu.SetActive (true);
		Time.timeScale = 0;

	}
	public void Resume(){
		so = true;
		
		Time.timeScale = 1;
		pauseMenu.SetActive (false);

	}
}
