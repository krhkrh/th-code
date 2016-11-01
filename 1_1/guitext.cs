using UnityEngine;
using System.Collections;

public class guitext : MonoBehaviour
{

	public string[] textlist=new string[20]; 
	public string[] sparelist=new string[20]; 
	float time=0.0f;
	public GUISkin myskin; 
	int tail=2;
	float xborder=Screen.width/7;
	float yborder=Screen.height*20/21;
	float[] xunit=new float[20];
	float[] yunit=new float[20];
	int[] control=new int[20];
	Rect re;
	int i=0;
	// Use this for initialization
	void Start () {


		xunit[0]=xborder;
		yunit[0]=yborder/20;
		control[0]=-1;

		xunit[1]=xborder;
		yunit[1]=yborder/10;
		control[1]=-1;

		for(i=2;i<20;i++)
		{
			xunit[i]=0;
			yunit[i]=yunit[0];
			control[i]=2;
		}
	}
	
	void addtext(string t)
	{
		sparelist[tail]=t;
		StartCoroutine(c(tail));
		tail++;
		if(tail==20)
			tail=2;

	}

	IEnumerator c(int number)  //1--18
	{
		control[number]=3;
		yield return new WaitForSeconds(1.0f);
		control[number]=1;
		yield return new WaitForSeconds(0.2f);
		textlist[number]=sparelist[number];
		control[number]=2;
		yield return new WaitForSeconds(4.0f);
		textlist[number]="";
		control[number]=3;
		yield return new WaitForSeconds(0.2f);
		control[number]=2;

	}


	void calculatewidth(int number)
	{
		switch(control[number])
		{
		case 0:{xunit[number]=0;}break;
		case 1:{if(xunit[number]<xunit[0])xunit[number]+=10f; else xunit[number]=xunit[0];}break;
		case 3:{if(xunit[number]>0)xunit[number]-=10f; else xunit[number]=0;}break;
		}
	}

	void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width-xborder,Screen.height-yborder ,xborder ,yborder));
		GUI.skin=myskin;	

		for(i=2;i<20;i++)
		{
			calculatewidth(i);
		}

		for(i=0;i<20;i++)
		{
			GUILayout.BeginArea(new Rect(0,i*yunit[0],xunit[i],yunit[i]));
			GUILayout.Box(textlist[i]);
			GUILayout.EndArea();
		}

		GUILayout.EndArea();
	}



	// Update is called once per frame
	void Update () {
		time+=Time.deltaTime;
		textlist[1]=(int)(time/60)+":"+(int)(time%60);
		textlist[0]=scorekeeper.lastscore+"";
	}
}
