using UnityEngine;
using System.Collections;

public class Shooter3_12 : shooterbasic
{
	GameObject[] bt2 = new GameObject[8];
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

		int i=0;
		GameObject bb;
		float random = Random.Range(0,100);

		while(i<9)
		{

			audio.Play();

			for(int j=0;j<5;j++)
			{

				bb = (GameObject)Instantiate (bt2[i%8],gameObject.transform.position , Quaternion.identity);
				bb.AddComponent("expandhelix");
				bb.GetComponent<expandhelix> ().t=(int)(i*40+random+j*72);
				bb.GetComponent<expandhelix>() .type = 1;
				if(i<3)
					bb.GetComponent<expandhelix> ().expandType = 0;
				else if(i<5)
					bb.GetComponent<expandhelix> ().expandType = 1;
				else if(i<7)
					bb.GetComponent<expandhelix> ().expandType = 2;
				else
					bb.GetComponent<expandhelix> ().expandType = 3;
			}
			i++;

			yield return new WaitForSeconds(1.0f);
		}

		parent.SendMessage("endRoutine",SendMessageOptions.DontRequireReceiver);
		halt();
	}
}

