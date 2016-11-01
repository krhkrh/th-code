using UnityEngine;
using System.Collections;

public class myscube2_10 : basic {


	float yspeed=24;
	bool finished=false;
	public Material DSR;
	public Material normal;
	
	GameObject key;
	GameObject[] fakekey=new GameObject[2];
	GameObject player;
	GameObject brick_b,brick_r,brick_g;
	GameObject oneup;
	GameObject oneupentity;

	Vector3 forward_left = (Vector3.forward + Vector3.left).normalized * 10;
	Vector3 forward_right = (Vector3.forward + Vector3.right).normalized * 10;
	Vector3 back_left = (Vector3.back + Vector3.left).normalized * 10;
	Vector3 back_right = (Vector3.back + Vector3.right).normalized * 10;

	public AudioClip[] clips = new AudioClip[2];

	public void Awake()
	{
		v=new Vector3[] {Vector3.forward*10,forward_left,Vector3.left*10,back_left,Vector3.back*10,back_right,Vector3.right*10,forward_right};


		key=Resources.Load("ckey", typeof(GameObject)) as GameObject;
		fakekey[0]=Resources.Load("fakekey",typeof(GameObject)) as GameObject;
		fakekey[1]=Resources.Load("fakekey2",typeof(GameObject)) as GameObject;
		oneup=Resources.Load("player cube",typeof(GameObject)) as GameObject;
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Start () {
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;
		
		StartCoroutine(funcube());
	}

	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray")
		{
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag=="MainCamera")
		{
			RenderSettings.skybox=DSR;
			RenderSettings.ambientLight=Color.black;
		}
		else if(other.gameObject.tag=="light")
		{
			
			other.gameObject.light.enabled=false;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray"||other.gameObject.tag=="wall"||other.gameObject.tag=="itemp")
		{
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag=="MainCamera")
		{
			RenderSettings.skybox=normal;
			RenderSettings.ambientLight=new Color(0.75f,0.75f,0.75f);
		}
		else if(other.gameObject.tag=="light")
		{
			other.gameObject.light.enabled=true;
		}
		else if(other.gameObject.tag=="item")
		{
			Destroy(other.gameObject);
		}
		
	}


	void finish()
	{
		finished=true;
		broadcastall("countdown","wall");

	}
	
	void broadcastall(string fun,string tag) {
		GameObject[] gos = (GameObject[])GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject go in gos) {
			if (go) {
				go.gameObject.SendMessage(fun, SendMessageOptions.DontRequireReceiver);
			}
		}
	}


	IEnumerator funcube()
	{

		GameObject bb;
		int i=0,j=15;
		Vector3 axis;

		int number=(int)Random.value*77;

		while(i<5)
		{
			
			yspeed*=0.5f;
			i++;
			yield return new WaitForSeconds(0.4f);
		}
		yspeed=0;

		
		audio.Stop();
		audio.PlayOneShot(clips[0]);
		animation.Play("open");
		yield return new WaitForSeconds(3.0f);





		while(i<33)
		{


				if(i%7==0)
				{
					
					axis= new Vector3(transform.position.x,0,transform.position.z);
					
					bb = (GameObject)Instantiate (fakekey[1],v[4]+Vector3.up*10 , Quaternion.identity);
					bb.AddComponent ("fakekey");
					bb.GetComponent<fakekey> ().clockwise = true;
					bb.GetComponent<fakekey> ().yspeed = 2*Mathf.Cos(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().wspeed = 10*Mathf.Sin(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().type=1;
					

					axis= new Vector3(transform.position.x,0,transform.position.z);
					
					bb = (GameObject)Instantiate (fakekey[1],v[0]+Vector3.up*10 , Quaternion.identity);
					bb.AddComponent ("fakekey");
					bb.GetComponent<fakekey> ().clockwise = true;
					bb.GetComponent<fakekey> ().yspeed = 2*Mathf.Cos(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().wspeed = 10*Mathf.Sin(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().type=1;



					i++;
					
					//angle++;
					//v=Quaternion.AngleAxis(10,axis)*v;
					
					yield return new WaitForSeconds(0.2f);
				}
				else
				{
					axis= new Vector3(transform.position.x,0,transform.position.z);
					
					bb = (GameObject)Instantiate (fakekey[0],v[4]+Vector3.up*10 , Quaternion.identity);
					bb.AddComponent ("fakekey");
					bb.GetComponent<fakekey> ().clockwise = true;
					bb.GetComponent<fakekey> ().yspeed = 2*Mathf.Cos(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().wspeed = 10*Mathf.Sin(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().type=1;
					
					axis= new Vector3(transform.position.x,0,transform.position.z);
					
					bb = (GameObject)Instantiate (fakekey[0],v[0]+Vector3.up*10 , Quaternion.identity);
					bb.AddComponent ("fakekey");
					bb.GetComponent<fakekey> ().clockwise = true;
					bb.GetComponent<fakekey> ().yspeed = 2*Mathf.Cos(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().wspeed = 10*Mathf.Sin(Mathf.Deg2Rad*i*j);
					bb.GetComponent<fakekey> ().type=1;

					i++;
					
					//angle++;
					//v=Quaternion.AngleAxis(10,axis)*v;
					
					yield return new WaitForSeconds(0.2f);
				}
				
				if(i==33)
				{

					oneupentity=(GameObject)Instantiate (oneup, v[4]+Vector3.up*10 , Quaternion.identity);
					oneupentity.AddComponent ("oneup2_10");
					oneupentity.GetComponent<oneup2_10> ().yspeed=2*Mathf.Cos(Mathf.Deg2Rad*i*j);
					oneupentity.GetComponent<oneup2_10> ().wspeed=10*Mathf.Sin(Mathf.Deg2Rad*i*j);
				}
			}

			bb = (GameObject)Instantiate (key,Quaternion.Euler(0,180,0)*player.transform.position ,Quaternion.identity);
			bb.AddComponent ("key2_6");
			bb.GetComponent<key2_6> ().clockwise = true;
			bb.GetComponent<key2_6> ().yspeed = 4*(Random.value-0.5f);
			bb.GetComponent<key2_6> ().wspeed = 20*(Random.value-0.5f);

			i=0;
			while(finished!=true)
			{
				yield return new WaitForSeconds(1.0f);
			}
			
			animation.Play("close");
			yield return new WaitForSeconds(2.0f);
			audio.PlayOneShot(clips[1]);
			yield return new WaitForSeconds(2.0f);
			Destroy(gameObject);
			
			
	}






	void Update () {
		base.checkbound();
		
		transform.Translate (Vector3.down*yspeed*Time.deltaTime);
	}
}
