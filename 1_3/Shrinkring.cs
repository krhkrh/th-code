using UnityEngine;
using System.Collections;

public class Shrinkring : cylincircle {

	bool spawned = false;


	GameObject shooter3,b3_v,point;
	public float shrinktime = 1.0f;
	public float shrinkratio=0.9f;

	public int status=1;
	public int health=35;

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

	public override void Awake ()
	{
		GameObject bb;
		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;		
		point = Resources.Load ("point cube", typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;
		bb = (GameObject)Instantiate (shooter3, transform.position , Quaternion.identity);
		bb.AddComponent("Shooter3_5");

		bb.transform.parent=this.transform;
	}

	void spawnright()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("rightbranch");
		bb.GetComponent<rightbranch> ().type = 1; 
		bb.GetComponent<rightbranch> ().tag = "enemy";

		bb.GetComponent<rightbranch> ().up = false;
		bb.GetComponent<rightbranch> ().yspeed = -3f;
		bb.GetComponent<rightbranch> ().clockwise = false;
		bb.GetComponent<rightbranch> ().wspeed= 45;

	}

	void spawnleft()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (b3_v, transform.position, Quaternion.LookRotation(Vector3.up));
		bb.AddComponent("leftbranch");
		bb.GetComponent<leftbranch> ().type = 1; 
		bb.GetComponent<leftbranch> ().tag = "enemy";

		bb.GetComponent<leftbranch> ().up = false;
		bb.GetComponent<leftbranch> ().yspeed = -3.0f;
		bb.GetComponent<leftbranch> ().clockwise = true;
		bb.GetComponent<leftbranch> ().wspeed= 45;
	}

	void datasetting()
	{
		speed = 3;
		radius = 3;
		wspeed = 0;
		yspeed = 2.5f;
		shrinktime = 1.0f;
		shrinkratio = 0.9f;
		baseYspeed = 2.5f;
		t= -90;


	}


	public IEnumerator shrink()
	{
		while(radius>0.5f)
		{
			radius*= shrinkratio;
			yield return new WaitForSeconds(shrinktime);
		}

		halt();
	}

	public override IEnumerator trianglespeed ()
	{
		datasetting();
		yield return new WaitForSeconds(4.0f);

		while(yspeed>-6)
		{
			yspeed -= 0.5f;
			yield return new WaitForSeconds(0.2f);

		}


		StartCoroutine(shrink());

		while(radius>0.5f)
		{
			yspeed=radius*speed*Mathf.Sin(t*Mathf.Deg2Rad)+baseYspeed;
			wspeed=-(radius*speed*5*Mathf.Cos(t*Mathf.Deg2Rad)+baseWspeed);
			yield return new WaitForSeconds(0.2f);
			t+=15;

			if(spawned==false && transform.position.y<-0f)
			{
				if(!clockwise)
				{
					spawnright();

				}
				else
				{
					spawnleft();

				}
				spawned = true;
			}


		}
	}
}
