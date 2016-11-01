using UnityEngine;
using System.Collections;

public class key2_6 : rands {

	public AudioClip clips;
	GameObject myscude;
	
	void Awake()
	{
		myscude=GameObject.FindGameObjectWithTag("myscube");
	}
	
	
	
	// Use this for initialization
	void Start () {
		audio.volume=Control.volume;
		
	//	yspeed=0;
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
	

	void moveup()
	{
		gameObject.transform.Translate(Vector3.up*21);
	}
	
	void movedown()
	{
		gameObject.transform.Translate(Vector3.down*21);
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.y<-3)
			moveup ();
		
		if(transform.position.y>19)
			movedown();


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
