using UnityEngine;
using System.Collections;

public class camcontroller : rands {


	public override void OnTriggerEnter (Collider other)
	{

	}


	// Use this for initialization
	void Start () {

	}


	void testspeedcontrol()
	{
		if(up)
		{
			if(transform.position.y>25)
			{up=!up;}
		}
		else
		{
			if (transform.position.y<-10)
			{up=!up;}
		}
		
		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
		else
			transform.Translate (Vector3.down * yspeed * Time.deltaTime,Space.World);
		
		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
	void Update()
	{
		testspeedcontrol();

	}

}
