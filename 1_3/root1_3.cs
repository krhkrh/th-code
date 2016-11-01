using UnityEngine;
using System.Collections;

public class root1_3 : MonoBehaviour {

	public GameObject player;
	public GameObject manager;
	public GameObject boss;
	public GameObject textlist;
	public GameObject cam;
	public AudioClip[] clips;
	public Material[] skies;
	public float volume=0.7f;


	public string stageName = "";

	bool skip=false;


	public void notifyMysCubeSolved(int number)
	{
		if(number ==1)
			mysCube1Solved = true;
		else mysCube2Solved = true;
	}
	public bool mysCube1Solved = false;
	public bool mysCube2Solved = false;

	bool bossfin=false;
	bool stagefin=false;
	
	Vector3[] v8;
	Vector3[] v6;
	Vector3 va = new Vector3 (0, 19.0f, 0);
	

	GameObject conversationmanager1_3;
	GameObject myscude;
	GameObject title3;
	
	GameObject root1_4;

	
	GameObject shooter2;
	GameObject shooter3;
	GameObject b3_v;
	GameObject b3_i;
	GameObject fairyred,fairyblue;
	
	bool conversationend=false;

	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag ("Player");


		textlist = GameObject.FindGameObjectWithTag("textlist");
		v8 = new Vector3[] {
			Vector3.forward * 10,
			(Vector3.forward + Vector3.left).normalized * 10,
			Vector3.left * 10,
			(Vector3.back + Vector3.left).normalized * 10,
			Vector3.back * 10,
			(Vector3.back + Vector3.right).normalized * 10,
			Vector3.right * 10,
			(Vector3.forward + Vector3.right).normalized * 10
		};
		
		v6 = new Vector3[] {
			Vector3.forward * 10,
			Quaternion.Euler (0, -60, 0) * v8 [0],
			Quaternion.Euler (0, -120, 0) * v8 [0],
			Quaternion.Euler (0, -180, 0) * v8 [0],
			Quaternion.Euler (0, 120, 0) * v8 [0],
			Quaternion.Euler (0, 60, 0) * v8 [0],
			
		};

	//	root1_4= Resources.Load(,typeof(GameObject)) as GameObject;
		boss= Resources.Load("hatate_parent",typeof(GameObject)) as GameObject;
		conversationmanager1_3= Resources.Load("conversationmanager1_3",typeof(GameObject)) as GameObject;
		shooter2 = Resources.Load("shooter2", typeof(GameObject)) as GameObject;
		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
		myscude = Resources.Load ("cmyscube", typeof(GameObject)) as GameObject;
		title3= Resources.Load("title1_3", typeof(GameObject)) as GameObject;
		cam = Resources.Load("cam",typeof(GameObject)) as GameObject;
		fairyred= Resources.Load("littltfairy", typeof(GameObject)) as GameObject;
		fairyblue= Resources.Load("littltfairyb", typeof(GameObject)) as GameObject;

		b3_i = Resources.Load("b3_i",typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;

	}



	// Use this for initialization
	void Start () {
		audio.volume=volume;
		StartCoroutine (maincoroutine());
		manager = (GameObject)Instantiate (conversationmanager1_3,player.transform.position, Quaternion.identity);
		manager.transform.parent=player.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}

	void bgmpause()
	{
		audio.mute=true;
	}
	
	void bgmresume()
	{
		audio.mute=false;
	}


	IEnumerator endstage3()
	{
		boss.SendMessage("clear",SendMessageOptions.DontRequireReceiver);
		while(boss.transform.position.y>-5)
		{
			audio.volume*=0.5f;
			yield return new WaitForSeconds(1.0f);
		}
	}
	
	IEnumerator createnext()
	{
		
		yield return new WaitForSeconds(1.0f);
		GameObject bb;
		bb = (GameObject) Instantiate(root1_4,Vector3.zero,Quaternion.identity);
		yield return new WaitForSeconds(1.0f);
		manager.SendMessage("halt",SendMessageOptions.DontRequireReceiver);
		player.SendMessage("changeroot",bb,SendMessageOptions.DontRequireReceiver);
		while(boss.transform.position.y>-5)
		{
			yield return new WaitForSeconds(1.0f);
		}
		Destroy(boss);
		Destroy(gameObject);
	}

	IEnumerator maincoroutine ()
	{

		yield return new WaitForSeconds(1.0f);

	//	yield return new WaitForSeconds(3.0f);

	/*	stageName = "3_1";
		StartCoroutine(route3_1());

		yield return new WaitForSeconds(3.0f);

		stageName = "3_4";
		StartCoroutine(route3_4());

		yield return new WaitForSeconds(20.0f);

		stageName = "blossom";
		StartCoroutine(blossom());

		yield return new WaitForSeconds(20.0f);

		StartCoroutine(blossom());

		yield return new WaitForSeconds(10.0f);
		
		StartCoroutine(blossom());

		yield return new WaitForSeconds(25.0f);

		stageName = "fruit Mature";
		StartCoroutine(fruitMature());
		yield return new WaitForSeconds(5.0f);
		StartCoroutine(fruitMature());
		yield return new WaitForSeconds(5.0f);
		StartCoroutine(fruitMature());

		yield return  new WaitForSeconds(20.0f);
		stageName = "mysCube 3_1";
		StartCoroutine(mysCube3_1 ());


		while(!mysCube1Solved)
		{
			yield return new WaitForSeconds(1.0f);
		}
		audio.volume=volume;

		yield return new WaitForSeconds(2.0f);

		stageName = "3_2";
		StartCoroutine(route3_2 ());

		yield return new WaitForSeconds(30.0f);

		stageName = "3_3_v1";
		StartCoroutine(route3_3_v1());

		yield return new WaitForSeconds(30.0f);

	//	stageName = "3_3_v2";
	//	StartCoroutine(route3_3_v2());

	//	yield return new WaitForSeconds(40.0f);


		stageName = "3_6";
		StartCoroutine(route3_6 (1));

		yield return new WaitForSeconds(15.0f);

		StartCoroutine(route3_6 (2));

		yield return new WaitForSeconds(15.0f);
		
		StartCoroutine(route3_6 (1));

		yield return new WaitForSeconds(15.0f);
		
		StartCoroutine(route3_6 (2));

		yield return new WaitForSeconds(10.0f);

		stageName = "3_5";
		StartCoroutine(route3_5());


		yield return new WaitForSeconds(20.0f);

		stageName = "mysCube 3_2";
		StartCoroutine(mysCube3_2());

		while(!mysCube2Solved)
		{
			yield return new WaitForSeconds(1.0f);
		}

		audio.volume=volume;*/

		StartCoroutine(route3_conversation_1());



		/*
		 *  boss creation and setting in route3_conversation_1
		 * 
		 * 	then the game starts
		 * 
		 * 	when the game ends boss report to root
		 * 	and start route3_conversation_2
		 * 
		 */

	//	StartCoroutine(route3_conversation_2());

		//then create the statge 4;


	}

	Vector3 getXZhorizontal(Transform t)
	{
		return new Vector3(t.position.x,0,t.position.z);
	}

	IEnumerator mysCube3_1()
	{
		int j=0;
		GameObject bb;
		bb=(GameObject)Instantiate (myscude, new Vector3 (player.transform.position.x, 0, player.transform.position.z) + va, Quaternion.identity);
		bb.AddComponent("myscube3_1");
		bb.GetComponent<myscube3_1> ().clips[0]=this.clips[0];
		bb.GetComponent<myscube3_1> ().clips[1]=this.clips[1];
		bb.GetComponent<myscube3_1> ().DSR=skies[0];
		bb.GetComponent<myscube3_1> ().normal=skies[1];
		bb.GetComponent<myscube3_1> ().root = gameObject;
		
		yield return new WaitForSeconds (2.0f);
		while(j<3)
		{
			audio.volume*=0.5f;
			j++;
			yield return new WaitForSeconds (1.0f);
			
		}
	}

	void bossfinish()
	{
		bossfin=true;
	}

	void clearDecoration()
	{
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("decoration"))
		{
			Destroy(g);
		}
	}

	IEnumerator mysCube3_2()
	{

		int j=0;
		GameObject bb;

		clearDecoration();

		bb=(GameObject)Instantiate (myscude, new Vector3 (player.transform.position.x, 0, player.transform.position.z) + va, Quaternion.identity);
		bb.AddComponent("myscube3_2");
		bb.GetComponent<myscube3_2> ().clips[0]=this.clips[0];
		bb.GetComponent<myscube3_2> ().clips[1]=this.clips[1];
		bb.GetComponent<myscube3_2> ().DSR=skies[0];
		bb.GetComponent<myscube3_2> ().normal=skies[1];
		bb.GetComponent<myscube3_2> ().root = gameObject;
		
		yield return new WaitForSeconds (2.0f);
		while(j<3)
		{
			audio.volume*=0.5f;
			j++;
			yield return new WaitForSeconds (1.0f);
			
		}
	}



	IEnumerator fruitMature()
	{
		GameObject bb;
		float angle1 = Random.Range(70,100);
		float angle2 = Random.Range(10,45);
	
		bb = (GameObject)Instantiate (b3_v, Quaternion.Euler(0,angle1,0)*(getXZhorizontal(player.transform)+Vector3.down*4),Quaternion.Euler(270,0,0));
		bb.AddComponent("IvyFruit");
		bb.GetComponent<IvyFruit> () .type = 1;
		bb.GetComponent<IvyFruit> () .tag = "enemy";

		bb = (GameObject)Instantiate (b3_v, Quaternion.Euler(0,-angle2,0)*(getXZhorizontal(player.transform)+Vector3.down*4),Quaternion.Euler(270,0,0));
		bb.AddComponent("IvyFruit");
		bb.GetComponent<IvyFruit> () .type = 1;
		bb.GetComponent<IvyFruit> () .tag = "enemy";

		yield return new WaitForSeconds(0.1f);
	}

	IEnumerator blossom()
	{

		GameObject bb;

		float angle1 = Random.Range(10,45);
		float angle2 = Random.Range(70,100);
		bb = (GameObject)Instantiate (b3_v, Quaternion.Euler(0,angle1,0)*(getXZhorizontal(player.transform)+Vector3.down*4),Quaternion.Euler(270,0,0));
		bb.AddComponent("BlossomSeed");
		bb.GetComponent<BlossomSeed> () .type = 1;
		bb.GetComponent<BlossomSeed> () .tag = "enemy";
		
		bb = (GameObject)Instantiate (b3_v,  Quaternion.Euler(0,-angle2,0)* (getXZhorizontal(player.transform)+Vector3.down),Quaternion.Euler(270,0,0));
		bb.AddComponent("BlossomSeed");
		bb.GetComponent<BlossomSeed> () .type = 1;
		bb.GetComponent<BlossomSeed> () .tag = "enemy";

		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator route3_smartphone()
	{

		yield return new WaitForSeconds(1.0f);
	}

	//cylinder circle
	IEnumerator route3_2()
	{
		
		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter2, Vector3.zero,Quaternion.identity);
		bb.AddComponent("integration34");
		
		yield return new WaitForSeconds(1.0f);
		
	}

	private Vector3 getPlayerXYVector(Transform asdf)
	{
		Vector3 v = new Vector3(0,0,0);
		v.Set(asdf.position.x,0,asdf.position.z);
		return v;
	}

	//rainbow seed type1  static  55sec
	IEnumerator route3_3_v1()
	{

		GameObject bb;

		bb = (GameObject)Instantiate (b3_v, getPlayerXYVector(player.transform)+va,Quaternion.Euler(270,0,0));
		bb.AddComponent("rainbowseed");

		bb.GetComponent<rainbowseed>().yspeed=5;
		bb.GetComponent<rainbowseed>().up=false;
		bb.GetComponent<rainbowseed>().wspeed=0;


		yield return new WaitForSeconds(1.0f);

	}

	//rainbow seed type2  horizontal 55sec
	IEnumerator route3_3_v2()
	{
		
		GameObject bb;
		Vector3 horizontalPosition = getPlayerXYVector(player.transform);
		bb = (GameObject)Instantiate (b3_i, -horizontalPosition+va/2, Quaternion.Euler(270,0,0));
		bb.AddComponent("rainbowseed");
		yield return new WaitForSeconds(1.0f);
		
	}

	//ivy
	IEnumerator route3_4()
	{
		
		GameObject bb;

		bb = (GameObject)Instantiate (b3_v, v6[0]+Vector3.down*4, Quaternion.Euler(270,0,0));
		bb.AddComponent("leftbranch");
		bb.GetComponent<leftbranch> ().tag = "enemy";
		bb.GetComponent<leftbranch> ().type = 1;

		bb = (GameObject)Instantiate (b3_v, v6[2]+Vector3.down*4, Quaternion.Euler(270,0,0));
		bb.AddComponent("leftbranch");
		bb.GetComponent<leftbranch> ().tag = "enemy";
		bb.GetComponent<leftbranch> ().type = 1;

		bb = (GameObject)Instantiate (b3_v, v6[4]+Vector3.down*4, Quaternion.Euler(270,0,0));
		bb.AddComponent("leftbranch");
		bb.GetComponent<leftbranch> ().tag = "enemy";
		bb.GetComponent<leftbranch> ().type = 1;
		yield return new WaitForSeconds(1.0f);
		
	}

	//random tornato
	IEnumerator route3_5()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter2, Vector3.zero, Quaternion.identity);
		bb.AddComponent("Shooter3_7");
		bb.GetComponent<Shooter3_7> ().player = player;
		yield return new WaitForSeconds(1.0f);
	}

	//tornado column
	IEnumerator route3_6(int a)
	{
		GameObject bb;
		if(a%2==0)
		{
			for(int i=0;i<6;)
			{

				bb = (GameObject)Instantiate (shooter2, Vector3.zero, Quaternion.identity);
				bb.AddComponent("Shooter3_8");
				bb.GetComponent<Shooter3_8> ().initposition = v6[i];
				i+=2;
			}
		}
		else 
		{
			for(int i=1;i<6;)
			{
				bb = (GameObject)Instantiate (shooter2, Vector3.zero, Quaternion.identity);
				bb.AddComponent("Shooter3_8");
				bb.GetComponent<Shooter3_8> ().initposition = v6[i];

				i+=2;
			}
		}
		yield return new WaitForSeconds(1.0f);

	}

	//boss skill
	IEnumerator route3_7()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter2, Vector3.zero, Quaternion.identity);
		bb.AddComponent("shooter3_11");
		yield return new WaitForSeconds(1.0f);

	}

	IEnumerator route3_8()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter2, getPlayerXYVector(player.transform)+Vector3.up*7, Quaternion.identity);
		bb.AddComponent("Shooter3_12");
		yield return new WaitForSeconds(1.0f);
	}



	//title
	IEnumerator route3_1()
	{
		//rain drop= 3 elipses
		GameObject bb;
		bb = (GameObject)Instantiate (title3, Vector3.back * 10 + va, Quaternion.identity);
		bb.AddComponent ("rands");
		bb.GetComponent<rands> ().yspeed = 1;
		bb.GetComponent<rands> ().wspeed = 30;
		yield return new WaitForSeconds(1.0f);
	}

	void setskip(bool s)
	{
		skip=s;
	}

	IEnumerator route3_conversation_1()
	{
		//set conversation
		int i=1,j=0;
		player.SendMessage("setconversationmode",true,SendMessageOptions.DontRequireReceiver);

		GameObject bb;
		GameObject hatateCam;
		Vector3 initPosition =  getPlayerXYVector(player.transform)+Vector3.up*7;
		Vector3 minusYInitPosition =  getPlayerXYVector(player.transform)+Vector3.down*7;

		bb = (GameObject)Instantiate (boss, initPosition, Quaternion.LookRotation(minusYInitPosition));
		hatateCam = (GameObject)Instantiate (cam, bb.transform.position, Quaternion.LookRotation(getXZhorizontal(bb.transform)));

		hatateCam.AddComponent<camcontrol>();

		hatateCam.GetComponent<camcontrol>().controller = bb;
		hatateCam.GetComponent<camcontrol>().setSize(camcontrol.SMALL);
		hatateCam.GetComponent<MeshRenderer>().enabled = false;
		hatateCam.GetComponent<Collider>().enabled = false;

		bb.GetComponent<HatateParent>().cam = hatateCam;

		manager.SendMessage("findboss",SendMessageOptions.DontRequireReceiver);
		while(i<22&&!skip)
		{
			manager.SendMessage("setdisplay",3.5f,SendMessageOptions.DontRequireReceiver);
			i++;
			j=0;

			while(j<40&&!skip)
			{
				j++;
				yield return new WaitForSeconds(0.1f);
				
			}
		}
		conversationend=true;
		manager.SendMessage("skipconversation",SendMessageOptions.DontRequireReceiver);

		bb.SendMessage("setstate",1,SendMessageOptions.DontRequireReceiver);

		player.SendMessage("setconversationmode",false,SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(1.0f);
		
	}

	IEnumerator route3_conversation_2()
	{
		skip=false;
		//set conversation
		int i=1,j=0;
		player.SendMessage("setconversationmode",true,SendMessageOptions.DontRequireReceiver);
		
		while(i<6&&!skip)
		{
			manager.SendMessage("setdisplay",3.5f,SendMessageOptions.DontRequireReceiver);
			i++;
			j=0;
			
			while(j<40&&!skip)
			{
				j++;
				yield return new WaitForSeconds(0.1f);
				
			}
		}
		conversationend=true;
		manager.SendMessage("skipconversation",SendMessageOptions.DontRequireReceiver);
		
		player.SendMessage("setconversationmode",false,SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(1.0f);
		
	}



}
