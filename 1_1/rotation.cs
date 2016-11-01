using UnityEngine;
using System.Collections;

public class rotation : basic {

	GameObject bullet;

	public float wspeed=45.0f;
	int count=0;
	Vector3 direction;
	public bool type=false;
	public float yspeed=1.0f;
	public AudioClip clip;
	// Use this for initialization
	GameObject ab;
	void Awake(){
		bullet = Resources.Load("b2_r", typeof(GameObject)) as GameObject;
		}

	void Start () {
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Logarithmic;
	}
	
	// Update is called once per frame
	void Update () {
		base.checkbound ();
		if(type)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);

		transform.Translate(-Vector3.up * yspeed * Time.deltaTime);
		count++;
		if (count == 100) 
		{

			audio.PlayOneShot(clip);
			ab=(GameObject)Instantiate (bullet,transform.position,Quaternion.identity);
			ab.AddComponent ("splitaim");
			ab.GetComponent<splitaim>().type=true;

			ab=(GameObject)Instantiate (bullet,transform.position,Quaternion.identity);
			ab.AddComponent ("splitaim");
			ab.GetComponent<splitaim>().type=false;

			count=0;
		}
	}
}
