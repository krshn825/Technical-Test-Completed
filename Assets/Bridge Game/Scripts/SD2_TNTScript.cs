using UnityEngine;

public class SD2_TNTScript : MonoBehaviour
{
	[SerializeField]
	private PointEffector2D thisPointEffecter;
	[SerializeField]
	private BoxCollider2D tntCollider;
	[SerializeField]
	private BoxCollider2D explosionRadiusCollider;
	public bool Explode;
	//public GameObject ExplosionEffect;
	[SerializeField]
	bool  blast;
	public GameObject trig;
	public GameObject reve;
	private GameManager gameManager;
	public GameObject dang;

	void Start(){
		gameManager = FindObjectOfType<GameManager> ();

	}

	private void Update()
	{
		
		//if (gameManager.blast == true) {
			if (Input.GetMouseButtonDown (0)) {
			
				if (gameManager._ready == true) {
					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);

					if (hit.collider != null) {
					//Debug.Log (hit.collider.name);
						if (hit.collider.name == this.gameObject.name) {
					//	Debug.Log (hit.collider.name);
						trig.gameObject.SetActive (true);
						reve.gameObject.SetActive (true);
						hit.collider.tag = "danger";
							Instantiate (dang, hit.collider.gameObject.transform.position, Quaternion.identity);

						//SoundController.instance.bomb.Play ();
						this.Explode = true;
						}
					}
				
				}
			}
		//}


		if (!this.Explode)
			return;
		//this.tntCollider.enabled = false;
		this.explosionRadiusCollider.enabled = true;
		this.thisPointEffecter.enabled = true;
		for (int i = 0; i < 1; i++) {
			if (blast != true) {
				
			//Object.Instantiate<GameObject> (this.ExplosionEffect, this.transform.position, Quaternion.identity);
				blast = true;
				this.GetComponent<SpriteRenderer>().enabled = false;
			}
		}

		this.GetComponent<SpriteRenderer>().enabled = false;
	
		Object.Destroy((Object) this.gameObject, 0.05f);

	}

//	private void OnTriggerEnter2D(Collider2D incoming)
//	{
//		if (incoming.tag.Contains ("danger")) {
//			this.Explode = true;
//
//		}
//
//	
//	}

	private void OnTriggerEnter2D(Collider2D incoming)
	{
		if (incoming.tag.Contains ("danger")) {
			this.Explode = true;

		}
		if (incoming.name.Contains("TNT"))
		{
			foreach (SD2_TNTScript component in incoming.GetComponents<SD2_TNTScript>())
				component.Explode = true;
		}

		if (!incoming.name.Contains("Allie"))
			return;
		foreach (Behaviour component in incoming.GetComponents<HingeJoint2D>())
			component.enabled = false;
		
	}
	void OnMouseDown(){
		//this.Explode = true;
	}

}
