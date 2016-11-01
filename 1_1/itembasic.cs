using UnityEngine;
using System.Collections;

public class itembasic : straightline{

	
	public int itemtype=0;   // 0 power cube ;  1  point cube 


	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			if(itemtype==0)
				other.gameObject.SendMessage("incpower",1,SendMessageOptions.DontRequireReceiver);

			else if(itemtype==1)
				other.gameObject.SendMessage("incpoint",10,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}

	}




	IEnumerator speedchange()
	{
		while(yspeed<10)
		{
			yspeed++;
			yield return new WaitForSeconds(0.1f);
		}

	}

	// Use this for initialization
	void Start () 
	{
		audio.volume= Control.volume;
		wspeed=60.0f;
		StartCoroutine(speedchange());


	}
	

}
