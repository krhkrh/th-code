using UnityEngine;
using System.Collections;

public class spawn_rands : rands {

	// Use this for initialization
	GameObject dir;

	bool stop=false;
	public AudioClip clip;

	void Awake()
	{
		dir=Resources.Load("dirice",typeof(GameObject)) as GameObject;
	}


	void Start () {
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Logarithmic;
		StartCoroutine(spawn());
	}

	IEnumerator spawn()
	{
		GameObject bb;
		Vector3 scale=new Vector3(0.3f,0.3f,0.3f);
		while(!stop)
		{
			yield return new WaitForSeconds(1.0f);
			audio.PlayOneShot(clip);
			bb = (GameObject)Instantiate (dir, gameObject.transform.position, Quaternion.Euler(90,0,0));
			bb.AddComponent ("straightline");
			bb.GetComponent<straightline> ().up=false;
			bb.GetComponent<straightline> ().yspeed = 10.0f;
			bb.GetComponent<straightline> ().type=1;
			bb.transform.localScale=scale;


		
			bb = (GameObject)Instantiate (dir, gameObject.transform.position, Quaternion.Euler(90,0,0));
			bb.AddComponent ("straightline");
			bb.GetComponent<straightline> ().up=false;
			bb.GetComponent<straightline> ().yspeed = 7.0f;
			bb.GetComponent<straightline> ().type=1;
			bb.transform.localScale=scale;

			bb = (GameObject)Instantiate (dir, gameObject.transform.position, Quaternion.Euler(90,0,0));
			bb.AddComponent ("straightline");
			bb.GetComponent<straightline> ().up=false;
			bb.GetComponent<straightline> ().yspeed = 5.0f;
			bb.GetComponent<straightline> ().type=1;
			bb.transform.localScale=scale;

			if(transform.position.y<0)
			{
				stop=true;
			}
		}
	}


	// Update is called once per frame
	void Update () {
		base.checkbound ();
		
		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime);
		else
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime);
		
		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
