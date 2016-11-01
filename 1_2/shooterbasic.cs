using UnityEngine;
using System.Collections;

public class shooterbasic : MonoBehaviour {
	
	public virtual void halt()
	{
		Destroy(gameObject);
	}

	public virtual IEnumerator mainroute()
	{
		yield return new WaitForSeconds(1.0f);
	}

	public virtual void Awake()
	{
		audio.volume=Control.volume;
	}

	// Use this for initialization
	public virtual void Start () {
		StartCoroutine(mainroute());
	}

	// Update is called once per frame
	public virtual void Update () {
	
	}
}
