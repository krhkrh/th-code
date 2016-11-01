using UnityEngine;
using System.Collections;

public class rands_spawn : rands {


	GameObject bice;

	public int angle;
	public AudioClip clip;

	void Awake()
	{
		bice=Resources.Load("bice",typeof(GameObject)) as GameObject;
	}

	// Use this for initialization
	void Start () 
	{
		StartCoroutine(spawn());
		audio.volume=Control.volume;
		audio.rolloffMode= AudioRolloffMode.Logarithmic;
	}

	IEnumerator spawn()
	{
		int i=0;
		GameObject bb;
		int bound=6;
		float wspeed,yspeed=0;
		Vector3 v= Vector3.up;
		Vector3 axis= new Vector3(transform.position.x,0,transform.position.z);
		bool c=false;
		v=Quaternion.AngleAxis(10*(angle-3),axis)*v;


		while(transform.position.y>0&&transform.position.y<18)
		{
				axis= new Vector3(transform.position.x,0,transform.position.z);
				if(c!=false)
				{
					audio.PlayOneShot(clip);
				}
				for(i=0;i<bound;i++)
				{
					
					wspeed= 10*Mathf.Sin(Mathf.Deg2Rad*(angle-3)*60/bound);
					yspeed= 2*Mathf.Cos(Mathf.Deg2Rad*(angle-3)*60/bound);
					
					
					bb = (GameObject)Instantiate (bice,gameObject.transform.position , Quaternion.LookRotation(v.normalized));
					bb.AddComponent ("rands");
					bb.GetComponent<rands> ().clockwise = true;
					bb.GetComponent<rands> ().yspeed = yspeed;
					bb.GetComponent<rands> ().wspeed = wspeed;
					bb.GetComponent<rands> ().type=1;
					angle++;
					v=Quaternion.AngleAxis(10,axis)*v;
				}
			c=true;
			yield return new WaitForSeconds(1.0f);
		}
	}


	// Update is called once per frame

	void Update () {
		base.checkbound ();
		
		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
		else
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);
		
		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
