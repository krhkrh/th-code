using UnityEngine;
using System.Collections;

public class conversationmanager1_3 : MonoBehaviour {


	public Texture[] person1;
	public Texture[] person2;
	
	public Texture stageclear;
	
	public string[] person1words;
	public string[] person2words;
	
	public GUIStyle conversation;
	public GUISkin myskin;
	
	public AudioClip[] clips=new AudioClip[2];
	
	float border=1.0f;
	int p1=0,p2=0;
	
	bool close=false;
	bool display=false;
	int textnumber=1;
	
	public GameObject player;
	public GameObject boss;

	

	public void setPlayer(GameObject bb)
	{
		player = bb;
		if(boss == null)
			boss = player;
	}

	public void setBoss(GameObject bb)
	{
		boss=bb;
	}

void OnGUI()
	{
		if(display)
		{
		//samples here 
		//make sure the plot speech	
			switch(textnumber)
			{
				case 1:
				{
					dialog(2,3);
				}break;
				case 2:
				{
					dialog(1,3);
				}break;
				case 3:
				{
					dialog(2,0);
				}break;
				case 4:
				{
					dialog(1,2);
				}break;
			}
			
		}
	}



void dialog(int speaker,int imagecode)
		{
			if(!close)
			{
				if(border<300)
				{
					
					if(speaker==1)
					{
						
						if(border<10)
						{
							audio.PlayOneShot(clips[0]);
						}
						Vector3 v =  Camera.main.WorldToScreenPoint(player.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						if(imagecode<10)
							GUILayout.Box(person1[imagecode],conversation,GUILayout.Height(border*2/3));
						else{
							GUILayout.Box(stageclear,conversation,GUILayout.Height(border*2/3));
						}
						GUI.skin=myskin;	
						GUILayout.Box("");
						GUILayout.EndArea();
						border+=10;
					}
					
					else if(speaker==2)
					{
						if(border<10)
						{
							audio.PlayOneShot(clips[1]);
						}
						Vector3 v =  Camera.main.WorldToScreenPoint(boss.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						GUILayout.Box(person2[imagecode],conversation,GUILayout.Height(border*2/3));
						GUI.skin=myskin;	
						GUILayout.Box("");
						GUILayout.EndArea();
						border+=10;
					}
					
					
					
				}
				else
				{
					
					if(speaker==1)
					{
						Vector3 v =  Camera.main.WorldToScreenPoint(player.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						if(imagecode<10)
						{
							GUILayout.Box(person1[imagecode],conversation,GUILayout.Height(border*2/3));
							GUI.skin=myskin;	
							GUILayout.Box(person1words[p1]);
							
						}
						else
						{
							GUILayout.Box(stageclear,conversation,GUILayout.Height(border*2/3));
							GUI.skin=myskin;	
							GUILayout.Box(person1words[10]);
						}
						
						GUILayout.EndArea();
					}
					else if(speaker==2)
					{
						Vector3 v =  Camera.main.WorldToScreenPoint(boss.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						GUILayout.Box(person2[imagecode],conversation,GUILayout.Height(border*2/3));
						GUI.skin=myskin;	
						GUILayout.Box(person2words[p2]);
						GUILayout.EndArea();
					}
					
				}
			}
			else{
				if(border>1)
				{
					
					if(speaker==1)
					{
						Vector3 v =  Camera.main.WorldToScreenPoint(player.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						if(imagecode<10)
							GUILayout.Box(person1[imagecode],conversation,GUILayout.Height(border*2/3));
						else{
							GUILayout.Box(stageclear,conversation,GUILayout.Height(border*2/3));
						}
						GUI.skin=myskin;	
						GUILayout.Box("");
						GUILayout.EndArea();
						border-=10;
					}
					else if(speaker==2)
					{
						Vector3 v =  Camera.main.WorldToScreenPoint(boss.transform.position);
						GUILayout.BeginArea(new Rect(v.x+Screen.width/20f,-v.y+Screen.height/1.5f ,border ,border));
						GUILayout.Box(person2[imagecode],conversation,GUILayout.Height(border*2/3));
						GUI.skin=myskin;	
						GUILayout.Box("");
						GUILayout.EndArea();
						border-=10;
					}
					
				}
				else
				{
					if(speaker==1)
						p1++;
					else if(speaker==2)
						p2++;
					
					border=1;
					display=false;
					close=false;
					textnumber++;
				}
			}
			
		}


	public void halt()
	{
		Destroy(gameObject);
	}
	
	void Awake() {}

	void Start () {}
	
	void Update () {}

}