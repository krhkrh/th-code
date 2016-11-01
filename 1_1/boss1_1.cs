using UnityEngine;
using System.Collections;

public class boss1_1 : MonoBehaviour {


	GameObject player;
	public GameObject root;
	bool finish1=false,finish2=false,finish3=false,finish4=false;
	bool invincible=false;

	public GameObject textlist;

	public string[] spellcardname= new string[2];

	float[] xunit=new float[3];
	float[] yunit=new float[3];
	int[] control=new int[3];
	string countdownstring="40";
	string HP="HP",SP="Shield Endurance";

	GameObject dir,ball,bigtama,ray,b3_w,bice;

	Vector3 va=new Vector3(0,19.0f,0);
	int count=0;

	Vector3[] v8;
	Vector3[] v6;


	float xborder=Screen.width/7;
	float yborder=Screen.height*20/21;
	public GUISkin myskin; 

	public AudioClip[] clips=new AudioClip[10];


	float yspeed=0,wspeed=0;

	Animator anim;
	int lefthash= Animator.StringToHash("left");
	int righthash= Animator.StringToHash("right");
	int spellhash= Animator.StringToHash("spell");
	int attackhash= Animator.StringToHash("attack");
	int breakhash=Animator.StringToHash("break");
	int losehash=Animator.StringToHash("lose");
	int lstatehash=Animator.StringToHash("Base Layer.9left");
	int rstatehash=Animator.StringToHash("Base Layer.9right");
	int idlehash=Animator.StringToHash("Base Layer.9idle");

	public int state=-1;
	int movestate=0;
	int maxhp=500;
	int hp=500,drawhp=500;
	int maxsp=100;
	int sp=100,drawsp=100;
	bool lose=false;

	void setgui(int t)
	{
		StartCoroutine(c(t));
	}

	void clear()
	{
		movestate=3;
		yspeed=2.0f;
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject bb;
		if(other.gameObject.tag=="bullet")
		if(sp>0)
		{
			//bb = (GameObject)Instantiate (dir, gameObject.transform.position + Vector3.down*2 ,Quaternion.identity );
			if(Random.value>0.8)
			{
				audio.PlayOneShot(clips[6]);
				bb = (GameObject)Instantiate (ray, other.transform.position ,Quaternion.identity );
				bb.AddComponent ("saim");
				bb.GetComponent<saim> ().Threshold=0;
				bb.GetComponent<saim> ().type=1;
				bb.transform.localScale=new Vector3(0.3f,0.3f,0.3f);
			}
		}
	}
	
	void applydamage(int damage)
	{
		if(invincible==false)
		{
			if(sp==0)
			{
				if(hp-damage>0)
				hp-=damage;
				else
				{

					anim.SetTrigger(breakhash);
					invincible=true;
					if(finish1==false)
					{
						finish1=true;
					}
					else
					{
						if(finish2==false)
							finish2=true;
						else
						{
							if(finish3==false)
								finish3=true;
							else
							{
								finish4=true;
							}
						}
					}

				}
			}
			else
			{
				sp--;
				if(sp<=0)
				BroadcastMessage("setemitter",false,SendMessageOptions.DontRequireReceiver);
			}
		}

	}




	IEnumerator c(int number)  //0--2
	{
		control[number]=3;
		yield return new WaitForSeconds(1.0f);
		control[number]=1;
		yield return new WaitForSeconds(0.2f);
		control[number]=2;

		while(!lose)
		{
			yield return new WaitForSeconds(1.0f);
			//////////
		}
		control[number]=3;
		yield return new WaitForSeconds(0.2f);
		control[number]=2;
		
	}
	
	void calculatewidth(int number)
	{
		switch(control[number])
		{
		case 0:{xunit[number]=0;}break;
		case 1:{

			switch(number)
			{
				case 0:
				{
					if(xunit[number]<2*xborder)
					xunit[number]+=10f; 
					else 
					xunit[number]=2*xborder;   
				}break;
				case 1:
				{
					if(xunit[number]<2*xborder)
					xunit[number]+=10f; 
					else 
					xunit[number]=2*xborder;   
				}break;
				case 2:
				{
					if(xunit[number]<xborder)
						xunit[number]+=10f; 
					else 
						xunit[number]=xborder;   
				}break;

			}

		}break;
		case 2:
		{
			switch(number)
			{
			case 0:
			{
				xunit[number]=2*xborder/maxhp* drawhp; 
				if(drawhp<hp)
				{
					drawhp++;
				}
				else if(drawhp>hp)
				{
					drawhp=hp;
				}
				if(drawhp<maxhp/2)
				{
					HP="";
				}
				else{HP="HP";}
			}break;
			case 1:
			{
				xunit[number]=2*xborder/maxsp* drawsp; 

				if(drawsp<sp)
				{
					drawsp++;
				}
				else if(drawsp>sp)
				{
					drawsp=sp;
				}
				if(drawsp<maxsp/2)
				{
					SP="";
				}
				else
				{SP="Shield Endurance";}

			}break;
			case 2:
			{
				if(finish3==false)
					countdownstring=(40-count)+"";
				else
					countdownstring="?";
			}break;
				
			}


		}break;
		case 3:{

			switch(number)
			{
				case 0:
				{
					if(xunit[number]>0)
						xunit[number]-=10f; 
					else 
						xunit[number]=0;   
				}break;
				case 1:
				{
					if(xunit[number]>0)
						xunit[number]-=10f; 
					else 
						xunit[number]=0;   
				}break;
				case 2:
				{
					if(xunit[number]>0)
						xunit[number]-=10f; 
					else 
						xunit[number]=0;   
				}break;
				
			}
		}break;
		}
	}




	void OnGUI()
	{
		if(state>=0)
		{
			int i=0;
			for(i=0;i<3;i++)
			{
				calculatewidth(i);
			}

			GUILayout.BeginArea(new Rect(0,yunit[0] ,2*xborder ,yborder/5));
			GUI.skin=myskin;	

			GUILayout.BeginArea(new Rect(0,0,xunit[0],yunit[0]));
			GUILayout.Box(HP+"");
			GUILayout.EndArea();
			
			GUILayout.BeginArea(new Rect(0,yunit[1],xunit[1],yunit[1]));
			GUILayout.Box(SP+"");
			GUILayout.EndArea();
			
			
			GUILayout.BeginArea(new Rect(0,2*yunit[2],xunit[2],yunit[2]));
			GUILayout.Box(countdownstring+"");
			GUILayout.EndArea();

			GUILayout.EndArea();
		}
	}


	void Awake()
	{

		dir=Resources.Load ("dirice", typeof(GameObject)) as GameObject;
		ball=Resources.Load ("iceball", typeof(GameObject)) as GameObject;

		bigtama=Resources.Load("b1_b", typeof(GameObject)) as GameObject;
		b3_w= Resources.Load("b3_w",typeof(GameObject)) as GameObject;
		bice=Resources.Load("bice",typeof(GameObject)) as GameObject;
		ray=Resources.Load("rayparentb",typeof(GameObject)) as GameObject;
		v8 = new Vector3[] {
			Vector3.forward * 10,
			(Vector3.forward+Vector3.left).normalized*10,
			Vector3.left * 10,
			(Vector3.back+Vector3.left).normalized*10,
			Vector3.back * 10,
			(Vector3.back+Vector3.right).normalized*10,
			Vector3.right * 10,
			(Vector3.forward+Vector3.right).normalized*10,
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


	IEnumerator counter1(int bound)
	{
		count=0;
		while(count<bound&&finish1==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				audio.PlayOneShot(clips[4]);
			}
		}
		finish1=true;
	}

	IEnumerator counter2(int bound)
	{
		count=0;
		while(count<bound&&finish2==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				audio.PlayOneShot(clips[4]);
			}
		}
		finish2=true;
	}

	IEnumerator counter3(int bound)
	{
		count=0;
		while(count<bound&&finish3==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				audio.PlayOneShot(clips[4]);
			}
		}
		finish3=true;
	}
	
	void destroyentity()
	{
		GameObject[] d1=GameObject.FindGameObjectsWithTag("entity");
		if(d1.Length!=0)
		{
			foreach(GameObject b in d1)
			{
				Destroy(b);
			}
		}
	}

	void destroyray()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("ray");
		if(d2.Length!=0)
		foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}

	void destroyenergy()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("energy");
		if(d2.Length!=0)
		foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}


	IEnumerator moveplan()
	{
		AnimatorStateInfo stateInfo;

		while(!lose)
		{
			Vector3 direction =new Vector3 (transform.position.x, 0, transform.position.z);
			
			float angle=Quaternion.LookRotation(direction).eulerAngles.y;
			
			direction = -player.transform.forward;
			direction.y = 0;
			float headingAngle = Quaternion.LookRotation(direction).eulerAngles.y;
			stateInfo = anim.GetCurrentAnimatorStateInfo(0);

			wspeed = headingAngle-angle;
			movestate=2;

			if(wspeed<-270)
				wspeed+=360;
			if(wspeed>270)
				wspeed-=360;

			if(wspeed>30)
				wspeed=30;
			if(wspeed<-30)
				wspeed=-30;

			if(headingAngle>angle)
			{

				if(wspeed>10||wspeed<-10)
				{
					wspeed*=1.5f;
					if(stateInfo.nameHash == idlehash )
					{
						anim.SetBool(righthash,true);
					}
				}
				else
				{
					if(stateInfo.nameHash == rstatehash)
					{
						anim.SetBool(righthash,false);
					}
				}

			}
			else
			{
				if(wspeed<-10||wspeed>10) 
				{
					wspeed*=1.5f;
					if(stateInfo.nameHash == idlehash )
					{
						anim.SetBool(lefthash,true);
					}
				}
				else
				{
					if(stateInfo.nameHash == lstatehash)
					{
						anim.SetBool(lefthash,false);
					}
				}

			}


			wspeed*=0.9f;
			yield return new WaitForSeconds(0.5f);



		}

		stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == lstatehash )
		{
			anim.SetBool(lefthash,false);
			movestate=0;
		}
		
		else if(stateInfo.nameHash==rstatehash)
		{
			anim.SetBool(righthash,false);
		}
		movestate=0;
		yield return new WaitForSeconds(0.5f);
		anim.SetTrigger (losehash);


	}


	Vector3 standardposition()
	{
		Vector3 position= new Vector3(transform.position.x,0,transform.position.z);
		Vector3 positiony=new Vector3(0,transform.position.y,0);
		position=position.normalized*10;
		return position+positiony;

	}


	IEnumerator boss1_1_1()
	{
		textlist.SendMessage("addtext",spellcardname[2],SendMessageOptions.DontRequireReceiver);

		StartCoroutine(moveplan());
		yield return new WaitForSeconds(1.0f);
		int i=0,j=0;
		StartCoroutine(counter1(40));
		Vector3 v=Vector3.up*7;
		GameObject bb;

		while(!finish1)
		{

			audio.PlayOneShot(clips[0]);
			for(i=0;i<7;i++)
			{
				for(j=0;j<3;j++)
				{

					bb = (GameObject)Instantiate (dir, standardposition() + Vector3.up*2 ,Quaternion.identity );
					bb.AddComponent ("aimedShoot");
					bb.GetComponent<aimedShoot> ().duration=2+j;
					bb.GetComponent<aimedShoot> ().damagetype=1;
					bb.GetComponent<aimedShoot> ().deflection=i-3;

					bb.transform.localScale= new Vector3(0.3f,0.3f,0.3f);
				}
			}



			i=0;
			while(i<7)
			{
				yield return new WaitForSeconds(0.1f);
				i++;

				if(finish1)
				{
					break;
				}
			}

			if(finish1)
			{
				break;
			}


			audio.PlayOneShot(clips[0]);
			for(i=0;i<7;i++)
			{
				for(j=0;j<3;j++)
				{
					bb = (GameObject)Instantiate (dir,  standardposition()+ Vector3.up*2 ,Quaternion.identity );
					bb.AddComponent ("aimedShoot");
					bb.GetComponent<aimedShoot> ().duration=2+j;
					bb.GetComponent<aimedShoot> ().damagetype=1;
					bb.GetComponent<aimedShoot> ().deflection=i-3;
					
					bb.transform.localScale= new Vector3(0.3f,0.3f,0.3f);
				}
			}


			i=0;
			while(i<10)
			{
				yield return new WaitForSeconds(0.1f);
				i++;
				
				if(finish1)
				{
					break;
				}
			}
			
			if(finish1)
			{
				break;
			}


			audio.PlayOneShot(clips[0]);
			for(i=0;i<7;i++)
			{
				for(j=0;j<3;j++)
				{
					bb = (GameObject)Instantiate (dir, standardposition() + Vector3.up*2 ,Quaternion.identity );
					bb.AddComponent ("aimedShoot");
					bb.GetComponent<aimedShoot> ().duration=1+j;
					bb.GetComponent<aimedShoot> ().damagetype=1;
					bb.GetComponent<aimedShoot> ().deflection=i-3;
					
					bb.transform.localScale= new Vector3(0.3f,0.3f,0.3f);
				}
			}

			i=0;
			while(i<20)
			{
				yield return new WaitForSeconds(0.1f);
				i++;
				
				if(finish1)
				{
					break;
				}
			}
			
			if(finish1)
			{
				break;
			}

			Vector3 axis= new Vector3(transform.position.x,5,transform.position.z);
			audio.PlayOneShot(clips[8]);
			audio.PlayOneShot(clips[0]);
			for(i=0;i<36;i++)
			{
				if(i%6==0)
				{
					bb = (GameObject)Instantiate (b3_w, standardposition() + Vector3.up*2 ,Quaternion.identity );
					bb.AddComponent ("spawn_circle");

					bb.GetComponent<spawn_circle> ().aim=v;

					bb.GetComponent<spawn_circle> () .type=1;

					bb.GetComponent<spawn_circle> ().radius=13;
					bb.GetComponent<spawn_circle> ().clip=clips[0];

					bb.transform.localScale= new Vector3(0.2f,0.2f,0.2f);

				}
				else
				{

					bb = (GameObject)Instantiate (bice, standardposition() + Vector3.up*2,Quaternion.LookRotation(v.normalized) );
					bb.AddComponent ("saim");
					bb.GetComponent<saim> ().aim=v;
					bb.GetComponent<saim> ().type=1;

				}
				v=Quaternion.AngleAxis(10,axis)*v;
			}

			i=0;
			while(i<90)
			{
				yield return new WaitForSeconds(0.1f);
				i++;
				
				if(finish1)
				{
					break;
				}
			}
			
			if(finish1)
			{
				break;
			}
		}
		audio.PlayOneShot(clips[3]);
		state++;
		destroyenergy();
		destroyentity();
	}

	IEnumerator  boss1_1_spell_1()
	{
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		BroadcastMessage("setemitter",true,SendMessageOptions.DontRequireReceiver);


		transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x,-5,player.transform.position.z)); 
	
		if(stateInfo.nameHash == lstatehash )
		{
			anim.SetBool(lefthash,false);
			movestate=0;
		}
		
		else if(stateInfo.nameHash==rstatehash)
		{
			anim.SetBool(righthash,false);
		}
		movestate=0;
		yield return new WaitForSeconds(2.0f);
		anim.SetTrigger (spellhash);
		audio.PlayOneShot(clips[1]);

		textlist.SendMessage("addtext",spellcardname[0],SendMessageOptions.DontRequireReceiver);
		yield return new WaitForSeconds(1.0f);
		//textlist.SendMessage("addtext",spellcardname[0],SendMessageOptions.DontRequireReceiver);
		StartCoroutine(counter2(40));
		int i=0,l=1,j=0;
		int ready=8;
		GameObject bb;
		audio.volume=Control.volume*0.7f;
		while(!finish2)
		{


			if(ready>5)
			{
				if(ready==6)
				audio.PlayOneShot(clips[9]);
				for(j=0;j<6;j++)
				{
					bb = (GameObject)Instantiate (ball, v6[j]+va, Quaternion.identity);
					bb.AddComponent ("rands");
					bb.GetComponent<rands> ().clockwise = false;
					bb.GetComponent<rands> ().yspeed = 1.5f;
					bb.GetComponent<rands> ().wspeed = 10.0f;
					bb.GetComponent<rands> ().type=1;
				}
				ready--;
			}
			else {ready--;if(ready==-1)ready=8;}

			j=0;


			bb = (GameObject)Instantiate (bigtama, v6[i]+va, Quaternion.identity);
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = true;
			bb.GetComponent<rands> ().yspeed = 12-l;
			bb.GetComponent<rands> ().wspeed = l*13.0f;
			bb.GetComponent<rands> ().type=1;
			bb.transform.localScale=new Vector3(2,2,2);	
			if(finish2)
			{
				break;
			}
			yield return new WaitForSeconds(0.1f);

			audio.PlayOneShot(clips[9]);
			bb = (GameObject)Instantiate (b3_w, v6[i]+va, Quaternion.identity);
			bb.AddComponent ("spawn_rands");
			bb.GetComponent<spawn_rands> ().clockwise = true;
			bb.GetComponent<spawn_rands> ().yspeed = 12-l;
			bb.GetComponent<spawn_rands> ().wspeed = l*13.0f;
			bb.GetComponent<spawn_rands> ().type=1;
			bb.GetComponent<spawn_rands> ().clip=clips[0];
			bb.transform.localScale=new Vector3(1,1,1);	

			if(finish2)
			{
				break;
			}
			
			yield return new WaitForSeconds(0.1f);

			bb = (GameObject)Instantiate (bigtama, v6[i]+va, Quaternion.identity);
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = true;
			bb.GetComponent<rands> ().yspeed = 12-l;
			bb.GetComponent<rands> ().wspeed = l*13.0f;
			bb.GetComponent<rands> ().type=1;
			bb.transform.localScale=new Vector3(2,2,2);	

			if(finish2)
			{
				break;
			}
			yield return new WaitForSeconds(0.1f);
		
			if(l==7)
			{
				l=1;
			}
			else l++;

			if(i==5)
			{
				i=0;
			}
			else i++;
		}
		state++;

		destroyenergy();
		destroyentity();
		audio.PlayOneShot(clips[2]);
		audio.volume=Control.volume;
		yield return new WaitForSeconds(1.0f);
		destroyentity();

	}

	IEnumerator fastbundle(int p,int level)
	{
		GameObject bb;


			bb = (GameObject)Instantiate (bigtama, v6[p]+va, Quaternion.identity);
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = true;
			bb.GetComponent<rands> ().yspeed = 12-level;
			bb.GetComponent<rands> ().wspeed = level*13.0f;
			bb.GetComponent<rands> ().type=1;
			bb.transform.localScale=new Vector3(2,2,2);	
			yield return new WaitForSeconds(0.1f);
			
			bb = (GameObject)Instantiate (b3_w, v6[p]+va, Quaternion.identity);
			bb.AddComponent ("spawn_rands");
			bb.GetComponent<spawn_rands> ().clockwise = true;
			bb.GetComponent<spawn_rands> ().yspeed = 12-level;
			bb.GetComponent<spawn_rands> ().wspeed = level*13.0f;
			bb.GetComponent<spawn_rands> ().type=1;
			bb.transform.localScale=new Vector3(1,1,1);	

			yield return new WaitForSeconds(0.1f);

			bb = (GameObject)Instantiate (bigtama, v6[p]+va, Quaternion.identity);
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = true;
			bb.GetComponent<rands> ().yspeed = 12-level;
			bb.GetComponent<rands> ().wspeed = level*13.0f;
			bb.GetComponent<rands> ().type=1;
			bb.transform.localScale=new Vector3(2,2,2);	
			yield return new WaitForSeconds(0.1f);
		
		
	}

	IEnumerator slowbundle(int p)
	{
		GameObject bb;
		int j=0;
		while(j<3)
		{
			bb = (GameObject)Instantiate (ball, v6[p]+va, Quaternion.identity);
			bb.AddComponent ("rands");
			bb.GetComponent<rands> ().clockwise = false;
			bb.GetComponent<rands> ().yspeed = 1.5f;
			bb.GetComponent<rands> ().wspeed = 10.0f;
			bb.GetComponent<rands> ().type=1;
			
			yield return new WaitForSeconds(0.5f);
			j++;
		}
	}


	IEnumerator boss1_1_2()
	{

		yield return new WaitForSeconds(1.0f);
		transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x,-5,player.transform.position.z)); 
		BroadcastMessage("setemitter",true,SendMessageOptions.DontRequireReceiver);
		//textlist.SendMessage("addtext",finish2+"",SendMessageOptions.DontRequireReceiver);
		StartCoroutine(counter3(40));
		int i=0;
		GameObject bb;
		int bound=6;
		float wspeed,yspeed=0;
		Vector3 v= Vector3.up;
		while(!finish3)
		{
			Vector3 axis= new Vector3(transform.position.x,0,transform.position.z);

			AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
			if(stateInfo.nameHash == lstatehash )
			{
				anim.SetBool(lefthash,false);
			}
			
			else if(stateInfo.nameHash==rstatehash)
			{
				anim.SetBool(righthash,false);
			}
			movestate=0;

			anim.SetTrigger (attackhash);

			yield return new WaitForSeconds(1.0f);

			audio.PlayOneShot(clips[8]);
			for(i=0;i<bound;i++)
			{

				wspeed= 10*Mathf.Sin(Mathf.Deg2Rad*i*360/bound);
				yspeed= 2*Mathf.Cos(Mathf.Deg2Rad*i*360/bound);


				bb = (GameObject)Instantiate (b3_w,standardposition() + Vector3.up*2 , Quaternion.LookRotation(v.normalized));
				bb.AddComponent ("rands_spawn");
				bb.GetComponent<rands_spawn> ().clockwise = true;
				bb.GetComponent<rands_spawn> ().yspeed = yspeed;
				bb.GetComponent<rands_spawn> ().wspeed = wspeed;
				bb.GetComponent<rands_spawn> ().type=1;
				bb.GetComponent<rands_spawn> ().angle=i*6;
				bb.GetComponent<rands_spawn> ().clip=clips[0];

				v=Quaternion.AngleAxis(60,axis)*v;
			}

			i=0;
			while(i<100)
			{
				yield return new WaitForSeconds(0.1f);
				i++;
				
				if(finish3)
				{
					break;
				}
			}


			if(finish3)
			{
				break;
			}
		}
		audio.PlayOneShot(clips[3]);
		state++;
		destroyentity();
		destroyenergy();
	}

	IEnumerator boss1_1_spell_2()
	{
		int i=0;
		BroadcastMessage("setemitter",true,SendMessageOptions.DontRequireReceiver);
		transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x,-5,player.transform.position.z)); 

		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == lstatehash )
		{
			anim.SetBool(lefthash,false);
		}
		
		else if(stateInfo.nameHash==rstatehash)
		{
			anim.SetBool(righthash,false);
		}
		movestate=0;
		yield return new WaitForSeconds(2.0f);
		anim.SetTrigger (spellhash);
		audio.PlayOneShot(clips[1]);



		textlist.SendMessage("addtext",spellcardname[1],SendMessageOptions.DontRequireReceiver);

		yield return new WaitForSeconds(1.0f);
				GameObject bb;
	//	while(!finish4)
		audio.PlayOneShot(clips[7]);
		bb = (GameObject)Instantiate (ball,standardposition() + Vector3.up*2 , Quaternion.identity);
		bb.AddComponent ("recursive_spawn");
		bb.GetComponent<recursive_spawn> () .category = 4;
		bb.GetComponent<recursive_spawn> ().type=1;
		bb.GetComponent<recursive_spawn> ().clip=clips[7];
		bb.transform.localScale=new Vector3(0.5f,0.5f,0.5f);



		bb = (GameObject)Instantiate (ball, Quaternion.Euler(0,180,0)*(standardposition() + Vector3.up*2) , Quaternion.identity);
		bb.AddComponent ("recursive_spawn");
		bb.GetComponent<recursive_spawn> () .category = 1;
		bb.GetComponent<recursive_spawn> ().type=1;
		bb.GetComponent<recursive_spawn> ().clip=clips[7];
		bb.transform.localScale=new Vector3(0.5f,0.5f,0.5f);


		while(!finish4)
		{

			yield return  new WaitForSeconds(.5f);
			i++;
			if(80-i<10&&i%2==0)
			{
				audio.PlayOneShot(clips[4]);
			}
			if(i==80)
			{
				finish4=true;
				break;
			}

		}

		audio.PlayOneShot(clips[5]);
		destroyentity();
		yield return  new WaitForSeconds(.5f);
		destroyentity();

		
		state++;
	}

	void setstate(int i)
	{
		state =i;
		if(state==0)
		{
			StartCoroutine(boss1_1_behavier());
			setgui(0);
			setgui(1);
			setgui(2);
		}
	}


	IEnumerator boss1_1_behavier()
	{
		transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x,-5,player.transform.position.z)); 
		gameObject.transform.position =new Vector3(player.transform.position.x,0,player.transform.position.z)+ Vector3.up*21;
		hp=maxhp;
		drawhp=hp;
		sp=maxsp;
		drawsp=sp;

		yspeed=10;
		movestate=3;
		while(gameObject.transform.position.y>7)
		{
			yspeed*=0.7f;

			yield return new WaitForSeconds(0.65f);
		}

		movestate = 0;

		while(state==0)
		{
			yield return new WaitForSeconds(0.5f);
		}

		StartCoroutine(boss1_1_1());


		while(state==1)
		{
			yield return new WaitForSeconds(0.5f);
		}
		hp=maxhp;
		sp=maxsp;
		invincible=false;
		StartCoroutine(boss1_1_spell_1());

		while(state==2)
		{
			yield return new WaitForSeconds(0.5f);
		}
		hp=maxhp;
		sp=maxsp;
		invincible=false;
		StartCoroutine(boss1_1_2());

		while(state==3)
		{
			yield return new WaitForSeconds(0.5f);
		}
		hp=maxhp;
		sp=maxsp;
		invincible=false;
		StartCoroutine(boss1_1_spell_2());

		while(state==4)
		{
			yield return new WaitForSeconds(0.5f);
		}
		transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x,-5,player.transform.position.z)); 
		AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == lstatehash )
		{
			anim.SetBool(lefthash,false);
		}
		
		else if(stateInfo.nameHash==rstatehash)
		{
			anim.SetBool(righthash,false);
		}
		movestate=0;
		hp=0;
		sp=0;
		invincible=true;
		anim.SetTrigger(losehash);

		lose=true;


		root.SendMessage("bossfinish",SendMessageOptions.DontRequireReceiver);
	}


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		player=GameObject.FindGameObjectWithTag("Player");

		audio.volume= Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;
		xunit[0]=0;
		yunit[0]=yborder/20;
		xunit[1]=0;
		yunit[1]=yborder/20;
		xunit[2]=0;
		yunit[2]=yborder/20;
	}





	// Update is called once per frame
	void Update () 
	{
		switch(movestate)
		{
			case 0:{}break; //stop
			case 1:{transform.Translate(yspeed*Vector3.up*Time.deltaTime,Space.World);}break; //up
		case 2:{transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);}break; //right
			case 3:{transform.Translate(yspeed*Vector3.down*Time.deltaTime,Space.World);}break; //down
		case 4:{transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);}break; //left
		}
	}
}
