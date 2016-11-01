using UnityEngine;
using System.Collections;

public class Shooter3_6 : shooterbasic {

	GameObject b3_w;
	 Vector3 va = new Vector3(0,19.0f,0);
	Vector3[] v = new Vector3[4];

	public override void Awake ()
	{
		base.Awake();
		v[0] = Vector3.forward*10+va; v[1] = Vector3.left*10+va; v[2] = Vector3.back*10+va; v[3] = Vector3.right*10+va;
		b3_w=Resources.Load("b3_w",typeof(GameObject)) as GameObject;
	}

	public override IEnumerator mainroute ()
	{
		GameObject bb;

		audio.Play();
		for(int i=0;i<4;i++)
		{
			bb = (GameObject)Instantiate (b3_w, v[i], Quaternion.identity);
			bb.AddComponent("leftbranch");

		}
			
		yield return new WaitForSeconds(1.0f);
		halt();
	}
}
