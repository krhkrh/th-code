using UnityEngine;
using System.Collections;

public class playermove : straightline {

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.gameObject.SendMessage("extendmove",1,SendMessageOptions.DontRequireReceiver);
		}
		
	}



}
