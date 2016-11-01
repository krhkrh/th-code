using UnityEngine;
using System.Collections;

public class myscube3_2 : basic {

	float yspeed=24;
	public AudioClip[] clips = new AudioClip[2];
	public GameObject root;
	public Material DSR;
	public Material normal;
	bool finished=false;
	GameObject nexus,player,keyCube,b1_w_r,switchCube,playerCube,fakeSwitchCube;

	public void Awake()
	{
		nexus=Resources.Load("LSNexus",typeof(GameObject)) as GameObject;
		b1_w_r = Resources.Load("b1_w_r",typeof(GameObject)) as GameObject;
		keyCube = Resources.Load("ckey", typeof(GameObject)) as GameObject;
		switchCube = Resources.Load("switchCube",typeof(GameObject)) as GameObject;
		fakeSwitchCube = Resources.Load("fakeSwitchCube",typeof(GameObject)) as GameObject;
		playerCube = Resources.Load("player cube",typeof(GameObject)) as GameObject;
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
	void Start ()
	{
		audio.volume=Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;
		
		StartCoroutine(mainRoutine());
	}

	IEnumerator mainRoutine()
	{
		//working sprout 
		//puzzle here
		GameObject bb;
		Vector3 center = getXZhorizontal(player.transform)*2;
		Vector3 va = new Vector3(0,20,0);
		Vector3 innerRadius = new Vector3(5,0,0);
		GameObject[] nexusList =new GameObject[6];

		int j=0;
		int i=0;

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



		/////////////////////////////////////////////////////////


		//		k
		//		|
	//		/	*	\
	//		*/	   \*
	//		*	|	*		S
	//			*
	//			
	//			one



		bb = (GameObject)Instantiate (keyCube, center+va , Quaternion.identity);
		bb.AddComponent ("key3_2");
		bb.GetComponent<key3_2> ().speed=Vector3.down*6.0f;
		bb.GetComponent<key3_2> ().motionPeriod=1;
		GameObject keyCubeObject = bb;
		
		bb = (GameObject)Instantiate (b1_w_r, center+va , Quaternion.identity);
		bb.AddComponent ("containerShield");
		bb.GetComponent<containerShield> ().wspeed=0;
		bb.GetComponent<containerShield> ().yspeed=0;
		bb.GetComponent<containerShield> ().switchType = 1;
		bb.GetComponent<containerShield> ().durableTime = 5;
		bb.GetComponent<containerShield> ().speed = Vector3.down*6.0f;
		bb.GetComponent<containerShield> ().containedObject = keyCubeObject;
		bb.GetComponent<containerShield> ().motionPeriod = 1;
		GameObject keyShield = bb;

		bb = (GameObject)Instantiate (playerCube, center+va , Quaternion.identity);
		bb.AddComponent ("oneUp3_2");
		bb.GetComponent<oneUp3_2> ().speed=Vector3.down*5.75f;
		bb.GetComponent<oneUp3_2> ().motionPeriod=0;
		GameObject oneUp3_2 = bb;
		
		bb = (GameObject)Instantiate (b1_w_r, center+va , Quaternion.identity);
		bb.AddComponent ("containerShield");
		bb.GetComponent<containerShield> ().wspeed=0;
		bb.GetComponent<containerShield> ().yspeed=0;
		bb.GetComponent<containerShield> ().durableTime = 5;
		bb.GetComponent<containerShield> ().switchType = 1;
		bb.GetComponent<containerShield> ().containedObject = oneUp3_2;
		bb.GetComponent<containerShield> ().speed = Vector3.down*5.75f;
		bb.GetComponent<containerShield> ().motionPeriod = 0;
		GameObject playerCubeShield = bb;

		//nexus lock
		for(i=0;i<6;i++)
		{
			bb = (GameObject)Instantiate (nexus, Quaternion.Euler(0,i*60,0)*innerRadius+center+va , Quaternion.Euler(0,90*Random.Range(0,1),0));
			bb.AddComponent ("nexus5");
			bb.GetComponent<nexus5> ().speed=Vector3.down*5.75f;
			bb.GetComponent<nexus5> ().motionPeriod = 1;
			bb.GetComponent<nexus5> ().nexusType = 0;
			bb.GetComponent<nexus5> ().target[0] = keyShield;
			bb.GetComponent<nexus5> ().target[1] = playerCubeShield;
			bb.GetComponent<nexus5> ().currentTarget = keyShield;

			bb.tag="wall";
			nexusList[i]=bb;
		}


		//nexus switch
		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,10,0)*(center/2+va) , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch2");
		bb.GetComponent<nexusSwitch2> ().speed=Vector3.down*5.5f;
		bb.GetComponent<nexusSwitch2> ().motionPeriod = 1;
		bb.GetComponent<nexusSwitch2> ().controlType = 0;
		bb.GetComponent<nexusSwitch2> ().nexus[0] = nexusList[0];
		bb.GetComponent<nexusSwitch2> ().nexus[1] = nexusList[1];
		bb.GetComponent<nexusSwitch2> ().nexus[2] = nexusList[2];
		bb.GetComponent<nexusSwitch2> ().nexus[3] = nexusList[3];
		bb.GetComponent<nexusSwitch2> ().nexus[4] = nexusList[4];
		bb.GetComponent<nexusSwitch2> ().nexus[5] = nexusList[5];

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,30,0)*(center/2+va) , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch2");
		bb.GetComponent<nexusSwitch2> ().speed=Vector3.down*5.5f;
		bb.GetComponent<nexusSwitch2> ().motionPeriod = 1;
		bb.GetComponent<nexusSwitch2> ().controlType = 1;

		bb.GetComponent<nexusSwitch2> ().nexus[0] = nexusList[0];
		bb.GetComponent<nexusSwitch2> ().nexus[1] = nexusList[1];
		bb.GetComponent<nexusSwitch2> ().nexus[2] = nexusList[2];
		bb.GetComponent<nexusSwitch2> ().nexus[3] = nexusList[3];
		bb.GetComponent<nexusSwitch2> ().nexus[4] = nexusList[4];
		bb.GetComponent<nexusSwitch2> ().nexus[5] = nexusList[5];

		bb = (GameObject)Instantiate (switchCube, Quaternion.Euler(0,-30,0)*(center/2+va) , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("nexusSwitch2");
		bb.GetComponent<nexusSwitch2> ().speed=Vector3.down*5.5f;
		bb.GetComponent<nexusSwitch2> ().motionPeriod = 1;
		bb.GetComponent<nexusSwitch2> ().controlType = 2;
		bb.GetComponent<nexusSwitch2> ().player = player;
		bb.GetComponent<nexusSwitch2> ().nexus[0] = nexusList[0];
		bb.GetComponent<nexusSwitch2> ().nexus[1] = nexusList[1];
		bb.GetComponent<nexusSwitch2> ().nexus[2] = nexusList[2];
		bb.GetComponent<nexusSwitch2> ().nexus[3] = nexusList[3];
		bb.GetComponent<nexusSwitch2> ().nexus[4] = nexusList[4];
		bb.GetComponent<nexusSwitch2> ().nexus[5] = nexusList[5];


		bb = (GameObject)Instantiate (fakeSwitchCube, Quaternion.Euler(0,-10,0)*(center/2+va) , Quaternion.Euler(0,90*Random.Range(0,1),0));
		bb.AddComponent ("fakeSwitch");
		bb.GetComponent<fakeSwitch> ().speed=Vector3.down*5.5f;
		bb.GetComponent<fakeSwitch> ().motionPeriod = 1;





		while(finished!=true)
		{
			yield return new WaitForSeconds(1.0f);
		}

		animation.Play("close");
		yield return new WaitForSeconds(2.0f);
		audio.PlayOneShot(clips[1]);
		//myscube solved
		yield return new WaitForSeconds(2.0f);
		root.SendMessage("notifyMysCubeSolved",2,SendMessageOptions.DontRequireReceiver);
		
		Destroy(gameObject);
	}

	void finish()
	{
		finished=true;
	}

	Vector3 getXZhorizontal(Transform t)
	{
		return new Vector3(t.position.x,0,t.position.z);
	}

	Vector3 getXZhorizontalAt(Transform t,float y)
	{
		return new Vector3(t.position.x,y,t.position.z);
	}

	// Update is called once per frame
	void Update ()
	{
		base.checkbound();
		transform.Translate (Vector3.down*yspeed*Time.deltaTime);
	}

}
