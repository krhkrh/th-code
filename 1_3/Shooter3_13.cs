using UnityEngine;
using System.Collections;

public class Shooter3_13 : shooterbasic
{
	GameObject[] bt2 = new GameObject[4];
	int colorType=0;

	
	public override void Awake ()
	{
		base.Awake ();
		if(transform.position.y<3)
			colorType =0;
		else if(transform.position.y<10)
			colorType = 1;
		else colorType = 2;

		switch(colorType)
		{
		case 0:{
			bt2[0]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
			bt2[1]=Resources.Load("bt2_c_d",typeof(GameObject)) as GameObject;
			bt2[2]=Resources.Load("bt2_g_d",typeof(GameObject)) as GameObject;
			bt2[3]=Resources.Load("bt2_v_d",typeof(GameObject)) as GameObject;
		}break;
		case 1:{

			bt2[0]=Resources.Load("bt2_g",typeof(GameObject)) as GameObject;
			bt2[1]=Resources.Load("bt2_w_d",typeof(GameObject)) as GameObject;
			bt2[2]=Resources.Load("bt2_y_d",typeof(GameObject)) as GameObject;
			bt2[3]=Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;

		}break;
		case 2:{
			bt2[0]=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
			bt2[1]=Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;
			bt2[2]=Resources.Load("bt2_o_d",typeof(GameObject)) as GameObject;
			bt2[3]=Resources.Load("bt2_y_d",typeof(GameObject)) as GameObject;
		}break;
		default:break;
		}
	}


	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int j=7;
		Vector3 v = Vector3.down*5;
		const float floor1 = 360/7,floor2 = 72,floor3 = 120;
		Vector3 HorizontalAxis = new Vector3(transform.position.x,0,transform.position.z);
		Vector3 VerticalAxis = -(Quaternion.Euler(0,90,0)*HorizontalAxis);
		audio.Play();
		for(j=0;j<7;j++)
		{
			bb = (GameObject)Instantiate (bt2[0],gameObject.transform.position , Quaternion.identity);
			bb.AddComponent("IvyFruitBehavior2");
			bb.GetComponent<IvyFruitBehavior2> ().speed = v;
			v= Quaternion.AngleAxis(floor1,HorizontalAxis)*v;

		}
		
		v = Quaternion.AngleAxis(30,VerticalAxis)*Vector3.down*5;
		yield return new WaitForSeconds(0.1f);
		audio.Play();
		for(j=0;j<5;j++)
		{
			bb = (GameObject)Instantiate (bt2[1],gameObject.transform.position , Quaternion.identity);
			bb.AddComponent("IvyFruitBehavior");
			bb.GetComponent<IvyFruitBehavior> ().speed = v;
			v= Quaternion.AngleAxis(floor2,HorizontalAxis)*v;
				
		}

		v = Quaternion.AngleAxis(60,VerticalAxis)*Vector3.down*5;
		yield return new WaitForSeconds(0.1f);
		audio.Play();
		for(j=0;j<3;j++)
		{
			bb = (GameObject)Instantiate (bt2[2],gameObject.transform.position , Quaternion.identity);
			bb.AddComponent("IvyFruitBehavior");
			bb.GetComponent<IvyFruitBehavior> ().speed = v;
			v= Quaternion.AngleAxis(floor3,HorizontalAxis)*v;
		
		}
		
		v = Quaternion.AngleAxis(90,VerticalAxis)*Vector3.down*5;
		yield return new WaitForSeconds(0.1f);
		audio.Play();
		bb = (GameObject)Instantiate (bt2[3],gameObject.transform.position , Quaternion.identity);
		bb.AddComponent("IvyFruitBehavior");
		bb.GetComponent<IvyFruitBehavior> ().speed = v;

		yield return new WaitForSeconds(2.0f);
		halt();
	}

}

