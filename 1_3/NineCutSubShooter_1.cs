using UnityEngine;
using System.Collections;

public class NineCutSubShooter_1 : shooterbasic
{
	
	GameObject[] bt2 = new GameObject[8];
	private bool pass = true;

	public bool Type = false;

	public override void Awake ()
	{
		base.Awake();

		bt2[0]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2[1]=Resources.Load("bt2_c",typeof(GameObject)) as GameObject;
		bt2[2]=Resources.Load("bt2_g",typeof(GameObject)) as GameObject;
		bt2[3]=Resources.Load("bt2_o",typeof(GameObject)) as GameObject;
		bt2[4]=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2[5]=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
		bt2[6]=Resources.Load("bt2_w",typeof(GameObject)) as GameObject;
		bt2[7]=Resources.Load("bt2_y",typeof(GameObject)) as GameObject;



	}

	public override IEnumerator mainroute ()
	{

		int i=0;
		GameObject bb;
		while(pass)
		{
			if(Type)
			{
				bb = (GameObject)Instantiate (bt2[i],gameObject.transform.position , Quaternion.identity);
				bb.AddComponent("rands");
				bb.GetComponent<rands> ().wspeed = 0;
				bb.GetComponent<rands> ().yspeed = 10;
				bb.GetComponent<rands> ().up = false;
				bb.GetComponent<rands> ().type = 1;


				if(i == 7) i=0;
				else {i++;if(i%3==0)audio.Play();}

				yield return new WaitForSeconds(0.3f);
			}
			else{

				bb = (GameObject)Instantiate (bt2[i],gameObject.transform.position , Quaternion.identity);
				bb.AddComponent("rands");
				bb.GetComponent<rands> ().wspeed = 90;
				bb.GetComponent<rands> ().yspeed = 0;
				bb.GetComponent<rands> ().clockwise = false;
				bb.GetComponent<rands> ().type = 1;


				if(i == 7) i=0;
				else {i++;if(i%3==0)audio.Play();}

				yield return new WaitForSeconds(0.3f);
			}

		}
		halt();

	}

	public void setHalt(bool signal)
	{
		this.pass = signal;
	}

}

