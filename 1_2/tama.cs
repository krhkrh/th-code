using UnityEngine;
using System.Collections;

public class tama : basic {

	void setvolume(float f)
	{
		audio.volume=f;
	}
	// Use this for initialization
	void Start () {
		damage=30;
		setvolume(0.3f);
		StartCoroutine(countdown());
	}

	IEnumerator countdown()
	{


		yield return new WaitForSeconds(5.5f);
		audio.Play ();
		yield return new WaitForSeconds(1.5f);


		Destroy(gameObject);
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
	}
}
