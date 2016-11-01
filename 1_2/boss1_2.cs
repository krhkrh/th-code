using UnityEngine;
using System.Collections;

public class boss1_2 : MonoBehaviour {

	public float yspeed=10;
	public bool up=false;
	public float wspeed=0;
	public bool clockwise=false;
	public int state=0;
	public GUISkin myskin;
	public string abilityname;

	public GameObject textlist;
	//0 out;1 in;2 start;3 go

	int maxhp=500;
	int hp=500,drawhp=500;

	float[] xunit=new float[2];
	float[] yunit=new float[2];

	float xborder=Screen.width/7;
	float yborder=Screen.height*20/21;


	IEnumerator movedown()
	{
		state=3;
		yield return new WaitForSeconds(1.0f);
		while(yspeed<2.5f)
		{
			yspeed+=0.2f;
			yield return new WaitForSeconds(0.2f);
		}
		yspeed=2.5f;
	}

	IEnumerator slowdown()
	{
		state=1;
		textlist.SendMessage("addtext",abilityname,SendMessageOptions.DontRequireReceiver);
		while(yspeed>0.5f)
		{
			yspeed*=0.7f;
			yield return new WaitForSeconds(0.5f);
		}
		yspeed=0;
		state=2;
	}

	void calculatewidth()
	{

		switch(state)
		{
			case 0:
			{}break;
			case 1:
			{
				if(xunit[0]<2*xborder)
					xunit[0]+=10f; 
				else 
					xunit[0]=2*xborder;   


				if(xunit[1]<xborder)
					xunit[1]+=10f; 
				else 
					xunit[1]=xborder;   
			}break;
			case 2:
			{
				
			}break;
			case 3:
			{
				if(xunit[0]>0)
					xunit[0]-=10f; 
				else 
					xunit[0]=0;   
				
				
				if(xunit[1]<0)
					xunit[1]-=10f; 
				else 
					xunit[1]=0;   

			}break;
		}

	}


	void OnGUI()
	{
		if(state>=0)
		{
			int i=0;
	
			calculatewidth();

			if(xunit[0]>1)
			{
				GUILayout.BeginArea(new Rect(0,yunit[0] ,2*xborder ,2*yunit[0]));
				GUI.skin=myskin;	
				
				GUILayout.BeginArea(new Rect(0,0,xunit[0],yunit[0]));
				GUILayout.Box("HP");
				GUILayout.EndArea();

				GUILayout.BeginArea(new Rect(0,1*yunit[1],xunit[1],yunit[1]));
				GUILayout.Box("99");
				GUILayout.EndArea();
			
				GUILayout.EndArea();
			}
		}
	}


	void clear()
	{
		StartCoroutine(movedown());
	}

	// Use this for initialization
	void Start () {

		xunit[0]=0;
		yunit[0]=yborder/20;
		xunit[1]=0;
		yunit[1]=yborder/20;
		yspeed=12;
		textlist= GameObject.FindGameObjectWithTag("textlist");
		StartCoroutine(slowdown());

	}
	
	// Update is called once per frame
	void Update () {
		if(up)
		{
			transform.Translate(yspeed*Vector3.up*Time.deltaTime,Space.World);
		}
		else
		{
			transform.Translate(yspeed*Vector3.down*Time.deltaTime,Space.World);
		}
		if(clockwise)
		{
			transform.RotateAround (Vector3.zero, Vector3.up, wspeed * Time.deltaTime);
		}
		else
		{
			transform.RotateAround (Vector3.zero, Vector3.down, wspeed * Time.deltaTime);
		}
	}
}
