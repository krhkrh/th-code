using UnityEngine;
using System.Collections;

public class tornadocolumn : rands {


	public bool tornadotype = true; 
	int t=0;


	// Use this for initialization
	void Start () {
		StartCoroutine(adjustSpeed());
	}

	public override void OnTriggerEnter (Collider other){}




	IEnumerator adjustSpeed()
	{

		while(true)
		{
			if(tornadotype)
			{

				if(up)
				{
					if(transform.position.y>17.0f)
					{
						up=!up;
					}
				}
				else
				{
					if(transform.position.y<-2.0f)
					{
						up=!up;
					}
				}


			}
			else{

				if(up)
				{
					if(transform.position.y>14.0f)
					{
						up=!up;
					}
				}
				else
				{
					if(transform.position.y<1.0f)
					{
						up=!up;
					}
				}



			}
			yield return  new WaitForSeconds(0.1f);

		}

	}


}
