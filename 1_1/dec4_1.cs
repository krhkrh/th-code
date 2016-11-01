using UnityEngine;
using System.Collections;

public class dec4_1 : MonoBehaviour {

	// Use this for initialization
	GameObject ray;
	GameObject target;
	void Awake()
	{
		ray = Resources.Load ("rayparent", typeof(GameObject)) as GameObject;
		target= GameObject.FindGameObjectWithTag("decoration");


	}

	void Start () 
	{

		StartCoroutine(behavier());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator behavier()
	{
		GameObject bb;
		int i=0;
		Vector3 v=Vector3.zero;
		yield return new WaitForSeconds(10.0f);
		while(i<300)
		{
			if(target!=null)
			v= (target.transform.position- gameObject.transform.position).normalized;
			else break;

			bb = (GameObject)Instantiate (ray , gameObject.transform.position , Quaternion.LookRotation(v));
			bb.AddComponent ("raynehavier");
			yield return  new WaitForSeconds(0.2f);
			i++;
		}
		Destroy(gameObject);
	}

}
