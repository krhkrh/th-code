using UnityEngine;
using System.Collections;

public class rocketshooter : shooterbasic {

	GameObject dragonrocket;
	public float angle=0;

	public override void Awake ()
	{
		base.Awake ();
		dragonrocket= Resources.Load("rocketparent",typeof (GameObject)) as GameObject;
	}

	// Use this for initialization
	public override IEnumerator mainroute ()
	{
		GameObject bb;

		bb = (GameObject)Instantiate (dragonrocket, transform.position*1.1f ,Quaternion.Euler(0,angle+180,180) );
		bb.AddComponent ("rocketline");
		bb.GetComponent<rocketline> ().type=1;
		yield return new WaitForSeconds(0.1f);
		halt();
	}
	

}
