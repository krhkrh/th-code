using UnityEngine;
using System.Collections;

public class giantbomb : basic {

	// Use this for initialization
	float yspeed=24;
	Vector3 sc= new Vector3(0.02f,0.02f,0.02f);
	public AudioClip[] clips=new AudioClip[2];

	void Start () {
		transform.localScale=sc;
		audio.rolloffMode = AudioRolloffMode.Linear;
		setdamage(100);
		StartCoroutine(giantboom());
	}

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player"||other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		base.checkbound();

		transform.Translate (Vector3.back*yspeed*Time.deltaTime);
	}

	void OnTriggerStay(Collider other)
	{
	
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray")
		{
			Destroy(other.gameObject);
		}
	}
	IEnumerator giantboom()
	{
		
		int i=0;
		audio.PlayOneShot(clips[0]);
		while(i<5)
		{

			yspeed*=0.5f;
			i++;
			yield return new WaitForSeconds(0.4f);
		}

		audio.Stop();
		audio.PlayOneShot(clips[1]);
		animation.Play();
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
	}
}
