using UnityEngine;
using System.Collections;

public class oneup : straightline {


	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.gameObject.SendMessage("extend",1,SendMessageOptions.DontRequireReceiver);
			halt();
		}
		
	}


	IEnumerator ac()
	{
		while(transform.position.y<15&&transform.position.y>-2)
		{
			yspeed+=2;
			yield return new WaitForSeconds(0.2f);
		}
	}
	
	void acce(bool u)
	{
		up=u;
		StartCoroutine(ac());
	}

}
