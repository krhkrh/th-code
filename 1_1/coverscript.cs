using UnityEngine;
using System.Collections;

public class coverscript : MonoBehaviour {

	public Texture fadeOutTexture;
	public bool s=false;
	Color cw;
	// Use this for initialization
	void Start () {
	//	Rect r =new Rect(-Screen.width/2,-Screen.height/2,Screen.width,Screen.height);
		cw=Color.clear;
		s=true;
	//	guiTexture.pixelInset=r;


	}

	void sets()
	{
		s=true;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		if(s==true)
		{
			cw = Color.Lerp(Color.white, Color.clear, Time.time/2-1.0f);
			GUI.color = cw;
			GUI.depth = -1;
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
		}
	}


}
