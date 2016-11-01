using UnityEngine;
using System.Collections;

public class shieldscript : MonoBehaviour {

	// Use this for initialization
	GameObject player;
	public AudioClip[] clips;

	void Awake(){
		player=GameObject.FindGameObjectWithTag ("Player");
		}

	void Start () {
		audio.volume=Control.volume;
	}
	void alarm()
	{
		audio.PlayOneShot(clips[0]);
	}

	void secondaryAlarm()
	{
		audio.PlayOneShot(clips[1]);
	}
	void extend(int i)
	{
		player.SendMessage ("incplayer", 1,SendMessageOptions.DontRequireReceiver);
	}

	void extendmove(int i)
	{
		player.SendMessage ("incbomb", 1,SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerEnter(Collider other)
	{
		player.SendMessage ("shield", other,SendMessageOptions.DontRequireReceiver);
	}

	void incpower(int i)
	{
		player.SendMessage("incpower",i,SendMessageOptions.DontRequireReceiver);
	}
	void incpoint(int j)
	{
		player.SendMessage("incpoint",j,SendMessageOptions.DontRequireReceiver);
	}



	// Update is called once per frame
	void Update () {
	
	}
}
