using UnityEngine;
using System.Collections;

public class animationcontrol : MonoBehaviour {


	bool left=false,right=false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{


		if (Input.GetKeyDown (KeyCode.LeftArrow))
			left = true;
		if (Input.GetKeyDown (KeyCode.RightArrow))
			right = true;

		if (Input.GetKeyUp (KeyCode.LeftArrow))
			left = false;
		if (Input.GetKeyUp (KeyCode.RightArrow))
			right = false;

		else if (left == true)
			animation.CrossFade("left",0.3f);

		else if (right == true)
			animation.CrossFade("right",0.3f);

		else 
			animation.CrossFade("move",0.3f);


	}
}
