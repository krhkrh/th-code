using UnityEngine;
using System.Collections;

public class IvyFruit : rands
{
	public int health=100,status=1;
	GameObject point,shooter3,shooter2;

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
	
	void dataSetting()
	{
		yspeed = 2;
		up = true;
		wspeed = 0;
		clockwise = true;
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
		point = Resources.Load ("point cube", typeof(GameObject)) as GameObject;
		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
		shooter2 = Resources.Load("shooter2", typeof(GameObject)) as GameObject;
	}
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(mainroutine());
	}


	IEnumerator mainroutine()
	{
		GameObject bb;
		int i=0,j=0;
		bool planted = false;
		if(Random.value>0.5f)
			j=-10;
		else j=10;
		dataSetting();

		bb = (GameObject)Instantiate (shooter3, transform.position, Quaternion.identity);
		bb.AddComponent("Shooter3_5");
		bb.transform.parent = this.transform;

		while(transform.position.y<19.0f)
		{
			wspeed=20* Mathf.Sin(Mathf.Deg2Rad*i*j);
			i++;
			if(i==72)
				i=0;

			if(wspeed>-5&&wspeed<5)
			{
				if(planted == false)
				{
					planted = true;
					bb = (GameObject)Instantiate (shooter2, transform.position, Quaternion.identity);
					bb.AddComponent("Shooter3_13");


				}
			}
			else{ planted = false;}
			yield return new WaitForSeconds(0.1f);
		}

	}



}

