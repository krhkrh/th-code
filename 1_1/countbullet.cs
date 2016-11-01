using UnityEngine;
using System.Collections;

public class countbullet : basic {

	public float threshold=2.0f;
	public float wspeed=50;
	public float yspeed=10;
	public float ydown=5;
	public float wdown=25;
	public bool up=false;
	public bool clockwise=false;


	// Use this for initialization
	void Start () {
		StartCoroutine(countdown());
	}
	
	// Update is called once per frame
	void Update () 
	{
		base.checkbound();

		if(up)
			transform.Translate (Vector3.up*yspeed*Time.deltaTime);
		else
			transform.Translate (Vector3.down*yspeed*Time.deltaTime);

		if(clockwise)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}

	IEnumerator countdown()
	{
		int i=0;
		while(i<threshold)
		{

			if(yspeed>0)
				yspeed-=ydown;
			
			if(wspeed>0)
				wspeed-=wdown;
			i++;
			yield return new WaitForSeconds(threshold);
		}
		Destroy(gameObject);
	}
}
