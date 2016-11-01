using UnityEngine;
using System.Collections;

public class emplacement : basic {

	public float yspeed=3.0f;
	public float wspeed=45.0f;
	public bool up=false;
	public bool clockwise=false;
	public float duratioin=3;




	GameObject player;
	GameObject bomb;
	GameObject line;

	void Awake()
	{

		player=GameObject.FindGameObjectWithTag("Player");
		bomb = Resources.Load("small bomb", typeof(GameObject)) as GameObject;
		line = Resources.Load("line", typeof(GameObject)) as GameObject;

	}

	// Use this for initialization
	void Start () {
		gameObject.transform.localScale=new Vector3(0.3f,0.3f,0.3f);
		StartCoroutine(ready ());
	}
	
	// Update is called once per frame
	void Update () {
		base.checkbound();

		if(up)
			transform.Translate (Vector3.up*yspeed*Time.deltaTime);
		else
			transform.Translate (Vector3.down*yspeed*Time.deltaTime);
		
		if(clockwise)
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		else
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);



	}

	IEnumerator ready()
	{
		Vector3 position;
		GameObject bb;
		int i=0;

		while(i<duratioin)
		{
			yspeed-=1;
			wspeed-=15;
			i+=1;
			yield return new WaitForSeconds(1.0f);
		}


		i=0;
		while(i<9)
		{


			Ray ray=new Ray(gameObject.transform.position,player.transform.position-gameObject.transform.position);

			RaycastHit hit=new RaycastHit();

			if(Physics.Raycast(ray,out hit,100.0f))
			{
				position=player.transform.position;
				bb=(GameObject)Instantiate (line,Vector3.zero,Quaternion.identity);
				bb.GetComponent<drawline>().origin=gameObject.transform.position;
				bb.GetComponent<drawline>().destination=position;
				
				yield return new WaitForSeconds(3.0f);



				if(hit.collider!=null)
				{

					if(hit.collider.gameObject.tag=="graze"||hit.collider.gameObject.tag=="base"||hit.collider.gameObject.tag=="entity")
					{
						bb=(GameObject)Instantiate (bomb,hit.point,Quaternion.identity);
						yield return new WaitForSeconds(2.0f);
					}
				}
			}
			i++;

		}
		Destroy(gameObject);
	}

}
