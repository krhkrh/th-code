using UnityEngine;
using System.Collections;

public class loading : MonoBehaviour {

	// Use this for initialization
	void Start () {
		gameObject.guiTexture.pixelInset  =new Rect(-Screen.width/2, -Screen.height/2, Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
