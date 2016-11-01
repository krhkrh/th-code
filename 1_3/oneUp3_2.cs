using UnityEngine;
using System.Collections;

public class oneUp3_2 : MonoBehaviour
{


	public Vector3 speed;
	public int motionPeriod;

	void Start ()
	{

		StartCoroutine(speedControl());
	}

	IEnumerator speedControl()
	{
		int i=0;
		
		while(i<motionPeriod)
		{
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		i=0;
		while(i<5)
		{
			
			speed+=Vector3.up;
			i++;
			yield return new WaitForSeconds(1.0f);
		}
		speed=Vector3.zero;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag=="shield")
		{
			other.gameObject.SendMessage("extend",1,SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}

	Vector3 getHorizontalVector(Transform t)
	{
		return new Vector3(t.position.x,0,t.position.z);
	}

	public void startGoToSurface()
	{
		StartCoroutine(goToSurface());
	}
	IEnumerator goToSurface()
	{
		
		Vector3 vr = getHorizontalVector(gameObject.transform);
		speed = -vr.normalized;
		while(vr.sqrMagnitude>100)
		{
			vr= getHorizontalVector(gameObject.transform);
			yield return new WaitForSeconds(0.1f);
		}
		speed =Vector3.zero;
		
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate(speed*Time.deltaTime);
	}
}

