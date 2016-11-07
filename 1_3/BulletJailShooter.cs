using UnityEngine;
using System.Collections;

public class BulletJailShooter : shooterbasic
{

	GameObject[] bt2 = new GameObject[8];

	public bool stop = false;

	public float yFactor = 3, wFactor = 15;

	public void setStop(bool s)
	{
		this.stop = s;
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
	}

	public override IEnumerator mainroute ()
	{

		Vector3 axis;
		GameObject bb;
		int i1=0,i2 = 24,i3 = 48,j=0;
		Vector3 v= Vector3.down;
		if(Random.value>0.5f)
			j=5;
		else j=-5;
		Vector3 yOffset = Vector3.zero;
		Quaternion wOffset = Quaternion.identity;
		Vector3 insPos1 = Vector3.zero,insPos2 = Vector3.zero,insPos3 = Vector3.zero;

		while(!stop)
		{
			
			
			axis= new Vector3(transform.position.x,0,transform.position.z);
			yOffset = new Vector3(0,yFactor*Mathf.Cos(Mathf.Deg2Rad*i1*j),0);
			wOffset = Quaternion.Euler(0,wFactor*Mathf.Sin(Mathf.Deg2Rad*i1*j),0);
			insPos1 = wOffset * gameObject.transform.position +yOffset;

			yOffset = new Vector3(0,yFactor*Mathf.Cos(Mathf.Deg2Rad*i2*j),0);
			wOffset = Quaternion.Euler(0,wFactor*Mathf.Sin(Mathf.Deg2Rad*i2*j),0);
			insPos2 = wOffset * gameObject.transform.position +yOffset;

			yOffset = new Vector3(0,yFactor*Mathf.Cos(Mathf.Deg2Rad*i3*j),0);
			wOffset = Quaternion.Euler(0,wFactor*Mathf.Sin(Mathf.Deg2Rad*i3*j),0);
			insPos3 = wOffset * gameObject.transform.position +yOffset;



			bb = (GameObject)Instantiate (bt2[i1%8],insPos1 , Quaternion.identity);
			bb.AddComponent ("expandhelix");
			bb.GetComponent<expandhelix> ().t= i1*j;
			bb.GetComponent<expandhelix>().expandType = 3;

			bb = (GameObject)Instantiate (bt2[i2%8],insPos2 , Quaternion.identity);
			bb.AddComponent ("expandhelix");
			bb.GetComponent<expandhelix> ().t= i2*j;
			bb.GetComponent<expandhelix>().expandType = 3;

			bb = (GameObject)Instantiate (bt2[i3%8],insPos3 , Quaternion.identity);
			bb.AddComponent ("expandhelix");
			bb.GetComponent<expandhelix> ().t= i3*j;
			bb.GetComponent<expandhelix>().expandType = 3;

			v=Quaternion.AngleAxis(j,axis)*v;

			i1++;
			i2++;
			i3++;
			if(i1%2 == 0)
			{
				audio.Play();
			}
			if(i1==72)
				i1=0;
			if(i2==72)
				i2=0;
			if(i3==72)
				i3=0;

			yield return new WaitForSeconds(0.3f);

		}


		halt();

	}

}

