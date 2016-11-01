using UnityEngine;
using System.Collections;

public class myscube3_1 : basic
{

	float yspeed=24;
	GameObject nexus,player,keyCube,b1_w_r,switchCube;
	public Material DSR;
	public Material normal;
	public AudioClip[] clips = new AudioClip[2];
	public GameObject root;
	bool finished=false;

	public void Awake()
	{
		nexus=Resources.Load("LSNexus",typeof(GameObject)) as GameObject;
		b1_w_r = Resources.Load("b1_w_r",typeof(GameObject)) as GameObject;
		keyCube = Resources.Load("ckey", typeof(GameObject)) as GameObject;
		switchCube = Resources.Load("switchCube",typeof(GameObject)) as GameObject;
		player = GameObject.FindGameObjectWithTag ("Player");

	}

	public override void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="enemy")
		{
			Destroy(other.gameObject);
		}
		else if(other.gameObject.tag=="MainCamera")
		{
			RenderSettings.skybox=DSR;
			RenderSettings.ambientLight=Color.black;
		}
		else if(other.gameObject.tag=="light")
		{
			
			other.gameObject.light.enabled=false;
		}
		
	}

	void OnTriggerExit(Collider other)
	{
		if(other.gameObject.tag=="entity"||other.gameObject.tag=="energy"||other.gameObject.tag=="ray"||other.gameObject.tag=="enemy"||other.gameObject.tag=="items")
		{
			Destroy(other.gameObject);
		}
		if(other.gameObject.tag=="MainCamera")
		{
			RenderSettings.skybox=normal;
			RenderSettings.ambientLight=new Color(0.75f,0.75f,0.75f);
		}
		else if(other.gameObject.tag=="light")
		{
			other.gameObject.light.enabled=true;
		}
		else if(other.gameObject.tag=="wall")
		{
			Destroy(other.gameObject);
		}
		
	}

		// Use this for initialization
		void Start ()
		{
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;
		
		StartCoroutine(mainRoutine());
		}

	IEnumerator mainRoutine()
	{
		GameObject bb;
		int i=0,j=0;
		float radius = 12.0f;

		while(i<5)
		{
			
			yspeed*=0.5f;
			i++;
			yield return new WaitForSeconds(0.4f);
		}
		yspeed=0;
		i=0;
		
		audio.Stop();
		audio.PlayOneShot(clips[0]);
		animation.Play("open");
		yield return new WaitForSeconds(3.0f);

		Vector3 standardPosition = (-getXZhorizontal(player.transform)).normalized;
		Vector3 va = Vector3.up*20,vs = standardPosition*13,vq = standardPosition*10;
		GameObject shield;
		GameObject[] nexusList =new GameObject[8];


	
		bb = (GameObject)Instantiate (keyCube, vs+va , Quaternion.identity);
		bb.AddComponent ("key3_1");
		bb.GetComponent<key3_1> ().speed=Vector3.down*5;
		bb.GetComponent<key3_1> ().motionPeriod=1;


		bb = (GameObject)Instantiate (b1_w_r, vs+va , Quaternion.identity);
		bb.AddComponent ("containerShield");
		bb.GetComponent<containerShield> ().wspeed=0;
		bb.GetComponent<containerShield> ().yspeed=0;
		bb.GetComponent<containerShield> ().switchType = 0;
		bb.GetComponent<containerShield> ().speed = Vector3.down*5;
		bb.GetComponent<containerShield> ().motionPeriod = 1;

		shield = bb;
		Vector3 v1 = Quaternion.Euler(0,45,30)*standardPosition;

		for(j=0;j<4;j++)
		{
			bb = (GameObject)Instantiate (nexus, Quaternion.Euler(0,90*j,0)*v1*7+vs+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
			bb.AddComponent ("nexus");
			bb.GetComponent<nexus> ().speed=Vector3.down*5;
			bb.GetComponent<nexus> ().nexusType=0;
			bb.GetComponent<nexus> ().target[0] = shield;
			bb.GetComponent<nexus> ().motionPeriod = 0;

			bb.GetComponent<nexus> ().currentTarget = shield;
			bb.tag = "ray";
			nexusList[j] = bb; 
		}

		v1= Quaternion.Euler(0,45,-30)*standardPosition;
		for(j=0;j<4;j++)
		{
			bb = (GameObject)Instantiate (nexus, Quaternion.Euler(0,90*j,0)*v1*7+vs+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
			bb.AddComponent ("nexus");
			bb.GetComponent<nexus> ().speed=Vector3.down*5;
			bb.GetComponent<nexus> ().nexusType=0;
			bb.GetComponent<nexus> ().target[0] = shield;

			bb.GetComponent<nexus> ().currentTarget = shield;
			bb.GetComponent<nexus> ().motionPeriod = 2;
			bb.tag="ray";
			nexusList[4+j] = bb;
		}
		////////////////////////////////////////////////////////////
				 
		//working sprout
		////////////////////////////////////////////////////////////
		Vector3 v2 = Quaternion.Euler(0,90,0)*standardPosition*10,v3 = Quaternion.Euler(0,270,0)*standardPosition*10;
		GameObject dummyObj,shieldObj;

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,20,0)*v2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 0;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[4];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[5];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[1];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[6];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,20,0)*v2*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 0;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;

		dummyObj.GetComponent<nexus> ().currentTarget = bb;
		dummyObj.tag="wall";
		nexusList[5].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,20,0)*v2+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 0;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		/////////////////
		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,-20,0)*v2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 0;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[1];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[0];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[3];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[4];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,-20,0)*v2*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 0;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[0].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,-20,0)*v2+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 0;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		/////////////////
		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,20,0)*v3+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 0;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[2];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[0];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[3];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[7];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,20,0)*v3*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 0;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[3].GetComponent<nexus> ().target[1] = dummyObj;


		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,20,0)*v3+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 0;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		/////////////////
		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,-20,0)*v3+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 0;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[5];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[2];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[7];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[6];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,-20,0)*v3*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 0;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[6].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,-20,0)*v3+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 0;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		////////////////

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,20,0)*v2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 2;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[1];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[0];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[2];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[5];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,20,0)*v2*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 2;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[1].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,20,0)*v2+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 2;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		///////////////
		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,-20,0)*v2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 2;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[4];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[5];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[7];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[0];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,-20,0)*v2*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 2;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.tag="wall";
		nexusList[4].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,-20,0)*v2+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 2;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		///////////////

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,20,0)*v3+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 2;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[3];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[4];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[6];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[7];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,20,0)*v3*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 2;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[7].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,20,0)*v3+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 2;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		///////////////

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,-20,0)*v3+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch");
		bb.GetComponent<nexusSwitch> ().speed=Vector3.down*5;
		bb.GetComponent<nexusSwitch> ().motionPeriod = 2;
		bb.GetComponent<nexusSwitch> ().nexus[0]=nexusList[1];
		bb.GetComponent<nexusSwitch> ().nexus[1]=nexusList[2];
		bb.GetComponent<nexusSwitch> ().nexus[2]=nexusList[3];
		bb.GetComponent<nexusSwitch> ().nexus[3]=nexusList[6];

		dummyObj = (GameObject)Instantiate (nexus, Quaternion.Euler(0,-20,0)*v3*2+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
		dummyObj.AddComponent ("nexus");
		dummyObj.GetComponent<nexus> ().speed=Vector3.down*5;
		dummyObj.GetComponent<nexus> ().motionPeriod = 2;
		dummyObj.GetComponent<nexus> ().target[0] = bb;
		dummyObj.GetComponent<nexus> ().target[1] = bb;
		dummyObj.GetComponent<nexus> ().nexusType = 2;
		dummyObj.GetComponent<nexus> ().currentTarget = bb;

		dummyObj.tag="wall";
		nexusList[2].GetComponent<nexus> ().target[1] = dummyObj;

		shieldObj = (GameObject)Instantiate (b1_w_r, Quaternion.Euler(0,-20,0)*v3+va ,Quaternion.identity);
		shieldObj.AddComponent ("containerShield");
		shieldObj.GetComponent<containerShield> ().speed=Vector3.down*5;
		shieldObj.GetComponent<containerShield> ().motionPeriod = 2;
		shieldObj.GetComponent<containerShield> ().switchType = 1;
		shieldObj.GetComponent<containerShield> ().containedObject = bb;
		bb.GetComponent<nexusSwitch> ().container = shieldObj;
		///////////////


	/*	bb = (GameObject)Instantiate (switchCube, -standardPosition*10+va, Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("resetAl");
		bb.GetComponent<resetAl> ().speed=Vector3.down*5;
		bb.GetComponent<resetAl> ().motionPeriod = 0;
		bb.GetComponent<resetAl> ().nexus[0]=nexusList[0];
		bb.GetComponent<resetAl> ().nexus[1]=nexusList[1];
		bb.GetComponent<resetAl> ().nexus[2]=nexusList[2];
		bb.GetComponent<resetAl> ().nexus[3]=nexusList[3];
		bb.GetComponent<resetAl> ().nexus[4]=nexusList[4];
		bb.GetComponent<resetAl> ().nexus[5]=nexusList[5];
		bb.GetComponent<resetAl> ().nexus[6]=nexusList[6];
		bb.GetComponent<resetAl> ().nexus[7]=nexusList[7];
*/

		while(finished!=true)
		{
			yield return new WaitForSeconds(1.0f);
		}

		foreach(GameObject n in nexusList)
		{
			n.SendMessage("finalize",SendMessageOptions.DontRequireReceiver);
		}

		animation.Play("close");
		yield return new WaitForSeconds(2.0f);
		audio.PlayOneShot(clips[1]);
		//myscube solved
		yield return new WaitForSeconds(2.0f);
		root.SendMessage("notifyMysCubeSolved",1,SendMessageOptions.DontRequireReceiver);

		Destroy(gameObject);

	}

	void finish()
	{
		finished=true;

		//working sprout

	}


	Vector3 getXZhorizontal(Transform t)
	{
		return new Vector3(t.position.x,0,t.position.z);
	}
	
	// Update is called once per frame
	void Update ()
	{
		base.checkbound();
		transform.Translate (Vector3.down*yspeed*Time.deltaTime);
	}
}

