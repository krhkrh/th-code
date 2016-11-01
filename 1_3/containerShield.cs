using UnityEngine;
using System.Collections;

public class containerShield : rands
{
	public int durableTime =2;
	int countDown = 0;
	bool isFirstHit = true;
	int states = 0;
	public Vector3 speed;
	public int motionPeriod;
	public GameObject containedObject;
	public int switchType =0;
	AudioClip[] clips = new AudioClip[2];

	public override void Awake ()
	{
		audio.volume = Control.volume;
		clips[0] = Resources.Load("sound/large_bubbly_whoosh_rnd_01",typeof(AudioClip)) as AudioClip;
		clips[1] = Resources.Load("sound/spin_01",typeof(AudioClip)) as AudioClip;
	}


	public override void OnTriggerEnter(Collider other)
	{
		if(switchType==0)
		{
			if(other.tag == "ray")
			{
				if(isFirstHit)
				{
					isFirstHit = false;
					StartCoroutine(startCountDown());
				}
				else{
					if(states==0)
						countDown =0;
				}
				Destroy(other.gameObject);
			}
			else if(other.tag == "key")
			{
				containedObject = other.gameObject;
			}
		}
		else if(switchType == 1)
		{
			if(other.tag == "ray")
			{
				Destroy(other.gameObject);
				countDown=0;
			}
		}

		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}


	IEnumerator fadeout()
	{
		int i=0;
		audio.PlayOneShot(clips[1]);
		Color tempcolor = renderer.material.color;
		while(i<10)
		{
			tempcolor.a -= 0.1f;
			renderer.material.color = tempcolor;
			i++;
			yield return new WaitForSeconds(0.1f);
		}

		containedObject.SendMessage("startGoToSurface",SendMessageOptions.DontRequireReceiver);

		renderer.enabled=false;
		gameObject.collider.enabled = false;
	}

	public void startFadeIn()
	{
		StartCoroutine(fadeIn());
		StartCoroutine(startCountDown());
	}

	IEnumerator fadeIn()
	{
		int i=0;
		audio.PlayOneShot(clips[0]);
		renderer.enabled = true;
		gameObject.collider.enabled = true;
		Color tempcolor = renderer.material.color;
		while(i<10)
		{
			tempcolor.a += 0.1f;
			renderer.material.color = tempcolor;
			i++;
			yield return new WaitForSeconds(0.1f);
		}
	}


	IEnumerator startCountDown()
	{
		while(countDown < durableTime)
		{
			countDown++;
			yield return new WaitForSeconds(1.0f);
		}
		countDown=0;
		states =1;
		StartCoroutine(fadeout());
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
		if(switchType==1)
		{
			StartCoroutine(startCountDown());
		}
	}

	void Start()
	{
		StartCoroutine(speedControl());
	}

		// Update is called once per frame
		void Update ()
		{
		transform.Translate(speed*Time.deltaTime);
		}
}

