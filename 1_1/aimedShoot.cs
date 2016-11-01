using UnityEngine;
using System.Collections;

public class aimedShoot : basic {


	public GameObject target;
	public int duration=4;
	Vector3 direction,rx;
	public bool type = false;
	public int laps=0;
	float yspeed=0,wspeed=0;
	public int deflection=0;
	public int damagetype=0;
	public bool tytype=true;


	void Awake()
	{
		target=GameObject.FindGameObjectWithTag("Player");
	}

	IEnumerator countdown()
	{
		yield return  new WaitForSeconds(10.0f);
		Destroy(gameObject);
	}

	public override void OnTriggerEnter (Collider other)
	{
		if(damagetype==0)
		{
			base.OnTriggerEnter(other);
		}
		else if(damagetype==1)
		{
			if(other.gameObject.tag=="Player")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
		}
		else if(damagetype==2)
		{
			if(other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
		}
	}

	// Use this for initialization
	public virtual void  Start () {

		StartCoroutine(countdown());
		direction =new Vector3 (transform.position.x, 0, transform.position.z);

		float angle=Quaternion.LookRotation(direction).eulerAngles.y;

		direction = -target.transform.forward;
		direction.y = 0;
		float headingAngle = Quaternion.LookRotation(direction).eulerAngles.y;

		if(tytype==false)
		{
			if(type==false)
				wspeed = headingAngle-angle;

			else
				wspeed = angle-headingAngle;


			if (wspeed <= 0)
				wspeed = wspeed + 360;

		}
		else
		{
			if(Mathf.Abs(angle- headingAngle) > Mathf.Abs(headingAngle-angle))
			{
				wspeed = angle-headingAngle;
				type=true;
			}
			else
			{
				wspeed = headingAngle-angle;
				type=false;
			}
	//		if(wspeed<0)
	//			wspeed = -wspeed;
		}




		float position = Quaternion.LookRotation(transform.forward).eulerAngles.y;



		wspeed = (wspeed+360*laps) / duration;
		yspeed = (transform.position.y - target.transform.position.y)/duration;


		wspeed= wspeed+deflection*(wspeed+10);
		yspeed= yspeed - Mathf.Abs(deflection)*0.7f*yspeed;



		rx=new Vector3(Mathf.Atan2( yspeed,Mathf.Deg2Rad*wspeed*10)*Mathf.Rad2Deg,0,0);

		if(type==false)
			transform.Rotate(Vector3.up*(90+position+angle)+rx);
		if(type==true)
			transform.Rotate(Vector3.down*(90+position-angle)+rx);




	}
	
	// Update is called once per frame
	public virtual void Update () 
	{

		base.checkbound ();
		transform.Translate (Vector3.down*yspeed*Time.deltaTime,Space.World);

			if (type == false)
							transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
			else 
				transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);

			


	}
}
