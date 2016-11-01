using UnityEngine;
using System.Collections;

public class basecode : MonoBehaviour {
	public float yspeed=2.5f;
	public float top=60.0f;
	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="energy"||other.gameObject.tag=="entity"||other.gameObject.tag=="ray")
			Destroy(other.gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.down*yspeed*Time.deltaTime);
		if(transform.position.y<=-20)
		{
			transform.Translate(new Vector3(0,top,0));
		}
	}
}
