using UnityEngine;
using System.Collections;

public class BlossomSeed : rands
{
	public int health=100,status=1;
	GameObject point,shooter3;


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
		yspeed = 5;
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
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(mainroutine());
	}

	IEnumerator mainroutine()
	{
		GameObject bb;
		float ratio = Random.Range(0.5f,0.9f);
		dataSetting();
		bb = (GameObject)Instantiate (shooter3, transform.position, Quaternion.identity);
		bb.AddComponent("Shooter3_5");
		bb.transform.parent = this.transform;

		while(transform.position.y<6)
		{
			yield return new WaitForSeconds(0.2f);
		}

		while(yspeed>0.2f)
		{
			yspeed*=ratio;
			yield return new WaitForSeconds(0.2f);
		}
		bb.GetComponent<Shooter3_5>().halt();
		yspeed = 0;

		bb = (GameObject)Instantiate (shooter3, transform.position, Quaternion.identity);
		bb.AddComponent("Shooter3_12");
		bb.GetComponent<Shooter3_12> ().parent = gameObject;
		bb.transform.parent = this.transform;

		yield return new WaitForSeconds(1.0f);
	}

	public void endRoutine()
	{

		StartCoroutine(leaveScene());
	}

	IEnumerator leaveScene()
	{
		while(transform.position.y<20)
		{
			yspeed += 0.5f;
			yield return new WaitForSeconds(0.5f);
		}
	}

}

