using UnityEngine;
using System.Collections;

public class IvyFruitBehavior : MonoBehaviour
{
	public Vector3 speed = Vector3.zero;
	Vector3 slowSpeed ;
	
	IEnumerator countdown()
	{
		int i=0;
		slowSpeed = speed *0.1f;
		while(i<3)
		{
			yield return new WaitForSeconds(1.0f);
			i++;
		}
		i=0;
		while(i<5)
		{
			slowSpeed = speed *i*0.2f;
			yield return new WaitForSeconds(0.2f);
			i++;
		}
		i=0;
		while(i<9)
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
		transform.Translate(slowSpeed*Time.deltaTime);
	}
}

