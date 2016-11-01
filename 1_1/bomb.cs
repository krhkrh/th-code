using UnityEngine;
using System.Collections;

public class bomb : basic {

	public float yspeed=2.5f;

	// Use this for initialization
	void Start () {

		setvolume();
		setdamage(30);

	}


	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}

	// Update is called once per frame
	void Update () {
			base.checkbound();

		transform.Translate (Vector3.down*yspeed*Time.deltaTime);
			
	}

	void OnTriggerStay(Collider other)
	{
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray")
		{
			Destroy(other.gameObject);
		}
	}

	IEnumerator blast()
	{

		yield return new WaitForSeconds(2.0f);

		Destroy(gameObject);

	}


}
