using UnityEngine;
using System.Collections;

public class rightbranch : cylincircle {

	public float shrinktime = 1.0f;
	public float shrinkratio=0.9f;

	public bool spawned = false;
	public GameObject b3_v,shooter3,point;

	public int health=35;
	public int status=1;
	
	public override void Start ()
	{
		StartCoroutine(detectstarttime());
	}

	IEnumerator detectstarttime()
	{
		while(transform.position.y>0)
		{
			yield return new WaitForSeconds(0.5f);

		}
		StartCoroutine(trianglespeed());

	}



	public override void Awake ()
	{

		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;

		point = Resources.Load ("point cube", typeof(GameObject)) as GameObject;

		GameObject bb;
		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;
		
		bb = (GameObject)Instantiate (shooter3, transform.position , Quaternion.identity);
		bb.AddComponent("Shooter3_5");
		bb.transform.parent=this.transform;



	}




	public	virtual void datasetting()
	{
		up = false;
		yspeed = -3f;
		clockwise = false;
		wspeed= 45;
		t= 200;
		radius = 3;
		shrinktime = 1.0f;
		shrinkratio = 0.9f;
		speed=3;
		baseWspeed=0;
		baseYspeed=2.5f;

	}

	public void applydamage(int d)
	{
		if(status==1)
		{
			health-=d;
			if(health<=0)
			{
				status=0;
				remove();
			}
		}
	}

	public void remove()
	{
		GameObject bb;
		bb = (GameObject)Instantiate (point, transform.position, Quaternion.identity);
		bb.AddComponent("itembasic");
		bb.GetComponent<itembasic> ().yspeed=-10;
		bb.GetComponent<itembasic> ().up=false;
		bb.GetComponent<itembasic> ().itemtype=1;

		Destroy(gameObject);
	}

	public IEnumerator shrink()
	{
		while(radius>0.5)
		{
			radius*= shrinkratio;
			yield return new WaitForSeconds(shrinktime);
		}
		
		halt();
	}

	void spawnrightleft()
	{
		GameObject bb;

		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("Shrinkring");
		bb.GetComponent<Shrinkring> ().type = 1; 
		bb.GetComponent<Shrinkring> ().tag = "enemy";

	}

	void spawnrightright()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("rightbranch");
		bb.GetComponent<rightbranch> ().type = 1; 
		bb.GetComponent<rightbranch> ().tag = "enemy";
	}

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
				
			//	spawnrightright();
				spawned=true;
				
			}
		}
	}
}
