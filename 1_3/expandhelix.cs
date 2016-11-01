using UnityEngine;
using System.Collections;

public class expandhelix : cylincircle {

	float expandtime = 1.0f , expandratio = 1.1f;

	public int expandType =0;
	public void datasetting(int t=0)
	{
		if(t==0)
		{
		speed = 3;
		radius = 0.5f;
		wspeed = 0;
		yspeed = 0f;
		expandtime = 1.0f;
		expandratio = 1.1f;
		baseYspeed = 0f;
		}
		if(t==1)
		{
			speed = 3;
			radius = 1f;
			wspeed = 0;
			yspeed = 0f;
			expandtime = 1.0f;
			expandratio = 1.1f;
			baseYspeed = 0f;
		}
		if(t==2)
		{
			speed = 3;
			radius = 0.5f;
			wspeed = 0;
			yspeed = 0f;
			expandtime = 1.0f;
			expandratio = 1.5f;
			baseYspeed = 0f;
		}
		if(t==3)
		{
			speed = 3;
			radius = 1f;
			wspeed = 0;
			yspeed = 0f;
			expandtime = 1.0f;
			expandratio = 1.5f;
			baseYspeed = 0f;
		}
	}

	public IEnumerator expand()
	{
		while(speed<40)
		{
			speed*= expandratio;

			yield return new WaitForSeconds(expandtime);
		}

		halt();
	}


	public override IEnumerator trianglespeed ()
	{
		datasetting(expandType);
		StartCoroutine(expand());

		while(true)
		{
			yspeed=radius*speed*Mathf.Sin(t*Mathf.Deg2Rad)+baseYspeed;
			wspeed=-(radius*speed*5*Mathf.Cos(t*Mathf.Deg2Rad)+baseWspeed);
			t+=15;
			yield return new WaitForSeconds(0.2f);
		}

	}




}
