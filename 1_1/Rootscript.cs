using UnityEngine;
using System.Collections;

public class Rootscript : MonoBehaviour
{
		//radius=10
		//height=17
	
		public int difficulty = 1;
		public GameObject player;
		public GameObject manager;
	public GameObject boss;
	public GameObject textlist;

	public AudioClip[] clips;
	public float volume=0.7f;
	bool skip=false;
	bool bossfin=false;
	bool stagefin=false;
		bool snowing=true;
		GameObject gb;
		GameObject iceball;
		GameObject dirice;
		GameObject b1_r;
		GameObject b1_g;
		GameObject b1_b;
		GameObject b3_w;
		GameObject b3_v;
		GameObject flake1i, flake2i, flake3i;
		GameObject flake1o, flake2o, flake3o;
		GameObject fairyred,fairyblue;
		GameObject title1;
		GameObject myscude;
		GameObject root1_2;
		Vector3[] v8;
		Vector3[] v6;
		Vector3 forward_left = (Vector3.forward + Vector3.left).normalized * 10;
		Vector3 forward_right = (Vector3.forward + Vector3.right).normalized * 10;
		Vector3 back_left = (Vector3.back + Vector3.left).normalized * 10;
		Vector3 back_right = (Vector3.back + Vector3.right).normalized * 10;
		Vector3 va = new Vector3 (0, 19.0f, 0);

		//vector = Quaternion.Euler(0, -45, 0) * vector;

		void Awake ()
		{

				player = GameObject.FindGameObjectWithTag ("Player");
				manager= GameObject.FindGameObjectWithTag("manager");
				boss= GameObject.FindGameObjectWithTag("boss");	

				gb = Resources.Load ("giant bomb", typeof(GameObject)) as GameObject;
			


				iceball = Resources.Load ("iceball", typeof(GameObject)) as GameObject;
				dirice = Resources.Load ("dirice", typeof(GameObject)) as GameObject;

				b1_r = Resources.Load ("b1_r", typeof(GameObject)) as GameObject;
				b1_g = Resources.Load ("b1_g", typeof(GameObject)) as GameObject;
				b1_b = Resources.Load ("b1_b", typeof(GameObject)) as GameObject;

				b3_w = Resources.Load ("b3_w", typeof(GameObject)) as GameObject;
				b3_v = Resources.Load ("b3_v", typeof(GameObject)) as GameObject;

				flake1i = Resources.Load ("snowflake1i", typeof(GameObject)) as GameObject;
				flake2i = Resources.Load ("snowflake2i", typeof(GameObject)) as GameObject;
				flake3i = Resources.Load ("snowflake3i", typeof(GameObject)) as GameObject;

				flake1o = Resources.Load ("snowflake1o", typeof(GameObject)) as GameObject;
				flake2o = Resources.Load ("snowflake2o", typeof(GameObject)) as GameObject;
				flake3o = Resources.Load ("snowflake3o", typeof(GameObject)) as GameObject;
		
				title1 = Resources.Load ("title1_1", typeof(GameObject)) as GameObject; //functional bullet 1

				fairyred= Resources.Load("littltfairy", typeof(GameObject)) as GameObject;
				fairyblue= Resources.Load("littltfairyb", typeof(GameObject)) as GameObject;
				root1_2= Resources.Load("root1_2", typeof(GameObject)) as GameObject;		

				myscude = Resources.Load ("myscube", typeof(GameObject)) as GameObject;
				v8 = new Vector3[] {
						Vector3.forward * 10,
						forward_left,
						Vector3.left * 10,
						back_left,
						Vector3.back * 10,
						back_right,
						Vector3.right * 10,
						forward_right
				};
				
				v6 = new Vector3[] {
					Vector3.forward * 10,
					Quaternion.Euler (0, -60, 0) * v8 [0],
					Quaternion.Euler (0, -120, 0) * v8 [0],
					Quaternion.Euler (0, -180, 0) * v8 [0],
					Quaternion.Euler (0, 120, 0) * v8 [0],
					Quaternion.Euler (0, 60, 0) * v8 [0],

				};

		}


		// Use this for initialization
		void Start ()
		{
				audio.volume=0.7f;
				StartCoroutine (maincoroutine ());
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
		/*
chapter 1 plan:
1,straight
2,around
3,chaser
4,functional bullet

5,character ability


		  */
		IEnumerator maincoroutine ()
		{
			/*	yield return  new WaitForSeconds(2.0f);
				
				StartCoroutine(route_1_0());
				yield return  new WaitForSeconds(4.0f);
	
				StartCoroutine (route_1_1 ());

				yield  return new WaitForSeconds (10.0f);

				StartCoroutine (route_1_2 ());

				yield  return new WaitForSeconds (1.0f);

				StartCoroutine (snow ());

				yield  return new WaitForSeconds (7.0f);

				StartCoroutine (route_1_3 ());
				
				yield  return new WaitForSeconds (65.0f);

				StartCoroutine (route_1_4 ());
				
				yield  return new WaitForSeconds (25.0f);

				StartCoroutine (route_1_5 ());

				yield  return new WaitForSeconds (15.0f);
				
				StartCoroutine (route_1_6 ());

				yield  return new WaitForSeconds (33.0f); 

				StartCoroutine(route_1_7());
				snowing=false;
				yield return new WaitForSeconds(35.0f);
				
				StartCoroutine(route_1_8());

				yield return new WaitForSeconds(27.0f);

				StartCoroutine(route_1_9());

				
				
				while(!stagefin)
				{
					yield return new WaitForSeconds(1.0f);
				}
				audio.volume=volume;
				snowing=true;

				StartCoroutine(snow());
				yield return new WaitForSeconds (3.0f);
				StartCoroutine(route_1_10());
				yield return new WaitForSeconds (3.5f);
				StartCoroutine(route_1_11());
				while(!bossfin)
				{
					yield return new WaitForSeconds(1.0f);
				}
				snowing=false;
				StartCoroutine(route_1_12());
				yield return new WaitForSeconds(11f);
				StartCoroutine(route_1_extra());
				yield return new WaitForSeconds(3.0f);*/
				StartCoroutine(endstage1());
				yield return new WaitForSeconds(1.0f);

				StartCoroutine(createnext());
				

		}
		
		


		void bossfinish()
		{
			bossfin=true;
		}
		
		void stagefinish()
		{	
			stagefin=true;
		}


		IEnumerator snow ()
		{
				GameObject bb;
		int i = 0;
				while (snowing) {
						for (i=0; i<6; i++) {
								bb = (GameObject)Instantiate (flake1i,   Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("straightline");
								bb.GetComponent<straightline> ().yspeed = Random.value + 1.0f;
						
								bb = (GameObject)Instantiate (flake1o, Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("straightline");
								bb.GetComponent<straightline> ().yspeed = Random.value + 1.0f;
								yield return new WaitForSeconds (2.0f);
								
								bb = (GameObject)Instantiate (flake2i, Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().yspeed = Random.value + 1.0f;
								bb.GetComponent<rands> ().wspeed = (Random.value + 1.0f) * 10;
								bb.GetComponent<rands> ().clockwise = true;

								bb = (GameObject)Instantiate (flake2o, Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().yspeed = Random.value + 1.0f;
								bb.GetComponent<rands> ().wspeed = (Random.value + 1.0f) * 10;
								bb.GetComponent<rands> ().clockwise = true;
								
								bb = (GameObject)Instantiate (flake3i, Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().yspeed = Random.value + 1.0f;
								bb.GetComponent<rands> ().wspeed = (Random.value + 1.0f) * 10;
								bb.GetComponent<rands> ().clockwise = false;

								bb = (GameObject)Instantiate (flake3o, Quaternion.Euler (0, 30 * (Random.value - 1), 0)*(v6 [i] * (Random.value + 1) + va * 1.5f), Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().yspeed = Random.value + 1.0f;
								bb.GetComponent<rands> ().wspeed = (Random.value + 1.0f) * 10;
								bb.GetComponent<rands> ().clockwise = false;
								yield return new WaitForSeconds (2.0f);
					}
						
				}
		}
	
	IEnumerator createnext()
	{
		GameObject bb;
		bb = (GameObject) Instantiate(root1_2,Vector3.zero,Quaternion.identity);
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

	IEnumerator endstage1()
	{

		boss.SendMessage("clear",SendMessageOptions.DontRequireReceiver);
		while(boss.transform.position.y>-5)
		{
			audio.volume*=0.5f;
			yield return new WaitForSeconds(1.0f);
		}
	}

	IEnumerator route_1_extra()
	{

		yield return new WaitForSeconds(2.0f);
		if(scorekeeper.score>=3000)
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



	IEnumerator route_1_12()
	{
		manager.SendMessage("setdisplay",3.0f,SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(3.5f);
		manager.SendMessage("setdisplay",3.0f,SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(3.5f);
		manager.SendMessage("setdisplay",3.0f,SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(3.5f);

	}
	
	IEnumerator route_1_10()
		{
			manager.SendMessage("setdisplay",4.0f,SendMessageOptions.DontRequireReceiver);
			yield return new WaitForSeconds(1.0f);
			boss.SendMessage("setstate",0,SendMessageOptions.DontRequireReceiver);

		}

		void setskip(bool s)
		{
			skip=s;
		}

		IEnumerator route_1_11()
		{
			int i=1,j=0;
			player.SendMessage("setconversationmode",true,SendMessageOptions.DontRequireReceiver);
			
			while(i<8&&!skip)
			{
				manager.SendMessage("setdisplay",3.0f,SendMessageOptions.DontRequireReceiver);
				i++;
				j=0;

				while(j<35&&!skip)
				{
					j++;
					yield return new WaitForSeconds(0.1f);
					
				}

			}
			manager.SendMessage("skipconversation",SendMessageOptions.DontRequireReceiver);
			player.SendMessage("setconversationmode",false,SendMessageOptions.DontRequireReceiver);
		}

		IEnumerator route_1_9 ()
		{
				int j=0;
				
				Instantiate (myscude, new Vector3 (player.transform.position.x, 0, player.transform.position.z) + va, Quaternion.identity);
				yield return new WaitForSeconds (2.0f);
				while(j<3)
				{
					audio.volume*=0.5f;
					j++;
					yield return new WaitForSeconds (1.0f);
					
				}
		}

		IEnumerator route_1_8 ()
		{

				int i = 0;
				for (i=0; i<4; i++) {
						Instantiate (gb, v8 [i * 2] * 1.6f + va, Quaternion.Euler (270, -90 * (i + 1), 0));

						yield return new WaitForSeconds (6.0f);
				}
		}
		
		IEnumerator route_1_7 ()
		{
			
				GameObject bb;
				bb = (GameObject)Instantiate (b3_w, v8 [0] + va, Quaternion.identity);
				bb.AddComponent ("firework");
				bb.GetComponent<firework> ().yspeed = 1.0f;
				bb.GetComponent<firework> ().clips=clips[7];
				yield  return new WaitForSeconds (10.0f);
				bb = (GameObject)Instantiate (b3_w, v8 [2] + va, Quaternion.identity);
				bb.AddComponent ("firework");
				bb.GetComponent<firework> ().clockwise = false;
				bb.GetComponent<firework> ().yspeed = 1.0f;
				bb.GetComponent<firework> ().clips=clips[7];
				yield  return new WaitForSeconds (10.0f);
				bb = (GameObject)Instantiate (b3_w, v8 [4] + va, Quaternion.identity);
				bb.AddComponent ("firework");
				bb.GetComponent<firework> ().yspeed = 1.0f;
				bb.GetComponent<firework> ().clips=clips[7];
				yield  return new WaitForSeconds (10.0f);
				bb = (GameObject)Instantiate (b3_w, v8 [6] + va, Quaternion.identity);
				bb.AddComponent ("firework");
				bb.GetComponent<firework> ().clockwise = false;
				bb.GetComponent<firework> ().yspeed = 1.0f;
				bb.GetComponent<firework> ().clips=clips[7];
		}
		
		IEnumerator route_1_6 ()
		{
				int i = 0;
			
				GameObject bb;
			

				for (i=0; i<6; i+=2) {
						bb = (GameObject)Instantiate (b3_v, v6 [i] * 2 + va, Quaternion.Euler(270,0,0));
						bb.AddComponent ("emplacement");
						bb.GetComponent<emplacement> ().yspeed = 3.0f;
				}

				for (i=1; i<6; i+=2) {
						bb = (GameObject)Instantiate (b3_v, v6 [i] * 2, Quaternion.Euler(270,0,0));
						bb.AddComponent ("emplacement");
						bb.GetComponent<emplacement> ().yspeed = 3.0f;
						bb.GetComponent<emplacement> ().up = true;
				}
				yield  return new WaitForSeconds (1.0f);
		}

		IEnumerator route_1_5 ()
		{
				int i = 0;
				float r = 0;
				GameObject bb;
			
				for (i=0; i<30; i++) {
						r = Random.value * 360;
						;

						bb = (GameObject)Instantiate (b3_w, new Vector3 (Mathf.Cos (r) * 10, 0, Mathf.Sin (r) * 10) + va, Quaternion.identity);
						bb.AddComponent ("blast6");
						bb.GetComponent<blast6> ().yspeed = 10.0f;
						bb.GetComponent<blast6> ().threshold = 1.5f;
						bb.GetComponent<blast6> ().clips=clips[5];
						yield  return new WaitForSeconds (.5f);
				}
		}

		IEnumerator route_1_4 ()
		{	
			
				GameObject bb;
				
				int i = 0;
				//for (i=0; i<6; i++)
				//	{
				bb = (GameObject)Instantiate (b3_w, (va + v6 [i]), Quaternion.identity);
				bb.AddComponent ("rotation");
				bb.GetComponent<rotation> ().type = false;
				bb.GetComponent<rotation> ().wspeed = 20;
				bb.GetComponent<rotation> ().clip=clips[4];
				

				bb = (GameObject)Instantiate (b3_w, (va + v6 [5 - i]), Quaternion.identity);
				bb.AddComponent ("rotation");
				bb.GetComponent<rotation> ().type = true;
				bb.GetComponent<rotation> ().wspeed = 20;		
				bb.GetComponent<rotation> ().clip=clips[4];

				yield  return new WaitForSeconds (4.0f);
				//	}



			
		}

		IEnumerator route_1_3 ()
		{
				int j = 0, i = 0, k = 0;
				GameObject bb;

				for (k=0; k<8; k++) {
						for (j=0; j<9; j++) {     // maze prototype clockwise
								for (i=0; i<8; i++) {
										
										bb = (GameObject)Instantiate (iceball, Quaternion.Euler (0, 5 * j, 0) * (va + v8 [i]), Quaternion.Euler (0, Random.value * 360, 0));
										bb.AddComponent ("straightline");
										bb.GetComponent<straightline> ().up = false;
										bb.GetComponent<straightline> ().yspeed = 2.5f;
								}
								yield  return new WaitForSeconds (.4f);
						}

						if (k %2==0) {
								for (j=0; j<8; j++) {    // maze prototype anticlockwise
										bb = (GameObject)Instantiate (dirice, va + v8 [j], Quaternion.identity);
										bb.AddComponent ("aimedShoot");
										bb.GetComponent<aimedShoot> ().type = true;
								}
					
					
						} else {
								for (j=0; j<8; j++) {    // maze prototype anticlockwise
										bb = (GameObject)Instantiate (dirice, va + v8 [4] + Vector3.down * j / 2, Quaternion.identity);						
										bb.AddComponent ("aimedShoot");
										bb.GetComponent<aimedShoot> ().type = true;
								}
						}

						for (j=0; j<9; j++) {    // maze prototype anticlockwise
								for (i=0; i<8; i++) {
										bb = (GameObject)Instantiate (iceball, Quaternion.Euler (0, -5 * j, 0) * (va + v8 [i]), Quaternion.Euler (0, Random.value * 360, 0));
										bb.AddComponent ("straightline");
										bb.GetComponent<straightline> ().up = false;
										bb.GetComponent<straightline> ().yspeed = 2.5f;
								}
								yield  return new WaitForSeconds (.4f);
						}

						if (k % 2==0) {
								for (j=0; j<8; j++) {    // maze prototype anticlockwise
										bb = (GameObject)Instantiate (dirice, va + v8 [j], Quaternion.identity);
										bb.AddComponent ("aimedShoot");
										bb.GetComponent<aimedShoot> ().type = false;
								}

						
						} else {
								for (j=0; j<8; j++) {    // maze prototype anticlockwise
										bb = (GameObject)Instantiate (dirice, va + v8 [4] + Vector3.down * j / 2, Quaternion.identity);
										bb.AddComponent ("aimedShoot");
										bb.GetComponent<aimedShoot> ().type = false;
								}
						}

				}
		}

		IEnumerator route_1_1 ()
		{
				
				GameObject bb;
				bb = (GameObject)Instantiate (title1, Vector3.back * 10 + va, Quaternion.identity);
				bb.AddComponent ("rands");
				bb.GetComponent<rands> ().yspeed = 1;
				bb.GetComponent<rands> ().wspeed = 30;



				bb = (GameObject)Instantiate (fairyred, Vector3.back * 10 + va, Quaternion.Euler(0,270,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=true;
				bb.GetComponent<fairy1_1> ().clockwise=true;
				bb.GetComponent<fairy1_1> ().health=15;

				bb = (GameObject)Instantiate (fairyblue, Vector3.forward * 10 + va, Quaternion.Euler(0,270,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().clockwise=false;
				bb.GetComponent<fairy1_1> ().type=false;
				bb.GetComponent<fairy1_1> ().health=15;

				yield  return new WaitForSeconds (1.0f);

				bb = (GameObject)Instantiate (fairyred, Vector3.left * 10 + va, Quaternion.identity);
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=true;
				bb.GetComponent<fairy1_1> ().clockwise=true;
				bb.GetComponent<fairy1_1> ().health=15;

				bb = (GameObject)Instantiate (fairyblue, Vector3.right * 10 + va, Quaternion.identity);
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=false;
				bb.GetComponent<fairy1_1> ().clockwise=false;
				bb.GetComponent<fairy1_1> ().health=15;

				yield  return new WaitForSeconds (1.0f);

				bb = (GameObject)Instantiate (fairyred, Vector3.forward * 10 + va, Quaternion.Euler(0,90,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=true;
				bb.GetComponent<fairy1_1> ().clockwise=true;
				bb.GetComponent<fairy1_1> ().health=15;

				bb = (GameObject)Instantiate (fairyblue, Vector3.back * 10 + va, Quaternion.Euler(0,90,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=false;
				bb.GetComponent<fairy1_1> ().clockwise=false;
				bb.GetComponent<fairy1_1> ().health=15;

				yield  return new WaitForSeconds (1.0f);

				bb = (GameObject)Instantiate (fairyred, Vector3.right * 10 + va, Quaternion.Euler(0,180,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=true;
				bb.GetComponent<fairy1_1> ().clockwise=true;
				bb.GetComponent<fairy1_1> ().health=15;

				bb = (GameObject)Instantiate (fairyblue, Vector3.left * 10 + va, Quaternion.Euler(0,180,0));
				bb.AddComponent ("fairy1_1");
				bb.GetComponent<fairy1_1> ().type=false;
				bb.GetComponent<fairy1_1> ().clockwise=false;
				bb.GetComponent<fairy1_1> ().health=15;

		}

		IEnumerator route_1_2 ()
		{
				if (difficulty == 1) {
						int i = 0;
						GameObject bb;

						for (i=0; i<8; i++) {
								bb = (GameObject)Instantiate (b1_r, va + v8 [i], Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().up = false;
								bb.GetComponent<rands> ().clockwise = true;

						}
						yield  return new WaitForSeconds (2.0f);
						for (i=0; i<8; i++) {
								bb = (GameObject)Instantiate (b1_g, va + v8 [i], Quaternion.identity);
								bb.AddComponent ("rands");
								bb.GetComponent<rands> ().up = false;
								bb.GetComponent<rands> ().clockwise = false;

						}
						yield  return new WaitForSeconds (2.0f);
						for (i=0; i<8; i++) {
								bb = (GameObject)Instantiate (b1_b, va + v8 [i], Quaternion.identity);
								bb.AddComponent ("straightline");
								bb.GetComponent<straightline> ().up = false;
								bb.GetComponent<straightline> ().yspeed = 3;

						}
						yield  return new WaitForSeconds (1.0f);
				}
		}

		IEnumerator route_1_0()
		{
			manager.SendMessage("setdisplay",3.0f,SendMessageOptions.DontRequireReceiver);
			yield return  new WaitForSeconds(1.0f);

		}

	// text
	/*
	 * textlist.SendMessage("addtext","asdf",SendMessageOptions.DontRequireReceiver);
		yield return  new WaitForSeconds(0.1f);

	 */

}
