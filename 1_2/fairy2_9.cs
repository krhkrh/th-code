using UnityEngine;
using System.Collections;

public class fairy2_9 : enemybasic {


	public float yspeed;
	GameObject rayshooter;
	public AudioClip shoot;



	public override void Awake ()
	{

		rayshooter=Resources.Load ("shooter4",typeof(GameObject)) as GameObject;
	}



	public override IEnumerator mainroutine ()
	{
		GameObject bb;


		while(true)
		{
			yspeed*=0.7f;
			if(yspeed<0.5)
			{
				yspeed=0;
				break;
			}
			yield return new WaitForSeconds(0.5f);
		}

		animation.CrossFade("shoot",0.3f);
		
		yield return new WaitForSeconds(1.3f);


		bb = (GameObject)Instantiate (rayshooter, transform.position , Quaternion.identity);
		bb.AddComponent ("shooter2_9");

		yield return new WaitForSeconds(21.0f);

		animation.CrossFade("move",0.3f);

		while(yspeed<10)
		{
			yspeed+=1.0f;

			yield return new WaitForSeconds(0.7f);
		}




	}

	new void Update()
	{
		base.checkbound();

		transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);

	}


}
