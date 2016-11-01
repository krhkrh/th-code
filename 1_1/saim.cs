using UnityEngine;
using System.Collections;

public class saim : basic {

	public GameObject target;

	public float speed=10.0f;

	public Vector3 aim=Vector3.zero;
	public float rate=0.5f;
	public int type=0;
	public int Threshold=5;

	void Awake()
	{
		target=GameObject.FindGameObjectWithTag("Player");
	}


	// Use this for initialization
	void Start () {


		StartCoroutine(startaim());


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
		base.checkbound();
		transform.Translate (aim*Time.deltaTime,Space.World);
	}

	IEnumerator startaim()
	{

		int i=0;
		while(i<Threshold)
		{
			aim*=rate;
			
			i++;
			yield return new WaitForSeconds(0.5f);
		}


		aim = target.transform.position- gameObject.transform.position;
		aim = Vector3.Normalize(aim)*speed;
		transform.rotation = Quaternion.LookRotation((target.transform.position-transform.position).normalized);

		yield return new WaitForSeconds(10.0f);
		Destroy(gameObject);
	}

}
