using UnityEngine;
using System.Collections;

public class shooter3_10 : shooterbasic{


	GameObject[] bt2 = new GameObject[8];
	public float radius=20.0f;

	public override void Awake ()
	{
		base.Awake ();
		audio.rolloffMode = AudioRolloffMode.Linear;

		bt2[0]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2[1]=Resources.Load("bt2_c",typeof(GameObject)) as GameObject;
		bt2[2]=Resources.Load("bt2_g",typeof(GameObject)) as GameObject;
		bt2[3]=Resources.Load("bt2_o",typeof(GameObject)) as GameObject;
		bt2[4]=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2[5]=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;
		bt2[6]=Resources.Load("bt2_w",typeof(GameObject)) as GameObject;
		bt2[7]=Resources.Load("bt2_y",typeof(GameObject)) as GameObject;
	}

	public override IEnumerator mainroute ()
	{
		GameObject bb;
		Vector3 axis, v= Vector3.up;
		

			for(int j=0;j<3 ;j++)
			{
				
				
				axis= new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
				
				Vector3.OrthoNormalize(ref axis,ref v);
				v*=radius;
				audio.Play ();
				for(int i=0;i<36;i++)
				{
					
					bb = (GameObject)Instantiate (bt2[i%8], gameObject.transform.position ,Quaternion.identity );
					bb.AddComponent ("saim");
					bb.GetComponent<saim> ().aim=v;
					bb.GetComponent<saim> ().type=0;
					v=Quaternion.AngleAxis(10,axis)*v;
				}
				
				yield return new WaitForSeconds(0.2f);
			}
	}


}

