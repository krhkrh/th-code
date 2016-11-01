using UnityEngine;
using System.Collections;

public class fairy2_2 : fairy1_1 {


	GameObject shooter;
	GameObject fairy;
	bool take=true;


	Vector3 respawn;
	Quaternion requater;
	float oyspeed;
	public override void Awake ()
	{
		base.Awake ();
		shooter= Resources.Load("shooter3", typeof(GameObject)) as GameObject;




		respawn=transform.position;
		requater=transform.rotation;
		oyspeed=yspeed;
	}

	void setake(bool s)
	{
		take=s;
	}

	public override IEnumerator mainroutine ()
	{

		if(type==true)
		{
			fairy= Resources.Load("littltfairyb", typeof(GameObject)) as GameObject;
			
		}
		
		else{
			fairy=Resources.Load("littltfairy" , typeof(GameObject)) as GameObject;
		}
		int i=0,j=0;
		GameObject bb;
		while(yspeed>1)
		{
			yspeed*=0.5f;
			if(health<0)
				break;
			yield return new WaitForSeconds(0.3f);
		}
		yspeed=0;
		if(health>=0&&take)
		{
		animation.CrossFade("shoot",0.3f);

		yield return new WaitForSeconds(1.3f);
		if(health>0&&take==true)
		animation.CrossFade("attack",0.3f);
		for(j=0;j<8;j++)
		{
			for(i=0;i<2;i++)
			{
				if(health<=0||take==false)
					break;
					bb = (GameObject)Instantiate (shooter, transform.position+Vector3.down*3 , Quaternion.identity);
					bb.AddComponent ("shooter2_2");

					yield return new WaitForSeconds(1.0f);

			}
			if(health<=0||take==false)
				break;
			yield return new WaitForSeconds(1.0f);
			for(i=0;i<2;i++)
			{
				if(health<=0)
					break;
				bb = (GameObject)Instantiate (shooter, transform.position+Vector3.down*3 , Quaternion.identity);
					bb.AddComponent ("shooter2_2");

					yield return new WaitForSeconds(0.5f);
			}
			if(health<=0)
				break;
			yield return new WaitForSeconds(1.0f);
		}
		}

		//yield return new WaitForSeconds(2.0f);
		if(health>0)
		{
			animation.CrossFade("move",0.3f);
		}

		yield return new WaitForSeconds(2.0f);

		if(health<=0&&take==true)
		{
			if(type)
			{
				bb = (GameObject)Instantiate (fairy, respawn, requater);
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=false;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=oyspeed*16;
				bb.GetComponent<fairy1_1> ().health=50;
			}
			else
			{
				bb = (GameObject)Instantiate (fairy, respawn, requater);
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=true;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=oyspeed*16;
				bb.GetComponent<fairy1_1> ().health=50;

			}
		}

		yspeed = 0.5f;
		while(yspeed<3)
		{
			yspeed+=0.5f;
			yield return new WaitForSeconds(0.5f);
		}
	}

	public override void remove ()
	{

		base.remove ();
		StartCoroutine(revenge());

	}

	IEnumerator revenge()
	{
		GameObject bb;
		yield return new WaitForSeconds(8.0f);
		animation.CrossFade("instantattk",0.3f);
		yield return new WaitForSeconds(0.3f);
		bb = (GameObject)Instantiate (shooter, transform.position-transform.forward*3 , Quaternion.identity);
		bb.AddComponent("dirshooter");
		yield return new WaitForSeconds(1.0f);
		animation.CrossFade("move",0.5f);
	}


	new void Update () {
		base.checkbound();
		
		if(status==1)
		{
			if(up==true)
				transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
			else
				transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);
			
			if (clockwise == true)
				transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
			else
				transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
		}
		else if(status==-1)
		{
			transform.Translate (escape * Time.deltaTime,Space.World);
			
		}
	}
}
