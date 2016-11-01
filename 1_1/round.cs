using UnityEngine;
using System.Collections;

public class round : basic {

	public bool clockwise=true;
	public int wspeed= 30;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		base.checkbound ();
		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
