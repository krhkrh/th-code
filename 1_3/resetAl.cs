
using UnityEngine;
using System.Collections;

public class resetAl : rands
{
	public AudioClip clips;
	public GameObject[] nexus = new GameObject[8];

	public Vector3 speed;
	public int motionPeriod;
		// Use this for initialization
		void Start ()
		{
		audio.volume=Control.volume;
		StartCoroutine(speedControl());
		collider.enabled = false;
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
		collider.enabled = true;
	}

	public override void OnTriggerEnter(Collider other)
	{
		
		if(other.gameObject.tag=="shield")
		{
			other.SendMessage("secondaryAlarm",SendMessageOptions.DontRequireReceiver);
			for(int i=0;i<8;i++)
				nexus[i].SendMessage ("resetAll",SendMessageOptions.DontRequireReceiver);
			
		}
	}

		// Update is called once per frame
		void Update ()
		{
		transform.Translate(speed*Time.deltaTime);
		}
}

