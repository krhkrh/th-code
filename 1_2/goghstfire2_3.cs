using UnityEngine;
using System.Collections;

public class goghstfire2_3 : enemybasic {

	// Use this for initialization
	GameObject[] bisolid=new GameObject[8];
	float yspeed=0,wspeed=1;
	float alpha=1;
	public AudioClip clip;
	bool take=false;


	new void Start () {

		audio.volume=Control.volume;
		StartCoroutine(mainroutine());
	}

	public override IEnumerator mainroutine ()
	{
		GameObject bb;
		int i=0;
		StartCoroutine(speedcontrol());
		StartCoroutine(countdown());
		while(transform.position.y>-4)
		{

			audio.PlayOneShot(clip);
			bb = (GameObject)Instantiate (bisolid[i],transform.position, Quaternion.Euler(90,0,0));
			bb.AddComponent ("straightline");
			if(transform.position.y>12)
			{
				bb.GetComponent<straightline> ().up=false;

			}
			else
			{
				bb.GetComponent<straightline> ().up=true;

			}
			bb.GetComponent<straightline> ().yspeed=yspeed+1;
			bb.transform.localScale=Vector3.one*0.5f;
			i++;
			if(i==8)
				i=0;
			yield return new WaitForSeconds(0.3f);

		}
	}

	IEnumerator speedcontrol()
	{

		while(take==false)
		{
			yspeed=2.5f*Mathf.Sin(alpha*Mathf.Deg2Rad);
			wspeed=2.5f*(Mathf.Cos(alpha*Mathf.Deg2Rad)+1);


			if(alpha>=360)
				alpha=1;


			alpha+=3;
			yield return new WaitForSeconds(0.2f);
		}


		while(yspeed<7)
		{
			yspeed+=0.5f;
			yield return new WaitForSeconds(0.2f);
		}


	}

	IEnumerator countdown()
	{
		yield return new WaitForSeconds(40.0f);
		take=true;
	}

	public override void Awake ()
	{
		bisolid[0]= Resources.Load("bisolid_r",typeof(GameObject)) as GameObject;
		bisolid[1]= Resources.Load("bisolid_o",typeof(GameObject)) as GameObject;
		bisolid[2]= Resources.Load("bisolid_y",typeof(GameObject)) as GameObject;
		bisolid[3]= Resources.Load("bisolid_g",typeof(GameObject)) as GameObject;
		bisolid[4]= Resources.Load("bisolid_b",typeof(GameObject)) as GameObject;
		bisolid[5]= Resources.Load("bisolid_i",typeof(GameObject)) as GameObject;
		bisolid[6]= Resources.Load("bisolid_v",typeof(GameObject)) as GameObject;
		bisolid[7]= Resources.Load("bisolid_w",typeof(GameObject)) as GameObject;


	}

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
