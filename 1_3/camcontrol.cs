using UnityEngine;
using System.Collections;

public class camcontrol : MonoBehaviour {


	public GameObject controller;

	Vector3 v1,v2;
	float ratio=1.0f;
	// Use this for initialization
	void Start () {

	}

	private void setscale(float scale)
	{
		transform.localScale = new Vector3(scale,scale,scale);
	}

	public const int SMALL = 0,NORMAL = 1,LARGE = 2;
	public void setSize(int i)
	{
		switch(i)
		{
			case SMALL: {transform.localScale = new Vector3(2,2,2);}break;
			case NORMAL: {transform.localScale = new Vector3(4,4,2);}break;
			case LARGE: {transform.localScale = new Vector3(6,6,2);}break;
			default:break;
		}
	}


	public void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",5,SendMessageOptions.DontRequireReceiver);
			
		}

		else if(other.gameObject.tag == "energy"||other.gameObject.tag=="bullet")
		{
			Destroy(other.gameObject);
		}

	}


	// Update is called once per frame
	void Update () {
			
		Vector3 v1 = new Vector3(controller.transform.position.x,0,controller.transform.position.z);

		v2 = v1.normalized*10;

		ratio = v1.magnitude/v2.magnitude;

		v2.y = (controller.transform.position.y-5)/ratio+5; 

		transform.position = v2;

		transform.rotation = Quaternion.LookRotation(v1);


	}
}
