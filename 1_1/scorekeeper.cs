using UnityEngine;
using System.Collections;

public class scorekeeper : MonoBehaviour {


	public static int score=0;
	public int maxscore=0;
	public static int lastscore=0;

	// Use this for initialization
	void Start () 
	{}

	// Update is called once per frame
	void Update () {
		if(lastscore!=score)
		{
			lastscore++;
		}

		if(maxscore<score)
		{
			maxscore=score;
		}
			
	}
}
