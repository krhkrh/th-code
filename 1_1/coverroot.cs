using UnityEngine;
using System.Collections;

public class coverroot : MonoBehaviour {

	bool gonext=false;

	public Material sunny2,sunset,night,sunny1;
	public GameObject light1,light2,light3,light4;
	public GameObject text1,text2,text3,text4,pivot,arrow;
	public GameObject dec4_1,firework1,firework2;

	public GameObject hakutakumission,tenshimission,reisenmission,amission;

	public GameObject loadscreen1,loading;

	public AudioClip[] clips=new AudioClip[4];

	//select cancle decide
	int choice1=1,choice2=1,choice3=1;
	int dchoice1=0,dchoice2=0,dchoice3=0;

	// Use this for initialization

	GameObject comet,dust,yy,yy2;

	void Awake()
	{
		comet=Resources.Load("comet",typeof(GameObject)) as GameObject;
		dust=Resources.Load("Smoke Trail",typeof(GameObject)) as GameObject;
		yy=Resources.Load("yy",typeof(GameObject)) as GameObject;
		yy2= Resources.Load("newyy",typeof(GameObject)) as GameObject;

	}

	void Start () {


		Random.seed=(int)(System.DateTime.Now.Ticks);

		switch((int)(Random.Range(0,4)))
		{
		case 0:RenderSettings.skybox=sunny2;light1.light.enabled=true;StartCoroutine(decoration1());

			break;
		case 1:RenderSettings.skybox=sunset;light4.light.enabled=true;StartCoroutine(decoration4());
			break;
		case 2:RenderSettings.skybox=night;light3.light.enabled=true;StartCoroutine(decoration3());
			break;
		case 3:RenderSettings.skybox=sunny1;light2.light.enabled=true;StartCoroutine(decoration2());

			break;
		}
		audio.volume=Control.volume;
		text1.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
		hakutakumission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
	}

	IEnumerator decoration1()
	{
		GameObject bb;
		Vector3 v =	new Vector3(8,5,-55);
		bool c=false;
		v=Quaternion.Euler(180,180,0)*v;

		while(gonext==false)
		{
			if(c==false)
			{
				yield return new WaitForSeconds(Random.Range(10.0f,15.0f));
				if(gonext)
				{
					break;
				}
				c=true;
				for(int i=0;i<5;i++)
				{
					bb = (GameObject)Instantiate (dust,v, Quaternion.identity);
					bb.AddComponent ("decdust");
					v=Quaternion.Euler(40,0,0)*v;
					yield return new WaitForSeconds(1.0f);
				}
			}
			else
			{
				yield return new WaitForSeconds(70.0f);
				if(gonext)
				{
					break;
				}
				c=false;
			}
		}
	}

	IEnumerator decoration2()
	{

		while(gonext==false)
		{

			GameObject bb;

			yield return new WaitForSeconds(Random.Range(5.0f,10.0f));
			if(gonext)
			{
				break;
			}

			if(Random.value>0.5)
			{
				bb = (GameObject)Instantiate (yy,new Vector3(0,200,-100), Quaternion.identity);
				bb.rigidbody.AddForce(new Vector3(Random.Range(0,100),0,Random.Range(0,2000)));
				//bb.rigidbody.AddTorque(new Vector3(Random.Range(0,1000),Random.Range(0,1000),Random.Range(0,1000)));
			}
			else
			{
				bb = (GameObject)Instantiate (yy2,new Vector3(0,200,-100), Quaternion.identity);
				bb.rigidbody.AddForce(new Vector3(Random.Range(0,100),0,Random.Range(-1000,1000)));
				//bb.rigidbody.AddTorque(new Vector3(Random.Range(0,1000),Random.Range(0,1000),Random.Range(0,1000)));
			}
			
			//Quaternion.Euler(Random.Range(0,30),Random.Range(0,30),0)*
		}


		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator decoration3()
	{
		GameObject bb;
	
		Vector3 v = new Vector3(44,5,-163);
		while(gonext==false)
		{
			yield return new WaitForSeconds(Random.Range(5.0f,10.0f));
			if(gonext)
			{
				break;
			}
			bb = (GameObject)Instantiate (comet,new Vector3(Random.Range(0,100),Random.Range(0,100),Random.Range(0,100)), Quaternion.identity);
			bb.AddComponent ("deccomet");
			bb.GetComponent<deccomet>().des=v;
			//Quaternion.Euler(Random.Range(0,30),Random.Range(0,30),0)*
		}
	
	}

	IEnumerator decoration4()
	{

		yield return  new WaitForSeconds(10.0f);
		firework1.SetActive(true);
		firework2.SetActive(true);
		dec4_1.SetActive(true);

		yield return new WaitForSeconds(60.0f);
	}

	void loadscreen(int c)
	{
		switch(c)
		{
		case -1:{loadscreen1.SendMessage("sets",false,SendMessageOptions.DontRequireReceiver);}break;
		case 1:loadscreen1.SetActive(true);loadscreen1.SendMessage("sets",true,SendMessageOptions.DontRequireReceiver);break;
		case 2:break;
		case 3:break;
		case 4:break;
		}
	}

	void movetomission(int c)
	{
		switch(c)
		{
		case 1:loadscreen1.SendMessage("sets",false,SendMessageOptions.DontRequireReceiver);loading.SetActive(true);Application.LoadLevel("mathlab");
			break;
		case 2:break;
		case 3:break;
		case 4:break;

		}

	}

	// Update is called once per frame
	void Update () 
	{


			if(dchoice1==0)
			{
				if (Input.GetKeyDown (KeyCode.UpArrow))
				{
					
					if(choice1>1)
					{
					audio.PlayOneShot(clips[0]);
							choice1--;
					p1(choice1,false);
					}
				else{
					audio.PlayOneShot(clips[3]);
				}
				}
				


				if (Input.GetKeyDown (KeyCode.DownArrow))
				{
						if(choice1<4)
					{
					audio.PlayOneShot(clips[0]);
							choice1++;
						p1(choice1,true);
					}
				else{
					audio.PlayOneShot(clips[3]);
				}
				}

				if (Input.GetKeyDown (KeyCode.X))
				{
					audio.PlayOneShot(clips[0]);
					choice1=4;
				}


				if(Input.GetKeyDown(KeyCode.Z))
				{
					dchoice1=choice1;
					audio.PlayOneShot(clips[2]);
					if(dchoice1==1)
					{
						pivot.SendMessage("main2story",SendMessageOptions.DontRequireReceiver);
					}
					if(dchoice1==2)
					{
						dchoice1=0;
					}
					if(dchoice1==3)
					{
						dchoice1=0;
					}
					if(dchoice1==4)
					{
						Application.Quit();
					}

				}

			}

			else
			{
				if(dchoice1==1)
				{
					if(dchoice2==0)
					{


						if (Input.GetKeyDown (KeyCode.UpArrow))
						{
							if(choice2>1)
							{
								audio.PlayOneShot(clips[0]);
								choice2--;

								p2(choice2,false);
							}

						else{
							audio.PlayOneShot(clips[3]);
						}



						}
						
						if (Input.GetKeyDown (KeyCode.DownArrow))
						{
							if(choice2<4)
						{
							audio.PlayOneShot(clips[0]);
								choice2++;
							p2(choice2,true);
						}
						else{
							audio.PlayOneShot(clips[3]);
						}
						}
						
						if (Input.GetKeyDown (KeyCode.X))
						{
							audio.PlayOneShot(clips[1]);
							pivot.SendMessage("story2main",SendMessageOptions.DontRequireReceiver);
							dchoice1=0;
							dchoice2=0;
						}
						
						if(Input.GetKeyDown(KeyCode.Z))
						{
							audio.PlayOneShot(clips[2]);
							dchoice2=choice2;
							loadscreen(dchoice2);
						}
					}
				else
				{
					if (Input.GetKeyDown (KeyCode.Z))
					{
						audio.PlayOneShot(clips[2]);
						movetomission(dchoice2);
						
					}
					if (Input.GetKeyDown (KeyCode.X))
					{
						audio.PlayOneShot(clips[1]);
						loadscreen(-1);
						dchoice2=0;
					}
				}
				}
				
			}
	}

	void p1(int c1,bool last)
	{

		if(last)
		{

			switch(c1)
			{
			case 1:
				text1.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				
				break;
			case 2:
				text1.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				text2.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 3:
				text2.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				text3.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 4:
				text3.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				text4.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
		else
		{

			switch(c1)
			{
			case 1:
				text1.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				text2.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			case 4:
				text4.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 2:
				text2.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				text3.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			case 3:
				text3.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				text4.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
	}


	void p2(int c1,bool last)
	{
		
		if(last)
		{
			
			switch(c1)
			{
			case 1:
				hakutakumission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				
				break;
			case 2:
				hakutakumission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				tenshimission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 3:
				tenshimission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				reisenmission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 4:
				reisenmission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				amission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
		else
		{
			
			switch(c1)
			{
			case 1:
				hakutakumission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				tenshimission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			case 4:
				amission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				break;
			case 2:
				tenshimission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				reisenmission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			case 3:
				reisenmission.SendMessage("setcolor",1,SendMessageOptions.DontRequireReceiver);
				amission.SendMessage("setcolor",0,SendMessageOptions.DontRequireReceiver);
				break;
			}
		}
	}

}
