using UnityEngine;
using System.Collections;

public class recursive_spawn : straightline {


	public int category=0;
	GameObject iceball;
	public float scale=0.5f;
	public AudioClip clip;

	// Use this for initialization
	void Awake()
	{
		iceball=Resources.Load ("iceball", typeof(GameObject)) as GameObject;

	}


	void Start () {
		audio.volume=Control.volume;
		yspeed=0;
		StartCoroutine(recursive());
	}

	public override void OnTriggerEnter (Collider other)
	{
		if(type==0)
		{
			base.OnTriggerEnter(other);
		}
		else if(type==1)
		{
			if(other.gameObject.tag=="Player")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
			if(other.gameObject.tag=="entity")
			{
				Destroy(gameObject);
			}
		}
		else if(type==2)
		{
			if(other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}
		}
	}


	IEnumerator recursive()
	{
		GameObject bb;

		yield return new WaitForSeconds(Random.value);
		audio.PlayOneShot(clip);
		switch(category)
		{
		case 0:{yield return new WaitForSeconds(2.0f);}break;
		case 1:{

			bb = (GameObject)Instantiate (iceball, transform.position+Vector3.up, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;

			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);


			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*(transform.position+Vector3.up*1.5f), Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=2;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*(transform.position+Vector3.up*1.5f), Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=6;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);
		}break;
		case 2:{


			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*transform.position + Vector3.up*0.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);
			


			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*transform.position + Vector3.up*1.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=1;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-10,0)*transform.position, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=3;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);



		}break;
		case 3:{

			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*transform.position + Vector3.down*0.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);
			
			
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*transform.position + Vector3.down*1.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=2;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-10,0)*transform.position, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=4;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);



		}break;
		case 4:{

			bb = (GameObject)Instantiate (iceball, transform.position+Vector3.down, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);
			
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,-5,0)*(transform.position+Vector3.down*1.5f), Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=3;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*(transform.position+Vector3.down*1.5f), Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=5;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);

		}break;
		case 5:{

			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*transform.position + Vector3.down*0.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);
			
			
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*transform.position + Vector3.down*1.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=4;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,10,0)*transform.position, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=6;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);


		}break;
		case 6:{

			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*transform.position + Vector3.up*0.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=0;
			bb.GetComponent<recursive_spawn> ().type=1;

			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(0.5f);
			
			
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,5,0)*transform.position + Vector3.up*1.5f, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=1;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			
			bb = (GameObject)Instantiate (iceball, Quaternion.Euler(0,10,0)*transform.position, Quaternion.identity);
			bb.AddComponent ("recursive_spawn");
			bb.GetComponent<recursive_spawn> ().category=5;
			bb.GetComponent<recursive_spawn> ().type=1;
			bb.GetComponent<recursive_spawn> ().clip=clip;
			bb.transform.localScale=new Vector3(scale,scale,scale);
			yield return new WaitForSeconds(1.0f);



		}break;
			default:break;
		}
		Destroy(gameObject);
	}


	// Update is called once per frame
	public override void Update () {
		base.Update();
	}
}
