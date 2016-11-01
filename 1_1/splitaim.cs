using UnityEngine;
using System.Collections;

public class splitaim : aimedShoot {

	GameObject bb1;
	GameObject bb2;

	// Use this for initialization
	void Awake()
	{
		bb1 = Resources.Load ("b2_b", typeof(GameObject)) as GameObject;
		bb2 = Resources.Load ("b2_c", typeof(GameObject)) as GameObject;
		target=GameObject.FindGameObjectWithTag("Player");
	}

	public override void Start () {
		base.Start();
	}

	public override	void OnTriggerEnter(Collider other)
	{

		GameObject ab;
		if(other.gameObject.tag=="graze")
		{
			ab=(GameObject)Instantiate (bb1,transform.position,Quaternion.identity);
			ab.AddComponent("aimedShoot");
			ab.GetComponent<aimedShoot>().laps=0;
			ab.GetComponent<aimedShoot>().duration=2;
			ab.GetComponent<aimedShoot>().tytype=false;
			ab.GetComponent<aimedShoot>().type=true;
			
			ab=(GameObject)Instantiate (bb2,transform.position,Quaternion.identity);
			ab.AddComponent("aimedShoot");
			ab.GetComponent<aimedShoot>().laps=0;
			ab.GetComponent<aimedShoot>().duration=2;
			ab.GetComponent<aimedShoot>().tytype=false;
			ab.GetComponent<aimedShoot>().type=false;
			

			Destroy(gameObject);
		}

	}

	// Update is called once per frame
	public override void Update () {
		base.Update();

	}
}
