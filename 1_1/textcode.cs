using UnityEngine;
using System.Collections;

public class textcode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void setcolor(int i)
	{

		if(i==1)
		{
			renderer.material.color=new Color(1.0f,0.4f,0);
			transform.Rotate(Vector3.right,-31,Space.Self);
		}
		else
		{
			renderer.material.color=Color.white;
			transform.Rotate(Vector3.right,31,Space.Self);


		}

	}



}
