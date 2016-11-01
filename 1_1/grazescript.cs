using UnityEngine;
using System.Collections;

public class grazescript : MonoBehaviour {

	GameObject player;
	int count=0;
	int status=0;
	GameObject power;
	float shieldtime=10.0f;

	public AudioClip[] clips=new AudioClip[4];
	float volume = Control.volume;

	// Use this for initialization
	void Awake(){
		player=GameObject.FindGameObjectWithTag ("Player");
		power = Resources.Load ("power cube", typeof(GameObject)) as GameObject;
		}

	void Start () {
		renderer.enabled=false;
		audio.volume=volume;
	}

	void activitshield()
	{
		renderer.enabled=true;
		status=1;
		StartCoroutine(fadein());
		StartCoroutine(countdown());
	}

	IEnumerator fadein()
	{
		int i=0;
		audio.PlayOneShot(clips[2]);
		Color tempcolor = renderer.material.color;
		while(i<10)
		{
			tempcolor.a += 0.1f;
			renderer.material.color = tempcolor;
			i++;
			yield return new WaitForSeconds(0.1f);
		}


	}

	IEnumerator fadeout()
	{
		int i=0;
		audio.PlayOneShot(clips[3]);
		Color tempcolor = renderer.material.color;
		while(i<10)
		{
			tempcolor.a -= 0.1f;
			renderer.material.color = tempcolor;
			i++;
			yield return new WaitForSeconds(0.1f);
		}

		status=0;
		player.SendMessage("setbombready",true,SendMessageOptions.DontRequireReceiver);
		renderer.enabled=false;
	}


	IEnumerator countdown()
	{
		yield return new WaitForSeconds(shieldtime);


		StartCoroutine(fadeout());
	}


	void OnTriggerStay(Collider other)
	{
		GameObject bb;
		if(status==1)
		{
			Vector3 v1=other.gameObject.transform.position;
			Vector3 v2=new Vector3(v1.x,0,v1.z).normalized*10;
			v1=new Vector3(0,v1.y,0);

			if(other.gameObject.tag=="ray"||other.gameObject.tag=="entity"||other.gameObject.tag=="energy")
			{
				if(!audio.isPlaying)
				{
					audio.PlayOneShot(clips[1]);
				}
				bb = (GameObject)Instantiate (power, v2+v1, Quaternion.identity);
				bb.AddComponent("itembasic");
				bb.GetComponent<itembasic> ().yspeed=-10;
				bb.GetComponent<itembasic> ().up=false;
				bb.GetComponent<itembasic> ().type=0;
				
				other.gameObject.SendMessage("halt",SendMessageOptions.DontRequireReceiver);
			}
		}
		
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject bb;
		if(status==0)
		{


			if(other.gameObject.tag=="ray"||other.gameObject.tag=="entity"||other.gameObject.tag=="energy")
			{
				count++;
				if(!audio.isPlaying)
				audio.PlayOneShot(clips[0]);
			}


			if(count==10)
			{


				bb = (GameObject)Instantiate (power, transform.position+Vector3.up*2, Quaternion.identity);
				bb.AddComponent("itembasic");
				bb.GetComponent<itembasic> ().yspeed=-10;
				bb.GetComponent<itembasic> ().up=false;
				bb.GetComponent<itembasic> ().type=0;
				count=0;
			}
		}
		else if(status==1)
		{
			Vector3 v1=other.gameObject.transform.position;
			Vector3 v2=new Vector3(v1.x,0,v1.z).normalized*10;
			v1=new Vector3(0,v1.y,0);

			if(other.gameObject.tag=="ray"||other.gameObject.tag=="entity"||other.gameObject.tag=="energy")
			{
				bb = (GameObject)Instantiate (power, v2+v1, Quaternion.identity);
				bb.AddComponent("itembasic");
				bb.GetComponent<itembasic> ().yspeed=-10;
				bb.GetComponent<itembasic> ().up=false;
				bb.GetComponent<itembasic> ().type=0;

				other.gameObject.SendMessage("halt",SendMessageOptions.DontRequireReceiver);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.down *30 * Time.deltaTime);
	}
}
