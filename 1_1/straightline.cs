using UnityEngine;
using System.Collections;

public class straightline : basic {

	public bool up=false;
	public float yspeed=5;
	public float wspeed=30.0f;
	public int type=0;

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
	public virtual void Update () {
		base.checkbound ();
		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
		else
			transform.Translate (Vector3.down * yspeed * Time.deltaTime,Space.World);

		transform.Rotate(Vector3.down *wspeed * Time.deltaTime,Space.World);
	}
}
