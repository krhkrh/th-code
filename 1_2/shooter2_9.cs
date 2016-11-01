using UnityEngine;
using System.Collections;

public class shooter2_9 : shooterbasic {

	GameObject ray;
	GameObject player;
	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int i=0;
		Vector3 v;
		for(i=0;i<40;i++)
		{
			v= (player.transform.position- gameObject.transform.position).normalized;

			audio.Play();
			bb = (GameObject)Instantiate (ray , gameObject.transform.position , Quaternion.LookRotation(v));
			bb.AddComponent ("ray2_9");
			bb.transform.localScale= Vector3.one*0.5f;
			i++;

			yield return new WaitForSeconds(1.0f);
		}




	}

	public override void Awake ()
	{
		base.Awake ();
		ray=Resources.Load("rayparento",typeof(GameObject)) as GameObject;
		player= GameObject.FindGameObjectWithTag("Player");
	}

}
