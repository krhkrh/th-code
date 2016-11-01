using UnityEngine;
using System.Collections;

public class shooter2_2 : shooterbasic {


	public GameObject elipse;

	public override IEnumerator mainroute ()
	{
		GameObject bb;
		float w=(Random.value+1)*20, y=(Random.value+1)*10;

		Vector3 axis= new Vector3(transform.position.x,0,transform.position.z);
		float angle=90-Mathf.Atan2(y,Mathf.Deg2Rad*w*10)*Mathf.Rad2Deg;
		audio.Play();
		bb = (GameObject)Instantiate (elipse, gameObject.transform.position ,Quaternion.Euler(90,0,0)*Quaternion.AngleAxis(angle,axis));
		bb.AddComponent ("rands");
		bb.GetComponent<rands> ().wspeed=w*1.1f;
		bb.GetComponent<rands> ().yspeed=y*1.1f;
		bb.transform.localScale = Vector3.one*0.5f;
		yield return new WaitForSeconds(0.1f);
		bb = (GameObject)Instantiate (elipse, gameObject.transform.position ,Quaternion.Euler(90,0,0)*Quaternion.AngleAxis(angle,axis));
		bb.AddComponent ("rands");
		bb.GetComponent<rands> ().wspeed=w;
		bb.GetComponent<rands> ().yspeed=y;
		bb.transform.localScale = Vector3.one*0.5f;
		yield return new WaitForSeconds(0.1f);
		bb = (GameObject)Instantiate (elipse, gameObject.transform.position , Quaternion.Euler(90,0,0)*Quaternion.AngleAxis(angle,axis));
		bb.AddComponent ("rands");
		bb.GetComponent<rands> ().wspeed=w*0.9f;
		bb.GetComponent<rands> ().yspeed=y*0.9f;
		bb.transform.localScale = Vector3.one*0.5f;

		halt();
	}


	public override void Awake()
	{
		base.Awake();
		elipse= Resources.Load("elipse_indigo", typeof(GameObject)) as GameObject;
	}
	// Use this for initialization


}
