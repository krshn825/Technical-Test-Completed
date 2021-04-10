using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TrignometricScale : MonoBehaviour
{
    public Vector3 Scale;
    public Vector3 ScaleFrequency;
	private Vector3 NewScale;
	private Vector3 startScale;
	bool ScaleOn;
	bool ScaleOff;
	private Vector3 buttonPos;

    void Start()
    {
		startScale = transform.localScale;
		ScaleOn = true;
		buttonPos = gameObject.transform.localScale;
	
    }
    void Update() {

		if (ScaleOff == true) {
			ScaleOn = false;
		}
	if(ScaleOn == true){
	   NewScale.x = startScale.x + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.x) * Scale.x;
	   NewScale.y = startScale.y + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.y) * Scale.y;
	   NewScale.z = startScale.z + Mathf.Sin(Time.timeSinceLevelLoad * ScaleFrequency.z) * Scale.z;
	   transform.localScale = new Vector3(NewScale.x, NewScale.y, NewScale.z);
			}	
    }

	public void tweenOn(){
		
		ScaleOn = true;
	}
	public void tweenOff(){
		gameObject.transform.localScale=buttonPos ;
		ScaleOff = true;
		ScaleOn = true;


	}

}
