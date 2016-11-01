using UnityEngine;
using System.Collections;

public class cylincircle : rands {
	public int t=0;
	public float radius =1;
	public float baseWspeed = 0;
	public float baseYspeed = 0;
	public float speed = 5.0f;
	public float life = 10.0f;



	// Use this for initialization
	public virtual void Start () {
		StartCoroutine(trianglespeed());
	}
	
	// Update is called once per frame
	public IEnumerator fadeout()
	{
		while(life>0)
		{
			life--;
			yield return new WaitForSeconds(1.0f);
		}
		while(speed>0.1f)
		{
			speed *= 0.7f ;
			yield return new WaitForSeconds(0.5f);
		}

		halt();

	}



	public virtual IEnumerator trianglespeed()
	{

		while(radius>0.1f)
		{
			yspeed=radius*speed*Mathf.Sin(t*Mathf.Deg2Rad)+baseYspeed;
			wspeed=radius*speed*5*Mathf.Cos(t*Mathf.Deg2Rad)+baseWspeed;
			yield return new WaitForSeconds(0.2f);
			t+=15;
		}
    //test
	}
}
