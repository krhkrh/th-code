using UnityEngine;
using System.Collections;

public class dec_fade : MonoBehaviour {

	public Vector3 speed = Vector3.zero;
	public int lifeSpan = 10;

	IEnumerator countdown()
	{
		int i=0;
		while(i< lifeSpan)
		{
			yield return new WaitForSeconds(1.0f);
				i++;
		}

		Destroy(gameObject);
	}


	// Use this for initialization
	void Start () {
		StartCoroutine(countdown());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime);
	}
}
