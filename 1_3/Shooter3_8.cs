using UnityEngine;
using System.Collections;

public class Shooter3_8 :  shooterbasic{

	//const float orbit = 11.5f;
	Vector3 vp,va;
	public bool tornadotype = false;
	public Vector3 initposition;
	GameObject tornatocolumninstance,tornatocolumninstance2;
	public override void Awake ()
	{
		base.Awake ();


		tornatocolumninstance = Resources.Load("tornadounitc",typeof(GameObject)) as GameObject;
		tornatocolumninstance2 = Resources.Load("tornadounith",typeof(GameObject)) as GameObject;
	}

	public override IEnumerator mainroute ()
	{
		va = new Vector3(0,16.9f,0);
		//va2  = new Vector3(0,13.9f,0);
		GameObject bb;
		int count =0;
		
		while(count<20)
		{
			audio.Play ();
			vp = new Vector3(initposition.x,0,initposition.z);
			vp.Normalize();
			
		//	if(count%2==0)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance, vp*11.5f+va, Quaternion.identity);
				bb.AddComponent("tornadobehavior");
				bb.GetComponent<tornadobehavior> ().yspeed=1;
				bb.GetComponent<tornadobehavior> ().wspeed=0;
				bb.GetComponent<tornadobehavior> ().up = false;
				bb.GetComponent<tornadobehavior> ().tornadotype = tornadotype;
				
			}

			
			/*else if(count%2==1)
			{
				bb = (GameObject)Instantiate (tornatocolumninstance2, vp*11.0f+va2, Quaternion.identity);
				bb.AddComponent("tornadobehavior");
				bb.GetComponent<tornadobehavior> ().yspeed=1;
				bb.GetComponent<tornadobehavior> ().wspeed=0;
				bb.GetComponent<tornadobehavior> ().up = false;
			}*/
			count++;
			yield return new WaitForSeconds(1.0f);
		}
	}

	

}
