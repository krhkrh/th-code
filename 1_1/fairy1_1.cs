using UnityEngine;
using System.Collections;

public class fairy1_1 : enemybasic {


	public bool type=false;
	public float wspeed=30;
	public float yspeed=2;
	public bool up=false,clockwise=true;


	public Vector3 escape=Vector3.down;


	public override void remove ()
	{
		GameObject bb;

		animation.CrossFade("remove",0.3f);
		wspeed=0;
		yspeed=0;


		if(type==true)
		{
			bb = (GameObject)Instantiate (power, transform.position, Quaternion.identity);
			bb.AddComponent("itembasic");
			bb.GetComponent<itembasic> ().yspeed=-10;
			bb.GetComponent<itembasic> ().up=false;
			bb.GetComponent<itembasic> ().itemtype=0;
		}

		else
		{
			bb = (GameObject)Instantiate (point, transform.position, Quaternion.identity);
			bb.AddComponent("itembasic");
			bb.GetComponent<itembasic> ().yspeed=-10;
			bb.GetComponent<itembasic> ().up=false;
			bb.GetComponent<itembasic> ().itemtype=1;
		}

		StartCoroutine(adjustdirection());

	}

	IEnumerator adjustdirection()
	{
		//if(type==false)
			escape= gameObject.transform.forward+Vector3.down;
			//escape=(Quaternion.Euler(0,270,0) * new Vector3(transform.position.x,-3,transform.position.z))/3;
		//else
		//	escape=(Quaternion.Euler(0,90,0) * new Vector3(transform.position.x,-3,transform.position.z))/3;
		
		yield return new WaitForSeconds(2.0f);
		status=-1;
		animation.CrossFade("escape",0.1f);
		yield return new WaitForSeconds(4.0f);
		animation.CrossFade("move",0.5f);
	}



	public override IEnumerator mainroutine ()
	{
		yield return new WaitForSeconds(5.0f);
	
		while(status==1)
		{
			yield return new WaitForSeconds(3.0f);
			up=!up;
		}

	}


	// Update is called once per frame
	new public void Update () {
		base.Update();

		if(status==1)
		{
			if(up==true)
				transform.Translate (Vector3.up * yspeed * Time.deltaTime);
			else
				transform.Translate (-Vector3.up * yspeed * Time.deltaTime);
			
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
