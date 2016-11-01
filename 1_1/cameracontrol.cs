using UnityEngine;
using System.Collections;

public class cameracontrol : MonoBehaviour {

	bool left,right=false;
	bool slow=false;
	public float movespeed=30;
	public float smovespeed=10;
	bool mode=false;


	// Use this for initialization
	void Start () {
	
	}

	void changespeed(float newspeed,float snewspeed)
	{
		movespeed=newspeed;
		smovespeed=snewspeed;
	}


	// Update is called once per frame
	void Update () {
	

			if(Input.GetKeyDown(KeyCode.D))
			{
				if(mode==false)
				{
					movespeed=40;
					smovespeed=30;
					mode=true;
				}
				else
				{
					movespeed=30;
					smovespeed=20;
					mode=false;
				}
			}

			if (Input.GetKeyDown (KeyCode.LeftShift))
				slow = true;

			if (Input.GetKeyDown (KeyCode.LeftArrow))
				left = true;
			if (Input.GetKeyDown (KeyCode.RightArrow))
				right = true;
			
			if (Input.GetKeyUp (KeyCode.LeftShift))
				slow = false;

			if (Input.GetKeyUp (KeyCode.LeftArrow))
				left = false;
			if (Input.GetKeyUp (KeyCode.RightArrow))
				right = false;



		if(slow==true)
		{
			if (left == true)
				transform.RotateAround (Vector3.zero, Vector3.up, smovespeed * Time.deltaTime);
			if (right == true)
				transform.RotateAround (Vector3.zero, -Vector3.up, smovespeed* Time.deltaTime);
		}
		else
		{
			if (left == true)
				transform.RotateAround (Vector3.zero, Vector3.up, movespeed * Time.deltaTime);
			if (right == true)
				transform.RotateAround (Vector3.zero, -Vector3.up, movespeed* Time.deltaTime);

		}

	}
}
