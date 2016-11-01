using UnityEngine;
using System.Collections;

public class myscude :basic {
	float yspeed=24;
	bool finished=false;
	public Material DSR;
	public Material normal;
	GameObject wall;
	GameObject b;
	Vector3 va=new Vector3(0,19.0f,0);

	public AudioClip[] clips=new AudioClip[2];

	Vector3 forward_left = (Vector3.forward + Vector3.left).normalized * 10;
	Vector3 forward_right = (Vector3.forward + Vector3.right).normalized * 10;
	Vector3 back_left = (Vector3.back + Vector3.left).normalized * 10;
	Vector3 back_right = (Vector3.back + Vector3.right).normalized * 10;

	void Awake()
	{
		v=new Vector3[] {Vector3.forward*10,forward_left,Vector3.left*10,back_left,Vector3.back*10,back_right,Vector3.right*10,forward_right};
		wall = Resources.Load("wall", typeof(GameObject)) as GameObject;
		b=Resources.Load("key", typeof(GameObject)) as GameObject;
	}

	// Use this for initialization
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

	}

	void finish()
	{
		finished=true;
		broadcastall("fin","wall");
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

		for(i=0;i<4;i++)
		{
			for(j=0;j<8;j++)
			{
				bb = (GameObject)Instantiate (wall, v[j]+va , Quaternion.Euler(0,j*-45.0f,0));
				if(i%2==0)
					bb.GetComponent<roll>().clockwise =true;
				else
					bb.GetComponent<roll>().clockwise =false;
			}
			yield return new WaitForSeconds(1.0f);
		}
		yield return new WaitForSeconds(1.0f);


		bb = (GameObject)Instantiate (b, v[0]+va , Quaternion.identity);
		bb.AddComponent ("key");
		bb.GetComponent<key> ().wspeed=22;

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
}
