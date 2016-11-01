using UnityEngine;
using System.Collections;

public class rocketline : MonoBehaviour {

	public bool up=false;
	public float yspeed=15;
	public int type=1;

	// Use this for initialization
	void Start () {
	
	}




	void halt()
	{
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {

		if(transform.position.y<-40||transform.position.y>60)
			halt();

		if(up==true)
			transform.Translate (Vector3.up * yspeed * Time.deltaTime,Space.World);
		else
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);
	}
}
