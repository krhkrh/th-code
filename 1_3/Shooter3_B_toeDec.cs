using UnityEngine;
using System.Collections;

public class Shooter3_B_toeDec : shooterbasic
{
	GameObject[] bt2_d = new GameObject[3];
	public float speedFactor = 5;
	public int parimeter = 9;

	public override void Awake ()
	{

		base.Awake ();
		bt2_d[0]=Resources.Load("bt2_b_d",typeof(GameObject)) as GameObject;
		bt2_d[1]=Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;
		bt2_d[2]=Resources.Load("bt2_v_d",typeof(GameObject)) as GameObject;
		audio.rolloffMode = AudioRolloffMode.Linear;

	}
	public override IEnumerator mainroute ()
	{
		GameObject bb;
		Vector3 axis, v= Vector3.up;
	
		axis= new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
		float pariSpan = 360/parimeter;

		Vector3.OrthoNormalize(ref axis,ref v);
		v*= speedFactor;

		for(int i=0;i<parimeter;i++)
		{
			bb = (GameObject)Instantiate (bt2_d[i%3], gameObject.transform.position ,Quaternion.identity );
			bb.AddComponent ("dec_fade");
			bb.GetComponent<dec_fade> ().speed=v;
			bb.GetComponent<dec_fade> ().lifeSpan = 5;
			v=Quaternion.AngleAxis(pariSpan,axis)*v;
		}
		yield return new WaitForSeconds(0.2f);
		halt();
	}
}

