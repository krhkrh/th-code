using UnityEngine;
using System.Collections;

public class blast6 : basic {

	GameObject ab;
	public float threshold=1.0f;
	public float yspeed=20.0f;
	public AudioClip clips;
	// Use this for initialization

	void Awake()
	{
		ab = Resources.Load ("b2_v", typeof(GameObject)) as GameObject;
	}

	void Start () {
		threshold=Random.value*2.5f;
		StartCoroutine(countdown());
		audio.volume=Control.volume;
		audio.rolloffMode = AudioRolloffMode.Logarithmic;
	}


	// Update is called once per frame
	void Update () {base.checkbound();transform.Translate(Vector3.down*yspeed*Time.deltaTime);}


	IEnumerator countdown()
	{
		GameObject bb;
		float wr=Random.value*90;
		float yr=wr/18;


		yield return new WaitForSeconds(threshold);

		audio.PlayOneShot(clips);

		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=0;
		bb.GetComponent<countbullet> ().up=true;
		bb.GetComponent<countbullet> ().yspeed=yr*2.5f;
		bb.GetComponent<countbullet> ().ydown=yr*1.25f;
		bb.GetComponent<countbullet> ().threshold=2.5f;

		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=0;
		bb.GetComponent<countbullet> ().up=false;
		bb.GetComponent<countbullet> ().yspeed = yr*2.5f;
		bb.GetComponent<countbullet> ().ydown = yr*1.25f;
		bb.GetComponent<countbullet> ().threshold = 2.5f;



		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=wr;
		bb.GetComponent<countbullet> ().clockwise=false;
		bb.GetComponent<countbullet> ().up=false;
		bb.GetComponent<countbullet> ().wdown=wr/2;
		bb.GetComponent<countbullet> ().yspeed = yr;
		bb.GetComponent<countbullet> ().ydown = yr/2;
		bb.GetComponent<countbullet> ().threshold = 2.5f;

		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=wr;
		bb.GetComponent<countbullet> ().clockwise=true;
		bb.GetComponent<countbullet> ().up=false;
		bb.GetComponent<countbullet> ().wdown=wr/2;
		bb.GetComponent<countbullet> ().yspeed = yr;
		bb.GetComponent<countbullet> ().ydown = yr/2;
		bb.GetComponent<countbullet> ().threshold = 2.5f;
		
		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=wr;
		bb.GetComponent<countbullet> ().clockwise=false;
		bb.GetComponent<countbullet> ().up=true;
		bb.GetComponent<countbullet> ().wdown=wr/2;
		bb.GetComponent<countbullet> ().yspeed = yr;
		bb.GetComponent<countbullet> ().ydown = yr/2;
		bb.GetComponent<countbullet> ().threshold = 2.5f;

		bb = (GameObject)Instantiate (ab, gameObject.transform.position , Quaternion.identity);
		bb.AddComponent ("countbullet");
		bb.GetComponent<countbullet> ().wspeed=wr;
		bb.GetComponent<countbullet> ().clockwise=true;
		bb.GetComponent<countbullet> ().up=true;
		bb.GetComponent<countbullet> ().wdown=wr/2;
		bb.GetComponent<countbullet> ().yspeed = yr;
		bb.GetComponent<countbullet> ().ydown = yr/2;
		bb.GetComponent<countbullet> ().threshold = 2.5f;
		
	


		
	}
	
}
