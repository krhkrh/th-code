using UnityEngine;
using System.Collections;

public class fairy2_7 : fairy1_1 {

	GameObject bigshooter;
	GameObject entity;
	// Use this for initialization


	public override void remove ()
	{
		if(entity!=null)
			entity.SendMessage("stopfiring",SendMessageOptions.DontRequireReceiver);
		base.remove ();
		StartCoroutine(revenge());
	}

	public override void Awake ()
	{
		base.Awake ();
		bigshooter= Resources.Load("shooter2",typeof(GameObject)) as GameObject;

	}

	IEnumerator revenge()
	{
		GameObject bb;
		yield return new WaitForSeconds(8.0f);
		animation.CrossFade("instantattk",0.3f);
		yield return new WaitForSeconds(0.3f);
		bb = (GameObject)Instantiate (bigshooter, transform.position-transform.forward*3 , Quaternion.identity);
		bb.AddComponent("dirshooter");
		yield return new WaitForSeconds(1.0f);
		animation.CrossFade("move",0.5f);
	}

	public override IEnumerator mainroutine ()
	{

		while(true)
		{
			yspeed*=0.7f;
			if(yspeed<0.5f)
			{
				yspeed=0;
				break;
			}
			yield return new WaitForSeconds(0.6f);
		}

		animation.CrossFade("shoot",0.3f);
		
		yield return new WaitForSeconds(1.3f);
		if(health>0)
			animation.CrossFade("attack",0.3f);

		if(health>0)
		{
			entity = (GameObject)Instantiate (bigshooter, transform.position , Quaternion.identity);
			entity.AddComponent ("bigshooter");
			entity.GetComponent<bigshooter> ().type=this.type;

			yield return new WaitForSeconds(16.0f);
			
			animation.CrossFade("move",0.3f);

			yspeed=5;
		}

	}

	new void Update () {
		base.checkbound();
		if(status==1)
			transform.Translate (-Vector3.up * yspeed * Time.deltaTime,Space.World);
		else if(status==-1)
		{
			transform.Translate (escape * Time.deltaTime,Space.World);
			
		}
	}
}
