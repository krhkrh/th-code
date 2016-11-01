using UnityEngine;
using System.Collections;

public class spawn_circle : saim {

	GameObject bice;
	public int radius=10;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
		StartCoroutine(respwan());
	}
	
	void Awake()
	{
		bice=Resources.Load("bice",typeof(GameObject)) as GameObject;
	}
	IEnumerator respwan()
	{
		int i=0;
		Vector3 v=Vector3.up*radius;
		GameObject bb;

		while(i<5)
		{
			aim*=rate;
			
			i++;
			yield return new WaitForSeconds(0.5f);
		}
		yield return new WaitForSeconds(Random.value*2);

		i=0;

		yield return new WaitForSeconds(1.0f);
		Vector3 axis= new Vector3(transform.position.x,0,transform.position.z);
		audio.PlayOneShot(clip);
		for(i=0;i<36;i++)
		{

				bb = (GameObject)Instantiate (bice, gameObject.transform.position ,Quaternion.LookRotation(v.normalized) );
				bb.AddComponent ("saim");
				bb.GetComponent<saim> ().aim=v;
				bb.GetComponent<saim> ().type=1;
				v=Quaternion.AngleAxis(10,axis)*v;
		}


		yield return new WaitForSeconds(0.2f);
		Destroy(gameObject);
	}
	// Update is called once per frame
	void Update () {
		base.checkbound();
		transform.Translate (aim*Time.deltaTime,Space.World);
	
	}
}
