using UnityEngine;
using System.Collections;

public class key : rands {


	public AudioClip clips;
	GameObject myscude;

	void Awake()
	{
		myscude=GameObject.FindGameObjectWithTag("myscube");
	}



	// Use this for initialization
	void Start () {
		audio.volume=Control.volume;


	}

	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.SendMessage("alarm",SendMessageOptions.DontRequireReceiver);
			myscude.SendMessage ("finish",SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}



	// Update is called once per frame
	void Update () {

		if(transform.position.y<-2)
			base.movetostart();

		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime);
		else
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime);
		
		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
