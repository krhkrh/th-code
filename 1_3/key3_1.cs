using UnityEngine;
using System.Collections;

public class key3_1 : MonoBehaviour
{

	public AudioClip clips;
	GameObject myscude;
	public Vector3 speed;
	public int motionPeriod;

	void Awake()
	{
		myscude=GameObject.FindGameObjectWithTag("myscube");
	}
	// Use this for initialization
	void Start () {
		audio.volume=Control.volume;
		StartCoroutine(speedControl());
		//	yspeed=0;
	}

	IEnumerator speedControl()
	{
		int i=0;
		
		while(i<motionPeriod)
		{
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		i=0;
		while(i<5)
		{
			
			speed+=Vector3.up;
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		speed=Vector3.zero;
	}


 	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.SendMessage("alarm",SendMessageOptions.DontRequireReceiver);
			myscude.SendMessage ("finish",SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}


	Vector3 getHorizontalVector(Transform t)
	{
		return new Vector3(t.position.x,0,t.position.z);
	}

	public void startGoToSurface()
	{
		StartCoroutine(goToSurface());
	}

	IEnumerator goToSurface()
	{

		Vector3 vr = getHorizontalVector(gameObject.transform);
		speed = -vr.normalized;
		while(vr.sqrMagnitude>100)
		{
			vr= getHorizontalVector(gameObject.transform);
			yield return new WaitForSeconds(0.1f);
		}
		speed =Vector3.zero;

	}

	void Update()
	{

		transform.Translate(speed*Time.deltaTime);
	}



}

