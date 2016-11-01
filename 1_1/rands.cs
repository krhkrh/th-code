using UnityEngine;
using System.Collections;

public class rands : basic {

	public bool up=false;
	public float yspeed=3;
	public int type=0;
	public bool clockwise=true;
	public float wspeed= 45;

	public override void Awake ()
	{

	}

	// Use this for initialization
	void Start () {

	}

	public override void OnTriggerEnter (Collider other)
	{
		if(type==0)
		{
			base.OnTriggerEnter(other);
		}
		else if(type==1)
		{
			if(other.gameObject.tag=="Player")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
		}
		else if(type==2)
		{
			if(other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
		}
	}


	// Update is called once per frame
	void Update () {
		base.checkbound ();

		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
		else
			transform.Translate (Vector3.down * yspeed * Time.deltaTime,Space.World);

		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
