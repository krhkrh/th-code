using UnityEngine;
using System.Collections;

public class decfirework : MonoBehaviour {


	public Vector3 center=new Vector3(3,10,-100);

	Vector3 speed;
	// Use this for initialization
	void Start () 
	{
		StartCoroutine(countdown());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(speed*Time.deltaTime);
	}

	IEnumerator countdown()
	{
		int i=0;
		yield return new WaitForSeconds(10.0f);

		while(i<60)
		{
			speed= new Vector3(Random.Range(-20,20),Random.Range(-20,20),Random.Range(-20,20))+center-gameObject.transform.position;
			yield return new WaitForSeconds(1.0f);
			i++;
		}
		Destroy(gameObject);
	}

}
