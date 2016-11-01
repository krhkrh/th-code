using UnityEngine;
using System.Collections;

public class integration34 : shooterbasic {

	/*case 0:bt2_=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;break;
	case 1:bt2_=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;break;
	case 2:bt2_=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;break;
	case 3:bt2_=Resources.Load("bt2_o",typeof(GameObject)) as GameObject;break;

*/

	GameObject[] bt2 = new GameObject[2];

	Vector3[] v8 = new Vector3[8];
	Vector3 va = new Vector3(0,19,0),vb = new Vector3(0,-4,0);

	public override void Awake ()
	{
		base.Awake ();

		bt2[0]=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2[1]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;



		v8[0] = Vector3.forward*10;
		v8[1] = Vector3.right*10;
		v8[2] = Vector3.back*10;
		v8[3] = Vector3.left*10;
		v8[4] = (Vector3.forward+Vector3.right).normalized*10;
		v8[5] = (Vector3.forward+Vector3.left).normalized*10;
		v8[6] = (Vector3.back+Vector3.right).normalized*10;
		v8[7] = (Vector3.back+Vector3.left).normalized*10;


	}

	public override IEnumerator mainroute ()
	{
		GameObject bb;

		for(int i=0;i<7;i++)
		{

			audio.Play ();

			bb = (GameObject)Instantiate (bt2[i%2], Quaternion.Euler(0,i*11,0)*v8[i%8]+va ,Quaternion.identity );
			bb.AddComponent ("shellfish");
			bb.GetComponent<shellfish>().colortype = i%2;
			bb.GetComponent<shellfish>().shelltype = false;


			bb = (GameObject)Instantiate (bt2[i%2], Quaternion.Euler(0,-i*11,0)*v8[(i+4)%8]+vb ,Quaternion.identity );
			bb.AddComponent ("shellfish");
			bb.GetComponent<shellfish>().colortype = i%2;
			bb.GetComponent<shellfish>().shelltype = true;


			yield return new WaitForSeconds(4.0f);
		}


		yield return new WaitForSeconds(1.0f);
	}
}
