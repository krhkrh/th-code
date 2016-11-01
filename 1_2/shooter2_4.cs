using UnityEngine;
using System.Collections;

public class shooter2_4 : shooterbasic {

	GameObject yy;
	GameObject player;

	public override void Awake ()
	{
		base.Awake ();
		yy=Resources.Load("passingball",typeof(GameObject)) as GameObject;
		player= GameObject.FindGameObjectWithTag("Player");

	}

	public override IEnumerator mainroute ()
	{
		int i=0,factor=-5;
		GameObject bb;
		Vector3 spawn=Vector3.zero;
		while(i<10)
		{
			spawn= new Vector3 (player.transform.position.x*factor,player.transform.position.y, player.transform.position.z*factor);
			bb = (GameObject)Instantiate (yy, spawn, Quaternion.LookRotation(player.transform.position));
			bb.AddComponent("saim");
			bb.GetComponent<saim> ().Threshold=0;
			yield return new WaitForSeconds(3.0f);
			i++;
		}


		halt();

	}


}
