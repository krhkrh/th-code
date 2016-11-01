using UnityEngine;
using System.Collections;

public class rocketcollider : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		

			if(other.gameObject.tag=="Player")
			{
				other.gameObject.SendMessage("applydamage",30,SendMessageOptions.DontRequireReceiver);
				
			}

			if(other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
			{
				other.gameObject.SendMessage("applydamage",210,SendMessageOptions.DontRequireReceiver);
				
			}

	}

}
