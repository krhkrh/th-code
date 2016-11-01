using UnityEngine;
using System.Collections;

public class drone : MonoBehaviour {

	GameObject bulletb,bulletr;
	GameObject bb;

	float speed=30.0f;
	int dronedamage=2;



	void Awake(){
		bulletr = Resources.Load ("bulletr", typeof(GameObject)) as GameObject;
		bulletb = Resources.Load ("bulletb", typeof(GameObject)) as GameObject;
		
		
	}
	
	// Use this for initialization
	void Start () 
	{
		//gameObject.SetActive(false);
	}

	void setdamage(int d)
	{
		dronedamage=d;
	}

	void setspeed(float s)
	{
		speed=s;
	}

	void enable()
	{
		gameObject.SetActive(true);
	}


	void fire(bool rb)
	{

		if(rb==true)
		{
			bb = (GameObject)Instantiate (bulletb, transform.position , Quaternion.identity);
			bb.AddComponent ("shibulletcode");
			bb.GetComponent<shibulletcode> ().up=true;
			bb.GetComponent<shibulletcode> ().yspeed=speed;
			bb.GetComponent<shibulletcode> ().damage=dronedamage;

		}
		
		else
		{
			bb = (GameObject)Instantiate (bulletr, transform.position, Quaternion.identity);
			bb.AddComponent ("shibulletcode");
			bb.GetComponent<shibulletcode> ().up=true;
			bb.GetComponent<shibulletcode> ().yspeed=speed;
			bb.GetComponent<shibulletcode> ().damage=dronedamage;
		}
	}
	// Update is called once per frame
	void Update () 
	{

	}
}
