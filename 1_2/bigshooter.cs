using UnityEngine;
using System.Collections;

public class bigshooter : shooterbasic {


	public bool type=true;
	GameObject tamar,tamab;
	bool stop=false;


	public override void Awake ()
	{
		base.Awake ();


		tamar=Resources.Load("b1_r",typeof(GameObject)) as GameObject;

		tamab=Resources.Load("b1_b",typeof(GameObject)) as GameObject;
	}


	void stopfiring()
	{
		stop=true;
	}


	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int i=0;

		for(i=0;i<50;i++)
		{
			if(stop)
			{
				break;
			}

			audio.Play();

			if(type)
			{
				if(i<15)
				{
					bb = (GameObject)Instantiate (tamar,transform.position+Vector3.down, Quaternion.identity);
					bb.AddComponent ("tama2_7");
					bb.GetComponent<tama2_7> ().clockwise=true;
					bb.GetComponent<tama2_7> ().wspeed=90-i*6;
					bb.GetComponent<tama2_7> ().yspeed=5+i/2;
				}
				else
				{
					bb = (GameObject)Instantiate (tamar,transform.position+Vector3.down, Quaternion.identity);
					bb.AddComponent ("tama2_7");
					bb.GetComponent<tama2_7> ().clockwise=true;
					bb.GetComponent<tama2_7> ().wspeed=0;
					bb.GetComponent<tama2_7> ().yspeed=12;

				}
			}
			else
			{

				if(i<15)
				{
					bb = (GameObject)Instantiate (tamab,transform.position+Vector3.down, Quaternion.identity);
					bb.AddComponent ("tama2_7");
					bb.GetComponent<tama2_7> ().clockwise=false;
					bb.GetComponent<tama2_7> ().wspeed=90-i*6;
					bb.GetComponent<tama2_7> ().yspeed=5+i/2;
				}
				else
				{
					bb = (GameObject)Instantiate (tamab,transform.position+Vector3.down, Quaternion.identity);
					bb.AddComponent ("tama2_7");
					bb.GetComponent<tama2_7> ().clockwise=false;
					bb.GetComponent<tama2_7> ().wspeed=0;
					bb.GetComponent<tama2_7> ().yspeed=12;
					
				}
			}
			yield return new WaitForSeconds(0.3f);

		}

		halt();

	}
	

}
