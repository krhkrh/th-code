using UnityEngine;
using System.Collections;

public class dirshooter : shooterbasic {


	GameObject elipse;
	public override void Awake ()
	{
		base.Awake ();
		elipse= Resources.Load("elipse_indigo", typeof(GameObject)) as GameObject;
	}
	// Use this for initialization

	public override IEnumerator mainroute ()
	{
		GameObject bb;
		audio.Play ();
		bb = (GameObject)Instantiate (elipse, transform.position , Quaternion.identity);
		bb.AddComponent("saim");
		bb.GetComponent<saim> ().speed=5;
		bb.GetComponent<saim> ().Threshold=0;
		yield return new WaitForSeconds(0.1f);
		bb = (GameObject)Instantiate (elipse, transform.position , Quaternion.identity);
		bb.AddComponent("saim");
		bb.GetComponent<saim> ().speed=10;
		bb.GetComponent<saim> ().Threshold=0;
		bb.transform.localScale= new Vector3(0.7f,0.7f,0.7f);
		yield return new WaitForSeconds(0.1f);
		bb = (GameObject)Instantiate (elipse, transform.position , Quaternion.identity);
		bb.AddComponent("saim");
		bb.GetComponent<saim> ().speed=15;
		bb.GetComponent<saim> ().Threshold=0;
		bb.transform.localScale= new Vector3(0.5f,0.5f,0.5f);


		halt();
	}
}
