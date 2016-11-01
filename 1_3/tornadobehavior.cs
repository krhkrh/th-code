using UnityEngine;
using System.Collections;

public class tornadobehavior : rands {


	public bool tornadotype =true;
	IEnumerator adjustspeed()
	{
		int i=0,j=0;
		if(tornadotype)
		j=5;
		else j=-5;

		while(transform.position.y>-2)
		{
			wspeed= 7 * Mathf.Sin(Mathf.Deg2Rad*i*j);
			i++;
			if(i==72)
				i=0;
			yield return new WaitForSeconds(0.2f);
		}
		
		yield return new WaitForSeconds(1.0f);
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(adjustspeed());
	}
	

}
