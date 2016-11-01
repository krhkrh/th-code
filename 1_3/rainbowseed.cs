using UnityEngine;
using System.Collections;

public class rainbowseed : rands {

	GameObject shooter3;

	public bool bossVersion = false;


	public override void Awake ()
	{
		base.Awake ();
		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;

	}




	IEnumerator startrainbow()
	{
		GameObject bb;

		while(transform.position.y>11)
		{
			yield return new WaitForSeconds(0.2f);
		}

		while(yspeed>0.5f)
		{
			yspeed *= 0.9f;
			yield return new WaitForSeconds(0.1f);
		}
		yspeed =0;

		bb = (GameObject)Instantiate (shooter3, transform.position , Quaternion.identity);
		bb.AddComponent("subshooter3_9");
		bb.GetComponent<subshooter3_9>().parent = gameObject;
		bb.transform.parent=this.transform;
		if(bossVersion)
		{
			bb.GetComponent<subshooter3_9>().bossVersion = true;
		}

		yield return new WaitForSeconds(1.0f);
	}

	public void endRoutine()
	{
		StartCoroutine(leaveScenne());
	}

	IEnumerator leaveScenne()
	{
		up=false;
		while(yspeed<5)
		{
			yspeed+=0.5f;
			yield return new WaitForSeconds(0.5f);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(startrainbow());
	}
	

}
