using UnityEngine;
using System.Collections;

public class raynehavier : MonoBehaviour {

	//public Vector3 v;


	// Use this for initialization
	void Start () {
		StartCoroutine(countdown());



	//	transform.rotation= Quaternion.Euler(90,0,0)*rotation;

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(gameObject.transform.forward*100*Time.deltaTime,Space.World);
	}



	IEnumerator countdown()
	{
		yield return new WaitForSeconds(30.0f);
		Destroy(gameObject);
	}

}
