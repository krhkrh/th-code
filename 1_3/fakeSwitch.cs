using UnityEngine;
using System.Collections;

public class fakeSwitch : rands {

	// Use this for initialization
	void Start () {
	
		StartCoroutine(speedControl());
		collider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime);
	}

	public Vector3 speed;
	public int motionPeriod;
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


	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			halt();
		}
	}

}
