using UnityEngine;
using System.Collections;

public class decdust : MonoBehaviour {

	float wspeed= 10.0f;
	// Use this for initialization
	void Start () {
		StartCoroutine(countdown());

	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround(Camera.main.transform.position,new Vector3(1,1,0),wspeed*Time.deltaTime);
	}

	IEnumerator countdown()
	{
		yield return new WaitForSeconds(70.0f);
		Destroy(gameObject);
	}
}
