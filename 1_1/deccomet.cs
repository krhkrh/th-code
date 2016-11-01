using UnityEngine;
using System.Collections;

public class deccomet : MonoBehaviour {

	float duration =3.0f;
	public Vector3 des;
	Vector3 speed;
	// Use this for initialization
	void Start () {
		speed = (des-gameObject.transform.position)/duration;
		StartCoroutine(countdown());
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(speed*Time.deltaTime);
	}

	IEnumerator countdown()
	{
		yield return new WaitForSeconds(30.0f);
		Destroy(gameObject);
	}
}
