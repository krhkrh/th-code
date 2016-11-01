using UnityEngine;
using System.Collections;

public class freeBullet : basic
{

	public Vector3 speed;
	public int lifeSpan = 8;

	public override void Awake (){}

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			halt();
		}
		else if(other.gameObject.tag=="wall"||other.gameObject.tag=="base")
		{
			halt();
		}
	}

	void Start()
	{
		StartCoroutine(mainRoutine());
	}

	public virtual IEnumerator mainRoutine()
	{
		int i=0;
		while(i<lifeSpan)
		{
			i++;
			yield return new WaitForSeconds(1.0f);
		}

		halt();
	}

	void Update()
	{
		//warning changed here,may cause problem
		transform.Translate(speed*Time.deltaTime,Space.World);
	}

}

