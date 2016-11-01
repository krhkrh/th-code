using UnityEngine;
using System.Collections;

public class fairy2_5 :fairy1_1 {


	GameObject shooter2;
	// Use this for initialization
	void Start () {
		health=10;
		yspeed=2.5f;
	}
	public override void remove ()
	{
		base.remove ();
		StartCoroutine(revenge());
	}

	public override void Awake ()
	{
		base.Awake ();
		shooter2= Resources.Load("shooter2", typeof(GameObject)) as GameObject;

	}

	IEnumerator revenge()
	{
		GameObject bb;
		yield return new WaitForSeconds(8.0f);
		animation.CrossFade("instantattk",0.3f);
		yield return new WaitForSeconds(0.3f);
		bb = (GameObject)Instantiate (shooter2, transform.position-transform.forward*3 , Quaternion.identity);
		bb.AddComponent("dirshooter");
		yield return new WaitForSeconds(1.0f);
		animation.CrossFade("move",0.5f);
	}

	// Update is called once per frame
	new void Update () {
		base.checkbound();
		if(status==1)
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);
		else if(status==-1)
		{
			transform.Translate (escape * Time.deltaTime,Space.World);
			
		}
	}
}
