using UnityEngine;
using System.Collections;

public class nexusSwitch2 : rands
{


	public AudioClip clips;

	public GameObject container;
	public Vector3 speed;
	public int motionPeriod;

	public GameObject player;
	public int controlType;

	public GameObject[] nexus = new GameObject[6];


		// Use this for initialization
		void Start ()
		{
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


		// Update is called once per frame
		void Update ()
		{
			transform.Translate(speed*Time.deltaTime);
		}

		public override void OnTriggerEnter (Collider other)
		{
			if(other.gameObject.tag=="shield")
			{
				other.SendMessage("secondaryAlarm",SendMessageOptions.DontRequireReceiver);

				if(controlType == 0 )
				{
					for(int i=0;i<nexus.Length;i++)
						nexus[i].SendMessage ("changeTarget",SendMessageOptions.DontRequireReceiver);
				}
				else if (controlType == 1)
				{
					for(int i=0;i<nexus.Length;i++)
						nexus[i].SendMessage ("oppositeShooting",SendMessageOptions.DontRequireReceiver);
				}

				else if (controlType == 2)
				{
					for(int i=0;i<nexus.Length;i++)
						nexus[i].SendMessage ("shootPlayer",player.transform.position,SendMessageOptions.DontRequireReceiver);
				}
			}

		}
	
}

