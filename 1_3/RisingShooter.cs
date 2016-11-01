using UnityEngine;
using System.Collections;

public class RisingShooter : shooterbasic
{
	GameObject[] bt2 = new GameObject[8];
	GameObject[] bt2_d = new GameObject[8];
	public GameObject player;

	bool finish = false;
	public void setFinish(bool f)
	{
		this.finish = f;
	}

	public override void Awake ()
	{

		base.Awake ();
		
		bt2[0]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2[1]=Resources.Load("bt2_c",typeof(GameObject)) as GameObject;
		bt2[2]=Resources.Load("bt2_g",typeof(GameObject)) as GameObject;
		bt2[3]=Resources.Load("bt2_o",typeof(GameObject)) as GameObject;
		bt2[4]=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2[5]=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
		bt2[6]=Resources.Load("bt2_w",typeof(GameObject)) as GameObject;
		bt2[7]=Resources.Load("bt2_y",typeof(GameObject)) as GameObject;

		bt2_d[0]=Resources.Load("bt2_b_d",typeof(GameObject)) as GameObject;
		bt2_d[1]=Resources.Load("bt2_c_d",typeof(GameObject)) as GameObject;
		bt2_d[2]=Resources.Load("bt2_g_d",typeof(GameObject)) as GameObject;
		bt2_d[3]=Resources.Load("bt2_o_d",typeof(GameObject)) as GameObject;
		bt2_d[4]=Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;
		bt2_d[5]=Resources.Load("bt2_v_d",typeof(GameObject)) as GameObject;
		bt2_d[6]=Resources.Load("bt2_w_d",typeof(GameObject)) as GameObject;
		bt2_d[7]=Resources.Load("bt2_y_d",typeof(GameObject)) as GameObject;

	}

	private Vector3 getHorizontalVector(Vector3 v)
	{
		return new Vector3(v.x, 0, v.z);
	}

	//freeBullet
	public override IEnumerator mainroute ()
	{
		Vector3 speed  = Vector3.up;
		int i=0;
		GameObject bb;
		Vector3 va = Vector3.down*3;
		while(!finish)
		{

			bb = (GameObject)Instantiate (bt2[i], Quaternion.Euler(0,Random.Range(-90,90),0) * getHorizontalVector(player.transform.position) + va, Quaternion.identity);
			bb.AddComponent("freeBullet");
			bb.GetComponent<freeBullet> ().speed = speed * Random.Range(5,10);
			bb.GetComponent<freeBullet> ().lifeSpan = 4;

			for(int j=0;j<5;j++)
			{
				bb = (GameObject)Instantiate (bt2_d[(int)Random.Range(0,8)], Quaternion.Euler(0,Random.Range(-90,90),0) * getHorizontalVector(player.transform.position) * Random.Range(1.0f,2.0f) + va, Quaternion.identity);
				bb.AddComponent("freeBullet");
				bb.GetComponent<freeBullet> ().speed = speed * Random.Range(5,10);
				bb.GetComponent<freeBullet> ().lifeSpan = 4;

			}

			i++;
			if(i==8)
			{
				i=0;
			}

			yield return new WaitForSeconds(0.2f);
		}
		halt();
	}
}

