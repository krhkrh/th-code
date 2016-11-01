using UnityEngine;
using System.Collections;

public class leftbranch : rightbranch {


	public override void datasetting()
	{
		up = false;
		yspeed = -3.0f;
		clockwise = true;
		wspeed= 45;
		t= 200;
		radius = 3;
		shrinktime = 1.0f;
		shrinkratio = 0.9f;
		speed=3;
		baseWspeed=0;
		baseYspeed=2.5f;
	}

	public void spawnrightleft()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("Shrinkring");
		bb.GetComponent<Shrinkring>().clockwise = !clockwise;
		bb.GetComponent<Shrinkring> ().type = 1; 
		bb.GetComponent<Shrinkring> ().tag = "enemy";

	}

	public void spawnleftleft()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("leftbranch");
		bb.GetComponent<leftbranch> ().type = 1;
		bb.GetComponent<leftbranch> ().tag = "enemy"
			;	}

	public override IEnumerator trianglespeed ()
	{

		datasetting();
		yield return new WaitForSeconds(4.0f);
		
		
		StartCoroutine(shrink());
		while(radius>0.5f)
		{
			yspeed=radius*speed*Mathf.Sin(t*Mathf.Deg2Rad)+baseYspeed;
			wspeed=-(radius*speed*5*Mathf.Cos(t*Mathf.Deg2Rad)+baseWspeed);
			yield return new WaitForSeconds(0.2f);
			t+=15;


			if(t==275)
			{
				
				spawnrightleft();
			}
			if(spawned==false && transform.position.y<1.0f)
			{

				//	spawnleftleft();
					spawned=true;

			}
		}

	}
}
