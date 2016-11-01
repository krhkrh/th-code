using UnityEngine;
using System.Collections;

public class oneup2_10 : rands {

	// Use this for initialization
	void Start () {
	
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
	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.gameObject.SendMessage("extend",1,SendMessageOptions.DontRequireReceiver);
			halt();
		}
		
	}
}
