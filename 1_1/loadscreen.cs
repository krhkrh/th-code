using UnityEngine;
using System.Collections;

public class loadscreen : MonoBehaviour {
	public Texture fadeinTexture;
	public bool s=false;
	float tick;
	Color cw;
	// Use this for initialization


	void Start () {
		cw=Color.clear;
		//s=true;
	}
	void sets(bool t)
	{
		s=t;
		tick=Time.time;
	}
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI(){

		if(s==false)
		{
			cw = Color.Lerp(Color.white, Color.clear, (Time.time-tick)*2);
			GUI.color = cw;
			GUI.depth = -1;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeinTexture);
		}

		else
		{
			cw = Color.Lerp(Color.clear, Color.white, (Time.time-tick)*2);
			GUI.color = cw;
			GUI.depth = -1;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeinTexture);
		}

	}

}
