using UnityEngine;
using System.Collections;

public class cogbehavior : rands {

	public bool cogtype =true;

	void datasetting()
	{
		if(cogtype == true)
		{
			clockwise =true;
			up=true;

		}
		else
		{
			clockwise =false;
			up= false;
		}
		type=1;
		yspeed=2;
	}


	// Use this for initialization
	void Start () {
		datasetting();
		StartCoroutine(speedcontrol());
	}
	
	IEnumerator speedcontrol()
	{
		yield return new WaitForSeconds(1.0f);

		while(yspeed>0.5f)
		{
			yspeed*=0.5f;
			yield return new WaitForSeconds(0.5f);
		}
		yspeed = 0;

		yield return new WaitForSeconds(3.0f);
		yspeed =0.5f;
		while(yspeed<10)
		{
			yspeed +=0.5f;
			wspeed --;
			yield return new WaitForSeconds(0.2f);
		}
		yspeed =10;

	}


}
