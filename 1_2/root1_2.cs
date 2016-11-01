using UnityEngine;
using System.Collections;

public class root1_2 : MonoBehaviour {

	// Use this for initialization

	public GameObject player;
	public GameObject manager;
	public GameObject boss;
	//public GameObject textlist;
	public GameObject softrain;
	public AudioClip[] clips;
	public Material[] skies;
	public float volume=0.7f;


	bool skip=false;

	bool bossfin=false;
	bool stagefin=false;

	Vector3[] v8;
	Vector3[] v6;
	Vector3 va = new Vector3 (0, 19.0f, 0);

	GameObject conversationmanager1_2;

	GameObject myscude;
	GameObject title2;

	GameObject root1_3;
	GameObject elipse;

	GameObject shooter2;
	GameObject shooter3;
	GameObject b3_v;
	GameObject b3_i;
	GameObject fairyred,fairyblue;
	bool informationreceived=false;
	bool conversationend=false;

	bool mazefinish=false;

	void Awake ()
	{




		player = GameObject.FindGameObjectWithTag ("Player");
		softrain = GameObject.FindGameObjectWithTag("wether");

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
		root1_3= Resources.Load("root1_3",typeof(GameObject)) as GameObject;
		boss= Resources.Load("kasa1_2",typeof(GameObject)) as GameObject;
		conversationmanager1_2= Resources.Load("conversationmanager1_2",typeof(GameObject)) as GameObject;
		shooter2 = Resources.Load("shooter2", typeof(GameObject)) as GameObject;
		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
		myscude = Resources.Load ("cmyscube", typeof(GameObject)) as GameObject;
		title2= Resources.Load("title1_2", typeof(GameObject)) as GameObject;
		elipse= Resources.Load("elipse_indigo", typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v", typeof(GameObject)) as GameObject;
		b3_i = Resources.Load("b3_i", typeof(GameObject)) as GameObject;
		fairyred= Resources.Load("littltfairy", typeof(GameObject)) as GameObject;
		fairyblue= Resources.Load("littltfairyb", typeof(GameObject)) as GameObject;
	}

	void Start ()
	{
		audio.volume=volume;
		StartCoroutine (maincoroutine());
		manager = (GameObject)Instantiate (conversationmanager1_2,player.transform.position, Quaternion.identity);
		manager.transform.parent=player.transform;

		 
	}
	
	// Update is called once per frame
	void Update ()
	{
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

	void bossfinish()
	{
		bossfin=true;
	}
	
	void stagefinish()
	{	
		if(informationreceived==false)
		{
			informationreceived=true;
			StartCoroutine(receivecooldown());
			if(mazefinish==false)
				mazefinish=true;
			else
				stagefin=true;

		}
	}

	IEnumerator receivecooldown()
	{
		yield return new WaitForSeconds(2.0f);
		informationreceived=false;
	}

	IEnumerator endstage2()
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
		bb = (GameObject) Instantiate(root1_3,Vector3.zero,Quaternion.identity);
		yield return new WaitForSeconds(1.0f);
		manager.SendMessage("halt",SendMessageOptions.DontRequireReceiver);
		player.SendMessage("changeroot",bb,SendMessageOptions.DontRequireReceiver);
	//	while(boss.transform.position.y>-5)
	//	{
	//		yield return new WaitForSeconds(1.0f);
	//	}
	//	Destroy(boss);
		Destroy(gameObject);
	}

	IEnumerator maincoroutine ()
	{
		yield return new WaitForSeconds(1.0f);
			
	/*	yield return new WaitForSeconds(4.0f);
		StartCoroutine(route2_1());
		yield return new WaitForSeconds(1.0f);
		startrainning();
		yield return new WaitForSeconds(2.0f);
		StartCoroutine(route2_2());

		yield return new WaitForSeconds(50.0f);
		StartCoroutine(route2_3());
		yield return new WaitForSeconds(15.0f);
		StartCoroutine(route2_4());
		yield return new WaitForSeconds(40.0f);
		StartCoroutine(route2_5f());
		yield return new WaitForSeconds(1.0f);
		StartCoroutine(route2_5());
		yield return new WaitForSeconds(52.0f);
		stoprainning();
		StartCoroutine(route2_6 ());

		while(!mazefinish)
		{
			yield return new WaitForSeconds(1.0f);
		}
		startrainning();
		audio.volume=volume;

		yield return new WaitForSeconds(2.0f);
		StartCoroutine(route2_7());
		StartCoroutine(route2_7f());
		yield return new WaitForSeconds(41.0f);
		StartCoroutine(route2_8());    
		yield return new WaitForSeconds(42.0f);     

		StartCoroutine(route2_9f());
		yield return new WaitForSeconds(28.0f);
		stoprainning();


		StartCoroutine(route2_10());

		while(!stagefin)
		{
			yield return new WaitForSeconds(1.0f);
		}
		startrainning();
		audio.volume=volume;

		yield return new WaitForSeconds(1.0f);
		StartCoroutine(route2_11());
		yield return new WaitForSeconds(3.5f);
		StartCoroutine(route2_12());

		while(!conversationend)
		{
			yield return new WaitForSeconds(1.0f);
		}

		stoprainning();
		yield return new WaitForSeconds(3.0f);

		StartCoroutine(endstage2());*/
		yield return new WaitForSeconds(1.0f);
		StartCoroutine(createnext());


	}


	void setskip(bool s)
	{
		skip=s;
	}


	IEnumerator route2_11()
	{
		GameObject bb;


		manager.SendMessage("setdisplay",4.0f,SendMessageOptions.DontRequireReceiver);

		yield return new WaitForSeconds(4.0f);
		Vector3 v= new Vector3(player.transform.position.x,0,player.transform.position.z);
		bb=(GameObject)Instantiate (boss,v+va, Quaternion.LookRotation(v+Vector3.down*10));

		//create kokasa

		manager.SendMessage("findboss",SendMessageOptions.DontRequireReceiver);
	}


	IEnumerator route2_12()
	{
		//set conversation
		int i=1,j=0;
		player.SendMessage("setconversationmode",true,SendMessageOptions.DontRequireReceiver);
		
		while(i<19&&!skip)
		{
			manager.SendMessage("setdisplay",3.5f,SendMessageOptions.DontRequireReceiver);
			i++;
			j=0;

			if(i==16)
			{
				manager.SendMessage("bossgo",SendMessageOptions.DontRequireReceiver);
			}

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


	IEnumerator route2_9f()
	{
		int i=0;
		GameObject bb;
		Vector3 v;
		for(i=0;i<3;i++)
		{
			v= (Vector3.zero- v6[i*2]*2 ).normalized;
			bb = (GameObject)Instantiate (fairyred,v6[i*2]*2 + va, Quaternion.LookRotation(v));
			bb.AddComponent ("fairy2_9");
			bb.GetComponent<fairy2_9> ().yspeed=7;
			yield return new WaitForSeconds(0.5f);
		}

		for(i=0;i<3;i++)
		{
			v= (Vector3.zero- v6[i*2+1]*2 ).normalized;
			bb = (GameObject)Instantiate (fairyred,v6[i*2+1]*2 + va, Quaternion.LookRotation(v));
			bb.AddComponent ("fairy2_9");
			bb.GetComponent<fairy2_9> ().yspeed=11;
			yield return new WaitForSeconds(0.5f);
		}

		for(i=0;i<3;i++)
		{
			v= (Vector3.zero- v6[i*2]*2 ).normalized;
			bb = (GameObject)Instantiate (fairyred,v6[i*2]*2 + va, Quaternion.LookRotation(v));
			bb.AddComponent ("fairy2_9");
			bb.GetComponent<fairy2_9> ().yspeed=15;
			yield return new WaitForSeconds(0.5f);
		}

		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator route2_10()
	{

		int j=0;
		GameObject bb;
		bb=(GameObject)Instantiate (myscude, new Vector3 (player.transform.position.x, 0, player.transform.position.z) + va, Quaternion.identity);
		bb.AddComponent("myscube2_10");
		bb.GetComponent<myscube2_10> ().clips[0]=this.clips[0];
		bb.GetComponent<myscube2_10> ().clips[1]=this.clips[1];
		bb.GetComponent<myscube2_10> ().DSR=skies[0];
		bb.GetComponent<myscube2_10> ().normal=skies[2];
		
		yield return new WaitForSeconds (2.0f);
		while(j<3)
		{
			audio.volume*=0.5f;
			j++;
			yield return new WaitForSeconds (1.0f);
			
		}

		//myscube
		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator route2_8()
	{

		int i=0;
		GameObject bb;
		Vector3 vp= new Vector3(player.transform.position.x,0,player.transform.position.z);

		for(i=0;i<6;i++)
		{
			bb = (GameObject)Instantiate (b3_i,Quaternion.Euler(0,(Random.value-0.5f)*30,0)*vp+va, Quaternion.identity);
			bb.AddComponent("ghostfire2_8");
			//bb.GetComponent<ghostfire2_8> ().health=100;

			yield return new WaitForSeconds(2.0f);
		}
		
		yield return new WaitForSeconds(1.0f);

		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator route2_7()
	{
		GameObject bb;

		Vector3 vp;
		float angle;
		int i=0;
		for(i=0;i<10;i++)
		{

			yield return new WaitForSeconds(5.0f);
			vp=new Vector3(player.transform.position.x,0,player.transform.position.z);
			angle=Quaternion.LookRotation(vp).eulerAngles.y;

			vp=new Vector3(player.transform.position.x,0,player.transform.position.z);

			bb= (GameObject) Instantiate(shooter2,vp+va*2,Quaternion.identity);
			bb.AddComponent("rocketshooter");
			bb.GetComponent<rocketshooter> ().angle=angle;

			bb= (GameObject) Instantiate(shooter2,Quaternion.Euler(0,45,0)*(vp+va*2),Quaternion.identity);
			bb.AddComponent("rocketshooter");
			bb.GetComponent<rocketshooter> ().angle=angle+45;


			bb= (GameObject) Instantiate(shooter2,Quaternion.Euler(0,-45,0)*(vp+va*2),Quaternion.identity);
			bb.AddComponent("rocketshooter");
			bb.GetComponent<rocketshooter> ().angle=angle-45;

			bb= (GameObject) Instantiate(shooter2,Quaternion.Euler(0,90,0)*(vp+va*2),Quaternion.identity);
			bb.AddComponent("rocketshooter");
			bb.GetComponent<rocketshooter> ().angle=angle+90;
			
			
			bb= (GameObject) Instantiate(shooter2,Quaternion.Euler(0,-90,0)*(vp+va*2),Quaternion.identity);
			bb.AddComponent("rocketshooter");
			bb.GetComponent<rocketshooter> ().angle=angle-90;


		}

		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator route2_7f()
	{
		int i=0;

		GameObject bb;
		Vector3 vp;
		float angle;
		for(i=0;i<3;i++)
		{
			vp=new Vector3(player.transform.position.x,0,player.transform.position.z);

			angle=Quaternion.LookRotation(vp).eulerAngles.y;


			bb = (GameObject)Instantiate (fairyred,Quaternion.Euler(0,20,0)*vp + va, Quaternion.LookRotation(vp+Vector3.down*3));
			bb.AddComponent ("fairy2_7");
			bb.GetComponent<fairy2_7> ().type=true;

			bb.GetComponent<fairy2_7> ().wspeed=0;
			bb.GetComponent<fairy2_7> ().yspeed=5;
			bb.GetComponent<fairy2_7> ().health=200;


			bb = (GameObject)Instantiate (fairyblue,Quaternion.Euler(0,-20,0)*vp + va, Quaternion.LookRotation(vp+Vector3.down*3));
			bb.AddComponent ("fairy2_7");
			bb.GetComponent<fairy2_7> ().type=false;

			
			bb.GetComponent<fairy2_7> ().wspeed=0;
			bb.GetComponent<fairy2_7> ().yspeed=5;
			bb.GetComponent<fairy2_7> ().health=200;

			yield return new WaitForSeconds(17.0f);
			
		}
		yield return new WaitForSeconds(1.0f);
	}



	IEnumerator route2_6()
	{
		int j=0;
		GameObject bb;
		bb=(GameObject)Instantiate (myscude, new Vector3 (player.transform.position.x, 0, player.transform.position.z) + va, Quaternion.identity);
		bb.AddComponent("myscube2_6");
		bb.GetComponent<myscube2_6> ().clips[0]=this.clips[0];
		bb.GetComponent<myscube2_6> ().clips[1]=this.clips[1];
		bb.GetComponent<myscube2_6> ().DSR=skies[0];
		bb.GetComponent<myscube2_6> ().normal=skies[1];

		yield return new WaitForSeconds (2.0f);
		while(j<3)
		{
			audio.volume*=0.5f;
			j++;
			yield return new WaitForSeconds (1.0f);
			
		}

	}



	IEnumerator route2_5()
	{
		int i=0;
		GameObject bb;


		for(i=0;i<8;i++)
		{
			bb = (GameObject)Instantiate (shooter3, v8[i]+Vector3.down*3, Quaternion.Euler(270,0,0));
			bb.AddComponent("shooter2_5");

		}
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator route2_5f()
	{
		int i=0;
		float a=0;
		GameObject bb;
		for(i=0;i<40;i++)
		{
			a=Random.value*360;
			if(Random.value>0.5)
			{
				bb = (GameObject)Instantiate (fairyred, Quaternion.Euler(0,a,0)*v8[0] + va, Quaternion.LookRotation(Quaternion.Euler(0,a,0)*v8[0]+Vector3.down*5));
				bb.AddComponent ("fairy2_5");
				bb.GetComponent<fairy2_5> ().type=true;
			}
			else
			{
			
				bb = (GameObject)Instantiate (fairyblue, Quaternion.Euler(0,a,0)*v8[0] + va, Quaternion.LookRotation(Quaternion.Euler(0,a,0)*v8[0]+Vector3.down*5));
				bb.AddComponent ("fairy2_5");
				bb.GetComponent<fairy2_5> ().type=false;
			}
				
			bb.GetComponent<fairy2_5> ().wspeed=0;
			bb.GetComponent<fairy2_5> ().yspeed=10;
			bb.GetComponent<fairy2_5> ().health=14;

			yield return new WaitForSeconds(1.0f);

		}


		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator route2_3()
	{
		int i=0;
		GameObject bb;

		for(i=0;i<3;i++)
		{
			bb = (GameObject)Instantiate (b3_v, v6 [i*2] + va, Quaternion.Euler(270,0,0));
			bb.AddComponent("goghstfire2_3");
			bb.GetComponent<goghstfire2_3> ().clip=clips[2];
			//yield return new WaitForSeconds(.0f);
		}

		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator route2_4()
	{
		GameObject bb;
		bb = (GameObject)Instantiate (shooter2, Vector3.zero, Quaternion.identity);
		bb.AddComponent("shooter2_4");
		yield return new WaitForSeconds(1.0f);

	}


	IEnumerator route2_2()
	{
		int i=0;
		GameObject bb;


		for(i=0;i<6;i++)
		{
			if(i%2==0)
			{
				bb = (GameObject)Instantiate (fairyred, v6[i] + va, Quaternion.LookRotation(v6[i]+Vector3.down*5));
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=true;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=10;
				bb.GetComponent<fairy1_1> ().health=50;
			}
			else
			{
				bb = (GameObject)Instantiate (fairyblue, v6[i] + va, Quaternion.LookRotation(v6[i]+Vector3.down*5));
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=false;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=20;
				bb.GetComponent<fairy1_1> ().health=50;
			}

		}

		for(i=0;i<6;i++)
		{
			if(i%2==0)
			{
				bb = (GameObject)Instantiate (fairyred, Quaternion.Euler(0,30,0)*v6[i] + va, Quaternion.LookRotation(Quaternion.Euler(0,15,0)*v6[i]+Vector3.down*5));
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=true;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=15;
				bb.GetComponent<fairy2_2> ().health=50;
			}
			else
			{
				bb = (GameObject)Instantiate (fairyblue, Quaternion.Euler(0,30,0)*v6[i] + va, Quaternion.LookRotation(Quaternion.Euler(0,15,0)*v6[i]+Vector3.down*5));
				bb.AddComponent ("fairy2_2");
				bb.GetComponent<fairy2_2> ().type=false;
				bb.GetComponent<fairy2_2> ().wspeed=0;
				bb.GetComponent<fairy2_2> ().yspeed=15;
				bb.GetComponent<fairy2_2> ().health=50;
			}
			
		}


		yield return new WaitForSeconds(45.0f);

		foreach (GameObject b in GameObject.FindGameObjectsWithTag("enemy"))
		{
			b.SendMessage("setake",false,SendMessageOptions.DontRequireReceiver);
		}

		yield return new WaitForSeconds(1.0f);


	}
	

	IEnumerator route2_1()
	{
		//rain drop= 3 elipses
		GameObject bb;
		bb = (GameObject)Instantiate (title2, Vector3.back * 10 + va, Quaternion.identity);
		bb.AddComponent ("rands");
		bb.GetComponent<rands> ().yspeed = 1;
		bb.GetComponent<rands> ().wspeed = 30;
		yield return new WaitForSeconds(1.0f);
	}








	IEnumerator route2_extra()
	{
		
		yield return new WaitForSeconds(2.0f);
		if(scorekeeper.score>=6000)
		{
			player.SendMessage("incplayer",1,SendMessageOptions.DontRequireReceiver);
			player.SendMessage("incbomb",3,SendMessageOptions.DontRequireReceiver);
			manager.SendMessage("setdisplay",4.0f,SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			player.SendMessage("incbomb",2,SendMessageOptions.DontRequireReceiver);
			manager.SendMessage("setdisplay",4.0f,SendMessageOptions.DontRequireReceiver);
		}
	}


	void startrainning()
	{
		softrain.particleSystem.enableEmission=true;
	}
	
	void stoprainning()
	{
		softrain.particleSystem.enableEmission=false;
	}

/*	IEnumerator football ()
	{
		GameObject bb;
		float speed = 7.0f;
		int i = 0, j = 1;
		Vector3 va = Vector3.up * speed;
		for (j=1; j<10; j++) {
			for (i=0; i<j*3; i++) {
				bb = (GameObject)Instantiate (b1_w, v6 [1] * 3 + va, Quaternion.identity);
				bb.AddComponent ("saim");
				bb.GetComponent<saim> ().aim = va;
				bb.GetComponent<saim> ().rate = 0.9f;
				va = Quaternion.Euler (0, 120 / j, 0) * va;
			}
			va = Quaternion.Euler (10, 0, 0) * va;
		}
		for (j=9; j>0; j--) {
			for (i=0; i<j*3; i++) {
				bb = (GameObject)Instantiate (b1_w, v6 [1] * 3 + va, Quaternion.identity);
				bb.AddComponent ("saim");
				bb.GetComponent<saim> ().aim = va;
				bb.GetComponent<saim> ().rate = 0.9f;
				va = Quaternion.Euler (0, 120 / j, 0) * va;
			}
			va = Quaternion.Euler (10, 0, 0) * va;
		}
		
		yield return new WaitForSeconds (1.0f);
	}*/


}
