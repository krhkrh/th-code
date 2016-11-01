using UnityEngine;
using System.Collections;

public class Shooter3_3 : shooterbasic {

	public int colortype=1;

	GameObject bt2_;
	float Yspeed = 1.0f;

	public override void Awake ()
	{
		base.Awake ();


		switch(colortype)
		{
			case 0:bt2_=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;break;
			case 1:bt2_=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;break;

		default:break;
		}

		
		
	}

	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int i=1;


		while(transform.position.y>0)
		{

			audio.Play();

			bb = (GameObject)Instantiate (bt2_, transform.position, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=transform.position.y*0.2f+0.1f;
			bb.GetComponent<cylincircle> ().t=-90;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;
			bb.GetComponent<cylincircle> ().clockwise = true;


			bb = (GameObject)Instantiate (bt2_, transform.position, Quaternion.identity);
			bb.AddComponent("cylincircle");
			bb.GetComponent<cylincircle> ().radius=transform.position.y*0.2f+0.1f;
			bb.GetComponent<cylincircle> ().t=-90;
			bb.GetComponent<cylincircle> ().baseYspeed = Yspeed;
			bb.GetComponent<cylincircle> ().clockwise = false;

			i++;
			yield return new WaitForSeconds(0.2f);
		}

		halt();
	}





}
