using UnityEngine;
using System.Collections;

public class ghostfire2_8 : enemybasic {

	GameObject[] bisolid= new GameObject[3];
	float yspeed=1,wspeed=1;


	public override IEnumerator mainroutine ()
	{
		GameObject bb;
		int i=0,j=0;
		if(Random.value>0.5f)
			j=5;
		else j=-5;
		Vector3 axis;
		StartCoroutine(speedcontrol());
		StartCoroutine(countdown());
		Vector3 v= Vector3.down;


		while(transform.position.y>-2)
		{


			axis= new Vector3(transform.position.x,0,transform.position.z);


				

			
			
			bb = (GameObject)Instantiate (bisolid[i%3],gameObject.transform.position , Quaternion.LookRotation(v.normalized));
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = true;
			bb.GetComponent<rands> ().yspeed = 2*Mathf.Cos(Mathf.Deg2Rad*i*j);
			bb.GetComponent<rands> ().wspeed = 10*Mathf.Sin(Mathf.Deg2Rad*i*j);
			bb.GetComponent<rands> ().type=1;
			v=Quaternion.AngleAxis(j,axis)*v;
			i++;
			if(i==72)
				i=0;
			//angle++;
			//v=Quaternion.AngleAxis(10,axis)*v;

			yield return new WaitForSeconds(0.1f);



		}


		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator speedcontrol()
	{
		int i=0,j=0;

		if(Random.value>0.5f)
			j=-5;
		else j=5;
		while(transform.position.y>-2)
		{
			wspeed= Mathf.Sin(Mathf.Deg2Rad*i*j);
			i++;
			if(i==72)
				i=0;
			yield return new WaitForSeconds(0.2f);
		}

		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator countdown()
	{


		yield return new WaitForSeconds(1.0f);
	}



	public override void Awake ()
	{
		bisolid[0] = Resources .Load("bisolid_w",typeof(GameObject)) as GameObject;
		bisolid[1] = Resources .Load("bisolid_i",typeof(GameObject)) as GameObject;
		bisolid[2]= Resources.Load("bisolid_g",typeof(GameObject)) as GameObject;
	}

	// Use this for initialization
	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="enemy")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
	// Update is called once per frame
	new void Update () {
		base.checkbound();
		
		transform.Translate (Vector3.down * yspeed * Time.deltaTime,Space.World);
		
		transform.RotateAround (Vector3.zero, Vector3.up, 10*wspeed * Time.deltaTime);
	}
}
