using UnityEngine;
using System.Collections;

public class Shooter3_7 : shooterbasic {


	//const float orbit = 11.5f; 11
	public const int BossBattle = 1, OnRoute = 0;
	Vector3 vp,va,va2;
	public GameObject player;
	GameObject tornatocolumninstance,tornatocolumninstance2;
	public int workingMode = OnRoute;

	public override void Awake ()
	{
		base.Awake ();

		tornatocolumninstance = Resources.Load("tornadocolumn",typeof(GameObject)) as GameObject;
		tornatocolumninstance2 = Resources.Load("tornadosandwitch",typeof(GameObject)) as GameObject;
	}


	public override IEnumerator mainroute()
	{

		
		va = new Vector3(0,16.9f,0);
		va2  = new Vector3(0,13.9f,0);
		GameObject bb;
		int count =0;

		while(count<10)
		{
			audio.Play ();
			vp = new Vector3(player.transform.position.x,0,player.transform.position.z);
			vp.Normalize();

			if(count%2==0)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance, -vp*11.5f+va, Quaternion.identity);
				bb.AddComponent("tornadocolumn");
				bb.GetComponent<tornadocolumn> ().yspeed=1;
				bb.GetComponent<tornadocolumn> ().tornadotype=true;
				bb.GetComponent<tornadocolumn> ().up = false;

			}


			else if(count%2==1)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance2, -vp*11.0f+va2, Quaternion.identity);
				bb.AddComponent("tornadocolumn");
				bb.GetComponent<tornadocolumn> ().yspeed=1;
				bb.GetComponent<tornadocolumn> ().tornadotype=false;
				bb.GetComponent<tornadocolumn> ().up = false;
			}

			/*else if(count%4==2)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance2, Quaternion.Euler(0,180,0)*vp*11.0f+va2, Quaternion.Euler(180,0,0));
				bb.AddComponent("tornadocolumn");
				bb.GetComponent<tornadocolumn> ().yspeed=1;
				bb.GetComponent<tornadocolumn> ().tornadotype=false;
				bb.GetComponent<tornadocolumn> ().up = false;
				bb.GetComponent<tornadocolumn> ().clockwise = false;
			}

			else if(count%4==3)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance2, Quaternion.Euler(0,180,0)*vp*11.0f+va2, Quaternion.Euler(180,0,0));
				bb.AddComponent("tornadocolumn");
				bb.GetComponent<tornadocolumn> ().yspeed=1;
				bb.GetComponent<tornadocolumn> ().tornadotype=false;
				bb.GetComponent<tornadocolumn> ().up = false;
				bb.GetComponent<tornadocolumn> ().clockwise = false;
			}*/
			if(workingMode == OnRoute)
				count++;
			else if (workingMode == BossBattle)
				count += 2;

			yield return new WaitForSeconds(1.0f);
		}

		halt();
	}




}
