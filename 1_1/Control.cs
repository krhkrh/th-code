using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {



	int condition=1;

	bool left=false,right=false,up=false,down=false;
	bool fire=false,slow=false;


	struct preserveddata
	{
		public int ups;
		public int bombs;
		public int energy;

	};

	bool informationsent=false;
	preserveddata spare;
	int wmovespeed=30;
	int ymovespeed=5;

	int swmovespeed=20;
	int symovespeed=3;

	bool lrdisabled=false;

	bool paused=false;
	bool gameover=false;

	bool lready=true,rready=false,bombready=true,ultiready=true,ultistate=true;
	bool ready=true;

	Vector3 direction;

	public int ups=100,bombs=3;
	
	int energy=0;

	float barragecooldown=0.4f;
	int barragestr=1;
	float barragespeed=15.0f;
	bool conversation=false;

	public GameObject textlist;
	public string mysinfo;

	public GUITexture border1;
	public GUITexture border2;
	public GUITexture border3;
	public GUITexture border4;
	public GUITexture move1;
	public GUITexture move2;
	public GUITexture move3;
	public GUITexture move4a;
	public GUITexture move4b;
	//public bool shieldon=true;
	public GameObject playerstate;

	public AudioClip[] clips;

	public GameObject root;
	GameObject[] d=new GameObject[4];
	GameObject bulletb,bulletr;
	GameObject drone;
	GameObject bb;
	static public float volume=0.3f;
	// Use this for initialization
	void Awake(){
			bulletr = Resources.Load ("bulletr", typeof(GameObject)) as GameObject;
			bulletb = Resources.Load ("bulletb", typeof(GameObject)) as GameObject;
			drone = Resources.Load ("hakutakusec", typeof(GameObject)) as GameObject;

		}


	void Start () {

		int size=50;
		int x = -Screen.width / 2 + 10;
		int y = -Screen.height / 2 + 10;

		spare.ups=2;
		spare.bombs=3;
		spare.energy=0;


		border1.pixelInset =  new Rect(x+size*3,y,size,size);
		border2.pixelInset =  new Rect(x+size*2,y,size,size);
		border3.pixelInset =  new Rect(x+size,y,size,size);
		border4.pixelInset =  new Rect(x,y,size,size);
		move1.pixelInset=new Rect(x+size*3,y,size,size);
		move4a.pixelInset=new Rect(x+size*2,y,size,size);
		move4b.pixelInset=new Rect(x+size*2,y,size,size);
		move2.pixelInset=new Rect(x+size,y,size,size);
		move3.pixelInset=new Rect(x,y,size,size);

		Vector3 tempv=move4b.transform.position;
		tempv.z=-0.5f;
		move4b.transform.position=tempv;

		light.enabled=false;


		d[0]= (GameObject)Instantiate (drone, Quaternion.Euler(0,10,0)*transform.position +Vector3.up, Quaternion.Euler(270,0,0));
		d[1]= (GameObject)Instantiate (drone, Quaternion.Euler(0,-10,0)*transform.position +Vector3.up, Quaternion.Euler(270,0,0));
		d[2]= (GameObject)Instantiate (drone, Quaternion.Euler(0,20,0)*transform.position +Vector3.down, Quaternion.Euler(270,0,0));
		d[3]= (GameObject)Instantiate (drone, Quaternion.Euler(0,-20,0)*transform.position +Vector3.down, Quaternion.Euler(270,0,0));


		d[0].transform.parent=transform;
		d[1].transform.parent=transform;
		d[2].transform.parent=transform;
		d[3].transform.parent=transform;

		d[0].SetActive(false);
		d[1].SetActive(false);
		d[2].SetActive(false);
		d[3].SetActive(false);
		audio.volume = volume;
		energy=5;
	}

	void OnGUI()
	{

		if (paused == true)
		{
			if(gameover==false)
				GUI.Box (new Rect(-5,-5,Screen.width + 10,Screen.height + 10), "Pause");
			else
			{
				GUI.Box (new Rect(-5,-5,Screen.width + 10,Screen.height + 10), "gameover");
			}
		}


		else
		{


			if(energy<128)
				GUI.Box (new Rect (Screen.width/100,Screen.height/15*11 , 10+energy, 30), "");
			else
				GUI.Box (new Rect (Screen.width/100,Screen.height/15*11 , 10+energy, 30), "max");
			

		}

		//int y = Screen.height;
		//GUI.BeginGroup(new Rect(x-45, y, 40 , 100));
	//	GUI.skin = myskin;

		//GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
		
		//GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);
		
		//GUI.EndGroup();
		//GUI.EndGroup();
	}

	/*void recover(int point)
	{
		if(energy<100&&shieldon==true)
		energy += point;
	}*/





	void incpower(int pw)
	{
		int last=energy;
		if(energy<128)
		{
			energy+=pw;
			scorekeeper.score+=1;
		}
		else
		{
			scorekeeper.score+=6;
		}
		if(pw!=0)
		{
			audio.PlayOneShot(clips[8]);
		}
		if(energy==8 && last<8)
		{
			audio.PlayOneShot(clips[7]);
		}

		if(energy==16&&last<16)
		{
			audio.PlayOneShot(clips[7]);
		}

		if(energy==32&&last<32)
		{
			audio.PlayOneShot(clips[7]);
		}

		if(energy==64&&last<64)
		{
			audio.PlayOneShot(clips[7]);
		}
		if(energy==128&&last<128)
		{
			audio.PlayOneShot(clips[7]);
		}

		if(energy<8)
		{
			barragespeed=15.0f;
			barragestr=2;
			barragecooldown=0.4f;
			d[0].SetActive(false);
			d[1].SetActive(false);
			d[2].SetActive(false);
			d[3].SetActive(false);
		}

		if(energy>=8&&energy<16)
		{

			barragespeed=20.0f;
			barragestr=3;
			barragecooldown=0.4f;
			d[0].SetActive(false);
			d[1].SetActive(false);
			d[2].SetActive(false);
			d[3].SetActive(false);

		}
		if(energy>=16&&energy<32)
		{
			barragespeed=25.0f;
			barragecooldown=0.3f;
			barragestr=4;
			d[0].SetActive(false);
			d[1].SetActive(false);
			d[2].SetActive(false);
			d[3].SetActive(false);
		}
		if(energy>=32&&energy<64)
		{	
			barragestr=3;
			barragespeed=30.0f;
			barragecooldown=0.3f;
			d[0].SetActive(true);
			d[1].SetActive(true);
			d[2].SetActive(false);
			d[3].SetActive(false);
		}
		if(energy>=64&&energy<128)
		{
			barragespeed=35.0f;
			barragestr=5;
			barragecooldown=0.2f;
			d[0].SetActive(true);
			d[1].SetActive(true);
			d[0].SendMessage("setdamage",3,SendMessageOptions.DontRequireReceiver);
			d[1].SendMessage("setdamage",3,SendMessageOptions.DontRequireReceiver);
			d[0].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);
			d[1].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);
			d[2].SetActive(false);
			d[3].SetActive(false);
		}
		if(energy==128)
		{
			barragecooldown=0.15f;
			barragespeed=35.0f;
			d[0].SetActive(true);
			d[1].SetActive(true);
			d[2].SetActive(true);
			d[3].SetActive(true);
			d[0].SendMessage("setdamage",4,SendMessageOptions.DontRequireReceiver);
			d[1].SendMessage("setdamage",4,SendMessageOptions.DontRequireReceiver);
			d[0].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);
			d[1].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);

			d[2].SendMessage("setdamage",4,SendMessageOptions.DontRequireReceiver);
			d[3].SendMessage("setdamage",4,SendMessageOptions.DontRequireReceiver);
			d[2].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);
			d[3].SendMessage("setspeed",35.0f,SendMessageOptions.DontRequireReceiver);
			barragestr=6;
		}

			
	}

	void incplayer(int a)
	{
		audio.PlayOneShot(clips[0]);
		ups+=a;
		playerstate.guiText.text ="player:"+ups+"\n"+"bomb:"+bombs;

	}

	void incbomb(int x)
	{
		audio.PlayOneShot(clips[1]);
		bombs+=x;
		playerstate.guiText.text ="player:"+ups+"\n"+"bomb:"+bombs;
	}

	void incpoint(int po)
	{
		if(po!=0)
		{
			scorekeeper.score+=10;
			audio.PlayOneShot(clips[8]);
		}
	}

	void shield(Collider other)
	{
	}

	/*void shield(Collider other)
	{
		if (other.gameObject.tag == "ray")
		{	point = 1;if (energy - point < 5) {
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
				Destroy(other.gameObject);
			}}
		else if (other.gameObject.tag == "entity")
		{point = 10;if (energy - point < 5) {
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
				Destroy(other.gameObject);
			}}
		else if (other.gameObject.tag == "energy")
		{point = 3;if (energy - point < 5) {
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
				Destroy(other.gameObject);
			}}
		else if (other.gameObject.tag=="smallbomb")
		{
			point=20;
			if (energy - point < 5) {
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
			}
		}
		else if (other.gameObject.tag=="giantbomb")
		{
			point=100;
			if (energy - point < 5) {
				
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
			}
		}
		else if (other.gameObject.tag=="wall")
		{
			point=40;
			if (energy - point < 5) {
				energy = 5;
				shieldon = false;
			} else {
				energy-=point;
			}
		}
		else if (other.gameObject.tag=="myscube")
		{
			gameObject.light.enabled=true;
		}
	}*/

	void setconversationmode(bool t)
	{
		conversation=t;
		lrdisabled=t;
	}

	public void setControlEnabled(bool enab)
	{
		lrdisabled = enab;
	}

	void applydamage(int d)
	{
		switch(condition)
		{
		case -1:{}break;
		case 0:{}break;
		case 1:
		{

			audio.PlayOneShot (clips[6]);
			StartCoroutine(invincible(5.0f));


			//if()    jue si
			if(ups>0)
			{
				ups--;
				bombs=3;
				playerstate.guiText.text ="player:"+ups+"\n"+"bomb:"+bombs;
			}
			else
			{
				ups=-1;
				gameover=true;
				pause();
			}
		}break;
		}

	}

	void OnTriggerEnter(Collider other)
	{
	


		if (other.gameObject.tag=="myscube")
		{
			if(informationsent==false)
			{
				textlist.SendMessage("addtext",mysinfo,SendMessageOptions.DontRequireReceiver);
				lrdisabled=true;
				gameObject.light.enabled=true;
				informationsent=true;
				StartCoroutine(sendcooldown());
			}
		}
	
	}

	IEnumerator sendcooldown()
	{
		yield return new WaitForSeconds(5.0f);
		informationsent=false;
	}

	void OnTriggerStay(Collider other)
	{


	}


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag=="myscube")
		{
			lrdisabled=false;
			gameObject.light.enabled=false;
			root.SendMessage("stagefinish",SendMessageOptions.DontRequireReceiver);
		}
	}

	void pause()
	{

		audio.PlayOneShot (clips[9]);
		if(paused==false)
		{
			Time.timeScale=0.0f;
			setconversationmode(true);
			root.SendMessage("bgmpause",SendMessageOptions.DontRequireReceiver);
			paused=true;
		}
		else
		{
			Time.timeScale=1.0f;
			setconversationmode(false);
			root.SendMessage("bgmresume",SendMessageOptions.DontRequireReceiver);
			paused=false;
		}
	}

	public void changeroot(GameObject r)
	{
		root=r;
	}


	// Update is called once per frame
	void Update () {
			

			if (Input.GetKeyUp (KeyCode.P))
				if(gameover==false)
					pause();
			
			if (Input.GetKeyDown (KeyCode.UpArrow))
				up = true;
			if (Input.GetKeyDown (KeyCode.DownArrow))
				down = true;

			if(conversation)
			{
				if(Input.GetKeyDown(KeyCode.Return))
				{
					root.SendMessage("setskip",true,SendMessageOptions.DontRequireReceiver);
				}

			}

			if (Input.GetKeyDown (KeyCode.LeftArrow))
				left = true;
			if (Input.GetKeyDown (KeyCode.RightArrow))
				right = true;

			if (Input.GetKeyDown (KeyCode.Z))
				fire=true;
			if(lrdisabled)
			{
				fire=false;
			}
			

			if (Input.GetKeyDown (KeyCode.LeftShift))
			{
				slow = true;
				gameObject.renderer.enabled=true;
			}

			if (Input.GetKeyUp (KeyCode.UpArrow))
				up = false;
			if (Input.GetKeyUp (KeyCode.DownArrow))
				down = false;
			if (Input.GetKeyUp (KeyCode.LeftArrow))
				left = false;
			if (Input.GetKeyUp (KeyCode.RightArrow))
				right = false;
			if (Input.GetKeyUp (KeyCode.LeftShift))
			{
				slow = false;
				gameObject.renderer.enabled=false;
			}
			if (Input.GetKeyUp (KeyCode.Z))
				fire=false;
			
			if(slow==false)
			{
				
				if (up == true&&transform.position.y<13.5)
					transform.Translate (Vector3.up * ymovespeed * Time.deltaTime);
				if (down == true&&transform.position.y>-2)
					transform.Translate (-Vector3.up * ymovespeed * Time.deltaTime);
				if (left == true)
					transform.RotateAround (Vector3.zero, Vector3.up, wmovespeed * Time.deltaTime);
				if (right == true)
					transform.RotateAround (Vector3.zero, -Vector3.up, wmovespeed * Time.deltaTime);

				transform.Translate(Vector3.zero);
			}
			else
			{
				

				if (up == true&&transform.position.y<13.5)
					transform.Translate (Vector3.up * symovespeed * Time.deltaTime);
				if (down == true&&transform.position.y>-2)
					transform.Translate (-Vector3.up * symovespeed * Time.deltaTime);
				if (left == true)
					transform.RotateAround (Vector3.zero, Vector3.up, swmovespeed * Time.deltaTime);
				if (right == true)
					transform.RotateAround (Vector3.zero, -Vector3.up, swmovespeed * Time.deltaTime);

				transform.Translate(Vector3.zero);
			}
			
		if(!lrdisabled)
		{
			
			
			
			if (Input.GetKeyDown (KeyCode.X))
			{
				if(bombready&&bombs>0)
					startbomb();
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if(ultistate)
					ultiin();
				else
					ultiout();
			}
		


		if(fire)
		{
			if(!slow)
			{
				
				if(lready)
				{

					audio.PlayOneShot(clips[4]);
					bb = (GameObject)Instantiate (bulletb, Quaternion.Euler(0,2,0)*(transform.position+Vector3.up ), Quaternion.identity);
					bb.AddComponent ("shibulletcode");
					bb.GetComponent<shibulletcode> ().up=true;
					bb.GetComponent<shibulletcode> ().yspeed=barragespeed;
					bb.GetComponent<shibulletcode> ().enemydamage=barragestr;

					d[2].SendMessage("fire",false,SendMessageOptions.DontRequireReceiver);
					d[3].SendMessage("fire",false,SendMessageOptions.DontRequireReceiver);
					lready=false;

					StartCoroutine(cooldownr(barragecooldown));
				}

				if(rready)
				{
					audio.PlayOneShot(clips[4]);
					bb = (GameObject)Instantiate (bulletr, Quaternion.Euler(0,-2,0)*(transform.position+Vector3.up), Quaternion.identity);
					bb.AddComponent ("shibulletcode");
					bb.GetComponent<shibulletcode> ().up=true;
					bb.GetComponent<shibulletcode> ().yspeed=barragespeed;
					bb.GetComponent<shibulletcode> ().enemydamage=barragestr;
					d[0].SendMessage("fire",true,SendMessageOptions.DontRequireReceiver);
					d[1].SendMessage("fire",true,SendMessageOptions.DontRequireReceiver);
					rready=false;
					StartCoroutine(cooldownl(barragecooldown));
				}
			}
			else
			{
				if(ready)
				{
					audio.PlayOneShot(clips[4]);
					bb = (GameObject)Instantiate (bulletb, Quaternion.Euler(0,2,0)*(transform.position+Vector3.up), Quaternion.identity);
					bb.AddComponent ("shibulletcode");
					bb.GetComponent<shibulletcode> ().up=true;
					bb.GetComponent<shibulletcode> ().yspeed=barragespeed;
					bb.GetComponent<shibulletcode> ().enemydamage=barragestr;
					
					bb = (GameObject)Instantiate (bulletr, Quaternion.Euler(0,-2,0)*(transform.position+Vector3.up), Quaternion.identity);
					bb.AddComponent ("shibulletcode");
					bb.GetComponent<shibulletcode> ().up=true;
					bb.GetComponent<shibulletcode> ().yspeed=barragespeed;
					bb.GetComponent<shibulletcode> ().enemydamage=barragestr;
					ready=false;
					StartCoroutine(cooldown(barragecooldown));
				}
			}

		}
		}
	}




	IEnumerator cooldown(float t)
	{
		yield return new WaitForSeconds(t);
		ready=true;
	}

		/*direction = transform.forward;
		// Zero out the y component of your forward vector to only get the direction in the X,Z plane
		direction.y = 0;
		float headingAngle = Quaternion.LookRotation(direction).eulerAngles.y;
		print (headingAngle);*/

	void ultiout()
	{
		audio.PlayOneShot(clips[3]);
		ups=spare.ups;
		bombs=spare.bombs;
		energy=spare.energy;
		ultistate=true;
		Vector3 tempv=move4b.transform.position;
		tempv.z=-0.5f;
		move4b.transform.position=tempv;

		incpower(0);
		playerstate.guiText.text ="player:"+ups+"\n"+"bomb:"+bombs;
	}
	void ultiin()
	{
		if(ultiready)
		{
			audio.PlayOneShot(clips[2]);
			spare.ups=ups;
			spare.bombs=bombs;
			spare.energy=energy;
			Vector3 tempv=move4b.transform.position;
			tempv.z=0.5f;
			move4b.transform.position=tempv;
			ultiready=false;
			ultistate=false;
			StartCoroutine(ulticooldown());
		}
	}

	IEnumerator ulticooldown()
	{
		yield return new WaitForSeconds(60.0f);
		ultiready=true;
	}

	void startbomb()
	{

		bombs--;
		playerstate.guiText.text ="player:"+ups+"\n"+"bomb:"+bombs;
		BroadcastMessage("activitshield",SendMessageOptions.DontRequireReceiver);
		bombready=false;
	}

	void setbombready(bool r)
	{
		bombready=r;
	}

	IEnumerator cooldownr(float bc)
	{
		yield return new WaitForSeconds(bc);
		rready=true;
		
	}
	IEnumerator cooldownl(float bc)
	{
		yield return new WaitForSeconds(bc);
		lready=true;
		
	}

	IEnumerator invincible(float t)
	{

		condition=0;
		yield return new WaitForSeconds(t);
		condition=1;
	}

	/*IEnumerator flash(float t)
	{
		bool k=true;
		float i=0;
		while(i<t)
		{
			if(k==true)
			{
				renderer.enabled=false;
				k=false;
				yield return new WaitForSeconds(0.3f);
			}
			else
			{
				renderer.enabled=true;
				k=true;
				yield return new WaitForSeconds(0.3f);
			}
			i+=0.3f;
		}
	}*/

	IEnumerator icearmor1()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator icearmor2()
	{
		yield return new WaitForSeconds(1.0f);
	}
		
	void skipspell()
	{

	}

	IEnumerator reinforce()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator enlargecollision()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator multicollision()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator targetize()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator transfo()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator satisfication()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator losingheart()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator losingsoul()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator losingmind()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator chaotic()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator stun()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator silence()
	{
		yield return new WaitForSeconds(1.0f);
	}


	IEnumerator seal()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator countdowndamage()
	{
		yield return new WaitForSeconds(1.0f);
	}

}
