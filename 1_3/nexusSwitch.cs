using UnityEngine;
using System.Collections;

public class nexusSwitch : rands
{

	public AudioClip clips;
	public GameObject[] nexus = new GameObject[4];
	public GameObject container;
	public Vector3 speed;
	public int motionPeriod;

	void Start () {
		audio.volume=Control.volume;
		StartCoroutine(speedControl());
		collider.enabled = false;
	}

public IEnumerator speedControl()
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

	public void startGoToSurface(){}


	public override void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.tag=="shield")
		{
			other.SendMessage("secondaryAlarm",SendMessageOptions.DontRequireReceiver);
			for(int i=0;i<nexus.Length;i++)
			nexus[i].SendMessage ("changeTarget",SendMessageOptions.DontRequireReceiver);

		}
		else if(other.gameObject.tag=="ray")
		{
			container.SendMessage("startFadeIn",SendMessageOptions.DontRequireReceiver);
		}
	}


		// Update is called once per frame
		void Update ()
		{
			transform.Translate(speed*Time.deltaTime);
		}
}

