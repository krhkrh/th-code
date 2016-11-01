using UnityEngine;
using System.Collections;

public class pivot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void main2story()
	{
		animation.CrossFade("main2story",0.3f);

	}

	void story2main()
	{
		animation.CrossFade("story2main",0.3f);
	}

	void sound()
	{
	}

}
