using UnityEngine;
using System.Collections;

public class wall2_6 : straightline {

	// Use this for initialization
	void Start () {
	
	}

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
		else if(other.gameObject.tag=="wall")
		{
			halt();
		}
	}

	IEnumerator ac()
	{
		while(transform.position.y<15&&transform.position.y>-2)
		{
			yspeed+=2;
			yield return new WaitForSeconds(0.2f);
		}
	}

	void acce(bool u)
	{
		up=u;
		StartCoroutine(ac());
	}

	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
