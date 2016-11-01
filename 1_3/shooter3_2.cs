using UnityEngine;
using System.Collections;

public class shooter3_2 : shooterbasic {

	GameObject bt2_r,bt2_b,bt2_v,bt2_o;

	float Yspeed = 1.0f;
	int randomNumber=0;

	
	public override void Awake ()
	{
		base.Awake ();

		bt2_r=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2_b=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2_v=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
		bt2_o=Resources.Load("bt2_o",typeof(GameObject)) as GameObject;



	}

	public override IEnumerator mainroute ()
	{

		int i=0,factor=-5;
		GameObject bb;
		Vector3 spawn=this.transform.position;

		while(i<3)
		{
			randomNumber = Random.Range(0,180);

			audio.Play();
			bb = (GameObject)Instantiate (bt2_r, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1;
			bb.GetComponent<cylincircle> ().t=randomNumber;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;


			bb = (GameObject)Instantiate (bt2_b, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1;
			bb.GetComponent<cylincircle> ().t=randomNumber+90;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;

			bb = (GameObject)Instantiate (bt2_v, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1;
			bb.GetComponent<cylincircle> ().t=randomNumber+ 180;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;

			bb = (GameObject)Instantiate (bt2_o, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1;
			bb.GetComponent<cylincircle> ().t=randomNumber+ 270;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;

			randomNumber = Random.Range(0,180);

			yield return new WaitForSeconds(1.0f);
			audio.Play();
			bb = (GameObject)Instantiate (bt2_r, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1.5f;
			bb.GetComponent<cylincircle> ().t=randomNumber;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;
			
			
			bb = (GameObject)Instantiate (bt2_b, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1.5f;
			bb.GetComponent<cylincircle> ().t=randomNumber+90;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;
			
			bb = (GameObject)Instantiate (bt2_v, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1.5f;
			bb.GetComponent<cylincircle> ().t=randomNumber+ 180;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;
			
			bb = (GameObject)Instantiate (bt2_o, spawn, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=1.5f;
			bb.GetComponent<cylincircle> ().t=randomNumber+ 270;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;

			yield return new WaitForSeconds(2.0f);
			i++;
		}
		
		
		halt();
	}



}
