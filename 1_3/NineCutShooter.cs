using UnityEngine;
using System.Collections;

public class NineCutShooter : shooterbasic
{

	public GameObject player;
	private GameObject shooter3,b3_v;

	Vector3[] v5 = new Vector3[5];
	Vector3 va = Vector3.up*19;

	GameObject[] cielShooter = new GameObject[5];

	private bool pass = true;

	public void setHalt(bool p)
	{
		this.pass = p;

	}

	public override void Awake ()
	{
		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;

		Quaternion rotation = Quaternion.Euler(0,72,0);
		Vector3 temp = Vector3.forward*10;
		int i =0;
		for(i=0;i<5;i++)
		{
			temp = rotation * temp;
			v5[i] = temp;
		}


	}

	public override IEnumerator mainroute ()
	{
		GameObject bb,shooter;
		int i=0;
		for(i=0;i<5;i++)
		{
			bb = (GameObject)Instantiate (b3_v, v5[i]+va, Quaternion.Euler(270,0,0));
			bb.AddComponent("rands");
			bb.GetComponent<rands> ().wspeed = 25.0f;
			bb.GetComponent<rands> ().clockwise = false;
			bb.GetComponent<rands> ().yspeed = 0;
			bb.GetComponent<Collider>().enabled = false;

			shooter = (GameObject)Instantiate (shooter3, bb.transform.position, Quaternion.identity);
			shooter.AddComponent("NineCutSubShooter_1");
			shooter.GetComponent<NineCutSubShooter_1> ().Type = true;
			shooter.transform.parent = bb.transform;

			cielShooter[i] = bb;
		}

		//Type == true means rotate false means going down
		i = 0;

		while(i < 3)
		{

			bb = (GameObject)Instantiate (b3_v, getHorizontalVector(player.transform.position) + va, Quaternion.Euler(270,0,0));
			bb.AddComponent("rands");
			bb.GetComponent<rands> ().wspeed = 0;
			bb.GetComponent<rands> ().up = false;
			bb.GetComponent<rands> ().yspeed = 3 + Random.Range(0,1);
			bb.GetComponent<Collider>().enabled = false;

			shooter = (GameObject)Instantiate (shooter3, bb.transform.position, Quaternion.identity);
			shooter.AddComponent("NineCutSubShooter_1");
			shooter.GetComponent<NineCutSubShooter_1> ().Type = false;
			shooter.transform.parent = bb.transform;

			yield return new WaitForSeconds(20.0f);
			i++;
		}

		while(pass)
		{
			yield return new WaitForSeconds(1.0f);
		}

		for(i=0;i<5;i++)
		{
			cielShooter[i].GetComponent<rands> ().halt();
		}

		halt();
	}

	private Vector3 getHorizontalVector(Vector3 v)
	{
		return new Vector3(v.x, 0, v.z);
	}
}

