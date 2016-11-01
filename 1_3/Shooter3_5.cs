using UnityEngine;
using System.Collections;

public class Shooter3_5 : shooterbasic {
	GameObject bt2_v;
	public override void Awake ()
	{
		base.Awake ();
		bt2_v=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
	}




	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int i=1;
		while(true)
		{
			audio.Play();
			bb = (GameObject)Instantiate (bt2_v, transform.position, Quaternion.identity);
			bb.AddComponent("rands");
			bb.GetComponent<rands> ().up=false;
			bb.GetComponent<rands> ().type = 1; 
			bb.GetComponent<rands> ().yspeed=2.5f;
			bb.GetComponent<rands> ().wspeed=0f;
			i++;
			yield return new WaitForSeconds(0.2f);

		}



	}
}