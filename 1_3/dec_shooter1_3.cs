using UnityEngine;
using System.Collections;

public class dec_shooter1_3 : shooterbasic{

	GameObject[] bt2_d = new GameObject[8];

	public float radius=10.0f;
	public override void Awake ()
	{
		base.Awake ();
		audio.rolloffMode = AudioRolloffMode.Linear;

		bt2_d[0]=Resources.Load("bt2_b_d",typeof(GameObject)) as GameObject;
		bt2_d[1]=Resources.Load("bt2_c_d",typeof(GameObject)) as GameObject;
		bt2_d[2]=Resources.Load("bt2_g_d",typeof(GameObject)) as GameObject;
		bt2_d[3]=Resources.Load("bt2_o_d",typeof(GameObject)) as GameObject;
		bt2_d[4]=Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;
		bt2_d[5]=Resources.Load("bt2_v_d",typeof(GameObject)) as GameObject;
		bt2_d[6]=Resources.Load("bt2_w_d",typeof(GameObject)) as GameObject;
		bt2_d[7]=Resources.Load("bt2_y_d",typeof(GameObject)) as GameObject;

	}

	public override IEnumerator mainroute ()
	{
		GameObject bb;
		Vector3 axis, v= Vector3.up;


		for(int m=0;m<5;m++)
		{

		yield return new WaitForSeconds(3.0f);

		for(int j=0;j<3 ;j++)
		{


			axis= new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));

			Vector3.OrthoNormalize(ref axis,ref v);
			v*=radius;
			audio.Play ();
			for(int i=0;i<36;i++)
			{
				
				bb = (GameObject)Instantiate (bt2_d[i%8], gameObject.transform.position ,Quaternion.identity );
				bb.AddComponent ("dec_fade");
				bb.GetComponent<dec_fade> ().speed=v;

				v=Quaternion.AngleAxis(10,axis)*v;
			}

			yield return new WaitForSeconds(0.2f);
		}
		}

		yield return new WaitForSeconds(1.0f);
	}

}
