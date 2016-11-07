using UnityEngine;
using System.Collections;

public class shooter3_11 : shooterbasic {

	GameObject[] bt2 = new GameObject[8];

	Vector3[] v8 = new Vector3[8];
	Vector3 va = new Vector3(0,19,0),vb = new Vector3(0,-4,0);
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

		v8[0] = Vector3.forward*10;
		v8[1] = Vector3.right*10;
		v8[2] = Vector3.back*10;
		v8[3] = Vector3.left*10;
		v8[4] = (Vector3.forward+Vector3.right).normalized*10;
		v8[5] = (Vector3.forward+Vector3.left).normalized*10;
		v8[6] = (Vector3.back+Vector3.right).normalized*10;
		v8[7] = (Vector3.back+Vector3.left).normalized*10;



	}

	bool stop = false;
	public void setStop(bool s)
	{
		this.stop = s;
	}


	public override IEnumerator mainroute ()
	{
		GameObject bb;
		int i=0;
		while(!stop)
		{

			audio.Play ();
			for(int j=0;j<8;j++)
			{
				bb = (GameObject)Instantiate (bt2[i%8], Quaternion.Euler(0,i*10,0)*v8[j]+va ,Quaternion.identity );
				bb.AddComponent ("cogbehavior");
				bb.GetComponent<cogbehavior> ().cogtype=false;

			}

			for(int j=0;j<8;j++)
			{
				bb = (GameObject)Instantiate (bt2[i%8], Quaternion.Euler(0,-i*10,0)*v8[j]+vb ,Quaternion.identity );
				bb.AddComponent ("cogbehavior");
				bb.GetComponent<cogbehavior> ().cogtype=true;
					
			}

			i++;
			if(i==36)
				i=0;

			yield return new WaitForSeconds(1.0f);
		}
		halt();
	}
}
