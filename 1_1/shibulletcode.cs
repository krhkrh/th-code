using UnityEngine;
using System.Collections;

public class shibulletcode : straightline {


	public int enemydamage=1;
	// Use this for initialization
	void Start () {
		setdamage(1);
	}

	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="enemy"||other.gameObject.tag=="boss" || other.gameObject.tag == "bossParent")
		{
			other.gameObject.SendMessage("applydamage",enemydamage,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	public override void Update () {
		base.Update();	
	}
}
