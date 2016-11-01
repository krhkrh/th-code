using UnityEngine;
using System.Collections;

public class shellfish : rands {

	public int colortype;
	public bool shelltype = true;
	GameObject shooter3;

	public override void Awake ()
	{
		base.Awake ();
		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
	}



	// Use this for initialization
	void Start () {
		GameObject bb;
		up=shelltype;
		wspeed=0;
		yspeed = 5.0f;
		if(shelltype)
		{
			bb = (GameObject)Instantiate (shooter3, transform.position, Quaternion.identity);
			bb.AddComponent("Shooter3_4");
			bb.GetComponent<Shooter3_4>().colortype = colortype;
			bb.transform.parent = transform;
		}
		else
		{
			bb = (GameObject)Instantiate (shooter3, transform.position, Quaternion.identity);
			bb.AddComponent("Shooter3_3");
			bb.GetComponent<Shooter3_3>().colortype = colortype;
			bb.transform.parent = transform;

		}
	}
	

}
