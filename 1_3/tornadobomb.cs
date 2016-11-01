using UnityEngine;
using System.Collections;

public class tornadobomb :staticbullet {

	GameObject shooter3;
	bool readytoblow=false;


	public override void Awake ()
	{

		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
	}

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			halt();
		}
		else if(other.gameObject.tag == "base")
		{
			readytoblow=true;
		}
	}


	void Update()
	{
		transform.Translate(new Vector3(0,0,1)*Time.deltaTime);
	}


	void OnDestroy() {

		if(readytoblow ==true)
		{

			Vector3 v1 =  transform.position;
			Vector3 v2 = new Vector3(v1.x,0,v1.z).normalized*10;
			v1 = new Vector3(0,v1.y,0); 

			GameObject bb;

			bb = (GameObject)Instantiate (shooter3, v2+v1, Quaternion.identity);
			bb.AddComponent("shooter3_10");

		}

	}




}
