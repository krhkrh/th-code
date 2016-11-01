using UnityEngine;
using System.Collections;

public class firework : rands {


	GameObject[] b2;
	public AudioClip clips;

	float speed=15.0f;

	void Awake()
	{
		b2=new GameObject[7];
		b2[0] = Resources.Load ("b2_r", typeof(GameObject)) as GameObject;
		b2[1] = Resources.Load ("b2_o", typeof(GameObject)) as GameObject;
		b2[2] = Resources.Load ("b2_y", typeof(GameObject)) as GameObject;
		b2[3] = Resources.Load ("b2_g", typeof(GameObject)) as GameObject;
		b2[4] = Resources.Load ("b2_c", typeof(GameObject)) as GameObject;
		b2[5] = Resources.Load ("b2_b", typeof(GameObject)) as GameObject;
		b2[6] = Resources.Load ("b2_v", typeof(GameObject)) as GameObject;

	}
	// Use this for initialization
	void Start () 
	{
		audio.rolloffMode = AudioRolloffMode.Linear;
		setvolume();
		StartCoroutine(countblow());
	}
	
	// Update is called once per frame
	void Update () 
	{
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



	IEnumerator countblow()
	{
		GameObject bb;
		int i=0,j=0;
		Vector3 va=Vector3.up*speed;
		va=Quaternion.Euler (30, 0, 0)*va;
		while(gameObject.transform.position.y>-2)
		{
			audio.PlayOneShot(clips);
			for(j=0;j<4;j++)
			{
				for(i=0;i<12;i++)
				{
					bb = (GameObject)Instantiate (b2[i%7], gameObject.transform.position , Quaternion.identity);
					bb.AddComponent ("saim");
					bb.GetComponent<saim> ().aim=va;
					va=Quaternion.Euler (0, 30, 0)*va;
				}
				va=Quaternion.Euler (30, 0, 0)*va;
			}

			yield return new WaitForSeconds(0.5f);
			va=Vector3.up*speed*4/5;
			va=Quaternion.Euler (30, 0, 0)*va;

			audio.PlayOneShot(clips);
			for(j=0;j<4;j++)
			{
				for(i=0;i<12;i++)
				{
					bb = (GameObject)Instantiate (b2[i%7], gameObject.transform.position , Quaternion.identity);
					bb.AddComponent ("saim");
					bb.GetComponent<saim> ().aim=va;
					va=Quaternion.Euler (0, 30, 0)*va;
				}
				va=Quaternion.Euler (30, 0, 0)*va;
			}

			va=Vector3.up*speed;
			va=Quaternion.Euler (30, 0, 0)*va;
			yield return new WaitForSeconds(4.0f);
		}
	}
	
}
