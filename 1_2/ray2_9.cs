using UnityEngine;
using System.Collections;

public class ray2_9 : basic {

	// Use this for initialization
	new void Awake()
	{}

	void Start () {

	}

	public override void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag=="Player")
		{
			other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
		base.checkbound();
		transform.Translate(gameObject.transform.forward*50*Time.deltaTime,Space.World);
	}
}
