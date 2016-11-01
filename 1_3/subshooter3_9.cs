using UnityEngine;
using System.Collections;

public class subshooter3_9 : shooterbasic {

	GameObject[] bt2 = new GameObject[8];

	public bool bossVersion = false;
	public GameObject parent;
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

	}

	public override IEnumerator mainroute ()
	{
		int random=Random.Range(0,180);
		int i=0;
		GameObject bb;

		while(i<60)
		{

			audio.Play ();

			for(int j=0;j<3;j++)
			{
				bb = (GameObject)Instantiate (bt2[i%7], transform.position, Quaternion.identity);
				bb.AddComponent("expandhelix");
				if(bossVersion)
				{
					bb.GetComponent<expandhelix> ().t=j*10+(random+i)*4;
					bb.GetComponent<expandhelix> ().expandType = 3;
				}
				else
				{
					bb.GetComponent<expandhelix> ().t=j*10+(random+i)*4;
				}
			}

			i++;
			yield return new WaitForSeconds(0.3f);
		}

		parent.SendMessage("endRoutine",SendMessageOptions.DontRequireReceiver);

	}


}
