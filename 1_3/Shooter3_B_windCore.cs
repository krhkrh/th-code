using UnityEngine;
using System.Collections;

public class Shooter3_B_windCore : shooterbasic
{
	GameObject[] bt2 = new GameObject[3];

	public override void Awake ()
	{
		
		base.Awake ();
		bt2[0]=Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2[1]=Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2[2]=Resources.Load("bt2_v",typeof(GameObject)) as GameObject;

		audio.rolloffMode = AudioRolloffMode.Linear;

	}
	public override IEnumerator mainroute ()
	{

		// wind core
		Vector3 sample1;
		Vector3 sample2;
		Vector3 sample3;
		float overAllSpeed = 5;
		
		int i = 0;
		int j = 0;
		Vector3 shootingDirection1 = new Vector3(0,1,0);
		sample1 = Vector3.forward;
		
		Vector3 shootingDirection2 = new Vector3(1, 0, 0);
		sample2 = Vector3.up;
		
		Vector3 shootingDirection3 = new Vector3(0, 0, 1);
		sample3 = Vector3.right;
		
		GameObject bb;
		for (j = 0; j < 18; j++)
		{
			for (i = 0; i < 18; i++)
			{
				bb = (GameObject)Instantiate(bt2[0], transform.position + shootingDirection1/2, Quaternion.identity);
				bb.AddComponent<freeBullet>();
				bb.GetComponent<freeBullet>().speed = shootingDirection1 * overAllSpeed;
				bb.GetComponent<freeBullet>().lifeSpan = 5;
				
				bb = (GameObject)Instantiate(bt2[1], transform.position + shootingDirection2/2, Quaternion.identity);
				bb.AddComponent<freeBullet>();
				bb.GetComponent<freeBullet>().speed = shootingDirection2 * overAllSpeed;
				bb.GetComponent<freeBullet>().lifeSpan = 5;
				
				bb = (GameObject)Instantiate(bt2[2], transform.position + shootingDirection3/2, Quaternion.identity);
				bb.AddComponent<freeBullet>();
				bb.GetComponent<freeBullet>().speed = shootingDirection3 * overAllSpeed;
				bb.GetComponent<freeBullet>().lifeSpan = 5;
				yield return new WaitForSeconds(0.1f);

				shootingDirection1 = Quaternion.AngleAxis(20, sample1) * shootingDirection1;
				
				shootingDirection2 = Quaternion.AngleAxis(20, sample2) * shootingDirection2;
				
				shootingDirection3 = Quaternion.AngleAxis(20, sample3) * shootingDirection3;

				if(i%2 == 0)
				{
					audio.Play();
				}

				
			}

			yield return new WaitForSeconds(0.1f);
			sample1 = Quaternion.Euler(0, 20, 0) * sample1;
			sample2 = Quaternion.Euler(20, 0, 0) * sample2;
			sample3 = Quaternion.Euler(0, 0, 20) * sample3;
		}
		halt();

	}

	public override void Start()
	{
		audio.Play();
		base.Start();
	}

}

