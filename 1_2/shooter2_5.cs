using UnityEngine;
using System.Collections;

public class shooter2_5 : shooterbasic {

	// Use this for initialization
	float wspeed=90;
	float cooldown=5;

	GameObject[] bisolid= new GameObject[5];



	public override void Awake ()
	{
		base.Awake ();

		bisolid[0]= Resources.Load("bisolid_r",typeof(GameObject)) as GameObject;
		bisolid[1]= Resources.Load("bisolid_v",typeof(GameObject)) as GameObject;
		bisolid[2]= Resources.Load("bisolid_y",typeof(GameObject)) as GameObject;
		bisolid[3]= Resources.Load("bisolid_g",typeof(GameObject)) as GameObject;
		bisolid[4]= Resources.Load("bisolid_b",typeof(GameObject)) as GameObject;

	}

	public override IEnumerator mainroute ()
	{
		int i=0,j=0;
		GameObject bb;
		for(i=0;i<7;i++)
		{
			for(j=0;j<20;j++)
			{
				audio.Play();
				bb = (GameObject)Instantiate (bisolid[j%5],transform.position, Quaternion.Euler(90,0,0));
				bb.AddComponent ("straightline");
				bb.GetComponent<straightline> ().up=true;
				bb.GetComponent<straightline> ().yspeed=2.5f;
				bb.transform.localScale=Vector3.one*0.5f;
				yield return new WaitForSeconds(0.1f);
			}
			yield return new WaitForSeconds(cooldown);
			cooldown-=0.6f;
		}

		halt();
	}


	
	// Update is called once per frame
	public override void Update () {
		transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
	}
}
