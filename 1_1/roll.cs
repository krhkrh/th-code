using UnityEngine;
using System.Collections;

public class roll : rands {




	// Use this for initialization
	void Start () {
	
	}
	void fin()
	{
		StartCoroutine(bonus());
	}

	IEnumerator bonus()
	{
		int i=0;
		while(i<4)
		{
			yspeed*=0.7f;
			wspeed*=0.7f;
			i++;
			yield return new WaitForSeconds(0.25f);
		}

		yspeed=0;
		wspeed=0;
		

		yield return new WaitForSeconds(1.5f);
		//bonus here
		Destroy(gameObject);
	}


	// Update is called once per frame
	void Update () {


			if(transform.position.y<-4)
				base.movetostart();
			
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
