using UnityEngine;
using System.Collections;

public class myscube2_6 : basic {


	float yspeed=24;
	bool finished=false;
	public Material DSR;
	public Material normal;

	GameObject key;
	GameObject player;
	GameObject brick_b,brick_r,brick_g;
	GameObject oneup;
	GameObject oneupentity;

	
	public AudioClip[] clips = new AudioClip[2];
	
	Vector3 forward_left = (Vector3.forward + Vector3.left).normalized * 10;
	Vector3 forward_right = (Vector3.forward + Vector3.right).normalized * 10;
	Vector3 back_left = (Vector3.back + Vector3.left).normalized * 10;
	Vector3 back_right = (Vector3.back + Vector3.right).normalized * 10;

	public void Awake()
	{

		v=new Vector3[] {Vector3.forward*10,forward_left,Vector3.left*10,back_left,Vector3.back*10,back_right,Vector3.right*10,forward_right};



		key=Resources.Load("ckey", typeof(GameObject)) as GameObject;
		brick_b=Resources.Load("brick_b", typeof(GameObject)) as GameObject;
		brick_r=Resources.Load("brick_r",typeof(GameObject)) as GameObject;
		brick_g=Resources.Load("brick_g",typeof(GameObject)) as GameObject;
		oneup=Resources.Load("player cube",typeof(GameObject)) as GameObject;

		player = GameObject.FindGameObjectWithTag ("Player");
	}


	void Start () {
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;

		StartCoroutine(funcube());
	}
	
	// Update is called once per frame
	void Update () {
		base.checkbound();
		
		transform.Translate (Vector3.down*yspeed*Time.deltaTime);
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
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray"||other.gameObject.tag=="wall")
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


		if(player.transform.position.y>5)
		{
			if(oneupentity!=null)
			{
				oneupentity.SendMessage("acce",false);
			}
			broadcastall("acce",false,"wall");
		}
		else
		{
			if(oneupentity!=null)
			{
				oneupentity.SendMessage("acce",true);
			}
			broadcastall("acce",true,"wall");
		}
	}
	
	void broadcastall(string fun,bool up,string tag) {
		GameObject[] gos = (GameObject[])GameObject.FindGameObjectsWithTag(tag);
		foreach (GameObject go in gos) {
			if (go) {
				go.gameObject.SendMessage(fun,up, SendMessageOptions.DontRequireReceiver);
			}
		}
	}


	IEnumerator funcube()
	{
		GameObject bb;
		int i=0,j=0;
		
		while(i<5)
		{
			
			yspeed*=0.5f;
			i++;
			yield return new WaitForSeconds(0.4f);
		}
		yspeed=0;
		i=0;
		
		audio.Stop();
		audio.PlayOneShot(clips[0]);
		animation.Play("open");
		yield return new WaitForSeconds(3.0f);




//		StartCoroutine(vertical(new Vector3(0,4,-10)));

//		StartCoroutine(horizontal(new Vector3(0,4,-10)));

		for(j=1;j<15;j++)
		{
			StartCoroutine( horizontal(Quaternion.Euler(0,-j*24,0)*v[0]+10*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}

		for(j=0;j<15;j++)
		{
			if(j==0||j==3||j==4||j==6||j==9||j==11||j==14)
				StartCoroutine(vertical(Quaternion.Euler(0,-j*24,0)*v[0]+10*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}

		for(j=0;j<15;j++)
		{
			if(j==2||j==7||j==8||j==12||j==14)
				StartCoroutine(	horizontal(Quaternion.Euler(0,-j*24,0)*v[0]+7*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}

		for(j=0;j<15;j++)
		{
			if(j==0||j==1||j==2||j==5||j==6||j==9||j==10||j==11||j==14)
				StartCoroutine(vertical(Quaternion.Euler(0,-j*24,0)*v[0]+7*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}


		for(j=0;j<15;j++)
		{
			if(j==3||j==5||j==8||j==9)
				StartCoroutine(horizontal(Quaternion.Euler(0,-j*24,0)*v[0]+4*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}


		for(j=0;j<15;j++)
		{
			if(j==1||j==5||j==12||j==10||j==13||j==14)
				StartCoroutine(	vertical(Quaternion.Euler(0,-j*24,0)*v[0]+4*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}


		for(j=0;j<14;j++)
		{

			StartCoroutine(horizontal(Quaternion.Euler(0,-j*24,0)*v[0]+1*Vector3.up));
			yield return new WaitForSeconds(0.1f);
		}

		if(player.transform.position.y<5)
		{
			bb = (GameObject)Instantiate (key, Vector3.up*13+v[0] , Quaternion.identity);
			bb.AddComponent ("key2_6");
			bb.GetComponent<key2_6> ().wspeed=22;
			bb.GetComponent<key2_6> ().yspeed=0;
		}
		else
		{
			bb = (GameObject)Instantiate (key, v[0]+Vector3.down, Quaternion.identity);
			bb.AddComponent ("key2_6");
			bb.GetComponent<key2_6> ().wspeed=22;
			bb.GetComponent<key2_6> ().yspeed=0;

		}

		oneupentity=(GameObject)Instantiate (oneup, Quaternion.Euler(0,-6.5f*24,0)*v[0]+8.5f*Vector3.up , Quaternion.identity);
		oneupentity.AddComponent ("oneup");
		oneupentity.GetComponent<oneup> ().yspeed=0;
		oneupentity.GetComponent<oneup> ().wspeed=10;





		i=0;
		while(finished!=true)
		{
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		
		animation.Play("close");
		yield return new WaitForSeconds(2.0f);
		audio.PlayOneShot(clips[1]);
		yield return new WaitForSeconds(2.0f);
		Destroy(gameObject);

	}

	void bottom(Vector3 v3)
	{
		StartCoroutine(horizontal(v3));
	}

	void unit(Vector3 v3)
	{
		StartCoroutine(vertical(v3));
		StartCoroutine(horizontal(v3));
	}

	IEnumerator vertical(Vector3 v3)
	{
		GameObject bb;


		bb=(GameObject)Instantiate (brick_r, v3+Vector3.down , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;

		yield return new WaitForSeconds(0.3f);
		bb=(GameObject)Instantiate (brick_b, v3+2*Vector3.down , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;
		
		yield return new WaitForSeconds(0.3f);
		bb=(GameObject)Instantiate (brick_g, v3+3*Vector3.down , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;
		
		yield return new WaitForSeconds(0.3f);

	}

	IEnumerator horizontal(Vector3 v3)
	{
		GameObject bb;

		bb=(GameObject)Instantiate (brick_g, Quaternion.Euler(0,0,0)*v3 , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;
		
		yield return new WaitForSeconds(0.3f);
		bb=(GameObject)Instantiate (brick_b, Quaternion.Euler(0,8,0)*v3 , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;
		
		yield return new WaitForSeconds(0.3f);
		bb=(GameObject)Instantiate (brick_r, Quaternion.Euler(0,16,0)*v3 , Quaternion.identity);
		bb.AddComponent ("wall2_6");
		bb.GetComponent<wall2_6> ().yspeed=0;
		bb.GetComponent<wall2_6> ().wspeed=5;
		
		yield return new WaitForSeconds(0.3f);


	}

}
