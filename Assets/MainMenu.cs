using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

	public void Load_MenuPag(){	
		SceneManager.LoadScene ("MainMenu");
	}

	public void Load_StorePage(){
		SceneManager.LoadScene ("StorePage");
	}

	public void Load_LevelPage(){
		SceneManager.LoadScene ("LevelMenu");
	}
}
