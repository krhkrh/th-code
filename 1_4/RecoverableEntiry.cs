using UnityEngine;
using System.Collections;

public class RecoverableEntiry : MonoBehaviour {
{
	void Awake (){}
	void Update(){


	}

	public Rigidbody rigidBody;
	public Transform originalTransform;
	public bool gravityEnabled = true;
	private bool keepDoing = false;

	public void setGravityEnabled(bool enabled)
	{
		if(this.gravityEnabled == enabled && this.gravityEnabled == false)
		{
		}
		else if(this.gravityEnabled == enabled && this.gravityEnabled == true)
		{
		}
		else if (this.gravityEnabled != enabled && this.gravityEnabled == false)
		{
			keepDoing = false;
			this.gravityEnabled = enabled;
			//TODO rigidBody enable gravity
		}
		else if (this.gravityEnabled != enabled && this.gravityEnabled == true)
		{
			keepDoing = true;
			this.gravityEnabled = enabled;
			//TODO rigidBody enable gravity
			startRecover();
		}
		
	}

	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		originalTransform = gameObject.transform;
	}

	public void startRecover()
	{
		StartCoroutine(recoverRoutine());
	}

	public virtual void halt()
	{
		Destroy(gameObject);
	}

	public virtual IEnumerator recoverRoutine()
	{

		//TODO:implementation
		while(keepDoing)
		{

		}
		yield return new WaitForSeconds(1.0f);
	}

	

}