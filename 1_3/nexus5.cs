using UnityEngine;
using System.Collections;

public class nexus5 : shooterbasic
{
	public GameObject[] target =new GameObject[2];
	public int nexusType= simutanous;
	public int targetKind=0;
	public GameObject currentTarget;
	public Vector3 speed;
	public int motionPeriod = 5;

	float wSpeed = 20;

	public const int simutanous = 0,transpass = 1,endPoint = 2;
	public Vector3 shootingDirection;

	public GameObject bt;
	public virtual void Awake()
	{
		bt=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
	}


	public void setTarget1(GameObject obj)
	{
		this.target[0] = obj;
	}

	public void setTarget2(GameObject obj)
	{
		this.target[1] = obj;
	}

	private void changeTarget()
	{
		if(targetKind == 0)
			targetKind =1;
		else if (targetKind ==1)
			targetKind =0;

		currentTarget = target[targetKind];
		shootingDirection = (currentTarget.transform.position-transform.position).normalized;

	}

	private void oppositeShooting()
	{
		if(targetKind == 0)
		{
			createBullet(target[1].transform.position);
		}
			
		else if (targetKind ==1)
		{

			createBullet(target[0].transform.position);
		}

	}

	private void shootPlayer(Vector3 player)
	{
		createBullet(player);
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
		currentTarget = target[targetKind];


		shootingDirection = (currentTarget.transform.position-gameObject.transform.position).normalized;
		
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

	private IEnumerator spawnBullets()
	{
		while(!finish)
		{
			createBullet(false);
			
			yield return new WaitForSeconds(0.7f);
			this.changeTarget();

		}
	}


	public override void Update ()
	{
		
		transform.Translate(speed*Time.deltaTime);
		transform.Rotate(Vector3.down * wSpeed * Time.deltaTime);
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


	private void createBullet(Vector3 targetTransform)
	{
		GameObject bb;
		audio.Play();
		Vector3 tempDirection = (targetTransform - transform.position).normalized;

		bb = (GameObject)Instantiate (bt,gameObject.transform.position + tempDirection, Quaternion.identity);
		bb.AddComponent("freeBullet");
		bb.tag = "ray";
		bb.GetComponent<freeBullet> ().speed = tempDirection*7;
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
}

