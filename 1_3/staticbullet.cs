using UnityEngine;
using System.Collections;

public class staticbullet : basic {

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);

		}
	}




	public override void Awake ()
	{}
}
