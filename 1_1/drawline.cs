using UnityEngine;
using System.Collections;

public class drawline : MonoBehaviour {

	LineRenderer render;


	public Vector3 origin=new Vector3(0,0,0);
	public Vector3 destination=new Vector3(0,0,0);
	Vector3 line;



	// Use this for initialization

	void Awake()
	{
		render=gameObject.GetComponent<LineRenderer>();
	}

	void Start () 
	{
		line=destination-origin;
		render.SetWidth(0.0f,0.0f);
		render.SetPosition(0,origin);
		render.SetPosition(1,origin+line*2);

		StartCoroutine(des ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator des()
	{
		float i=0;
		while(i<2.5)
		{
			render.SetWidth(i/40,i/40);

			i+=0.1f;
			yield return new WaitForSeconds(0.1f);
		}

		Destroy(gameObject);
	}


}
