using UnityEngine;
using System.Collections;

public class nexus : shooterbasic
{

	public Vector3 speed;
	public GameObject[] target =new GameObject[2];
	public GameObject currentTarget;
	public Vector3 shootingDirection;
	public GameObject bt;
	int targetKind=0;
	public int motionPeriod = 5;
	public float wSpeed = 20;

	public const int simutanous = 0,transpass = 1,endPoint = 2;

	public int nexusType = simutanous;


	public virtual void Awake()
	{
		bt=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
	}

	public override IEnumerator mainroute ()
	{

		int i=0;

		while(i<motionPeriod)
		{
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		i=0;
		while(i<5)
		{
			
			speed+=Vector3.up;
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		speed=Vector3.zero;

		shootingDirection = (currentTarget.transform.position-transform.position).normalized;

		if(nexusType == simutanous)
		{
			StartCoroutine(spawnBullets());
		}


	}

	public bool finish = false;

	public void finalize()
	{
		finish = true;
	}

	IEnumerator spawnBullets()
	{


		while(!finish)
		{
			createBullet(true);

			yield return new WaitForSeconds(0.5f);
		}

	}
	void resetAll()
	{
		currentTarget = target[0];
		
		shootingDirection = (currentTarget.transform.position-transform.position).normalized;
	}

	public override void Update ()
	{

		transform.Translate(speed*Time.deltaTime);
		transform.Rotate(Vector3.up * wSpeed *Time.deltaTime);

	}

	public void OnTriggerEnter(Collider other)
	{
		if(nexusType!=simutanous)
		{
			if(other.tag == "ray")
			{
				if(nexusType == transpass)
				{
					createBullet(true);
				}
				else if(nexusType == endPoint)
				{
					createBullet(false);
				}
			}
		}
	}


	private void createBullet(bool directed)
	{
		GameObject bb;
		audio.Play();

		if(directed)
		{
			bb = (GameObject)Instantiate (bt,gameObject.transform.position, Quaternion.identity);
			bb.AddComponent("freeBullet");
			bb.tag = "ray";
			bb.GetComponent<freeBullet> ().speed=shootingDirection*7;
		}

		else{


			bb = (GameObject)Instantiate (bt,gameObject.transform.position + shootingDirection, Quaternion.identity);
			bb.AddComponent("freeBullet");
			bb.tag="ray";
			bb.GetComponent<freeBullet> ().speed=shootingDirection*7;

		}


	}

	public void changeTarget()
	{
		targetKind++;

		if(targetKind<target.Length); 
		else targetKind=0;

		currentTarget = target[targetKind];

		shootingDirection = (currentTarget.transform.position-transform.position).normalized;
	}



}




