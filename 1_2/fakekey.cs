using UnityEngine;
using System.Collections;

public class fakekey : rands {





	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	void countdown()
	{
		StartCoroutine(slow());

	}
	IEnumerator slow()
	{
		while(true)
		{
			wspeed*=0.5f;
			yspeed*=0.5f;
			if(wspeed<5)
			{
				wspeed=0;
			if(yspeed<0.5f)
				{yspeed=0;break;}

			}

			yield return new WaitForSeconds(0.2f);
		}	
		halt();
	}

	void moveup()
	{
		gameObject.transform.Translate(Vector3.up*21);
	}

	void movedown()
	{
		gameObject.transform.Translate(Vector3.down*21);
	}

	
	// Update is called once per frame
	void Update () {

		if(transform.position.y<-3)
			moveup ();

		if(transform.position.y>19)
			movedown();


		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime);
		else
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime);

		if (clockwise == true)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
	}
}
