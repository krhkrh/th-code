using UnityEngine;
using System.Collections;

public class basic : MonoBehaviour {

	int upperbound=20;
	int lowerbound=-5;

	public int damage=1;

	public void setdamage(int i)
	{
		damage=i;
	}

	public void setvolume()
	{
		audio.volume=Control.volume;
	}


	public virtual void halt()
	{
		Destroy(gameObject);
	}

	public virtual void OnTriggerEnter(Collider other)
	{

			if(other.gameObject.tag=="Player"||other.gameObject.tag=="enemy"||other.gameObject.tag=="boss")
			{
				other.gameObject.SendMessage("applydamage",damage,SendMessageOptions.DontRequireReceiver);
				Destroy(gameObject);
			}

	}

	public Vector3[] v;
	public virtual void Awake()
	{
		Vector3 forward_left = (Vector3.forward + Vector3.left).normalized * 10;
		Vector3 forward_right = (Vector3.forward + Vector3.right).normalized * 10;
		Vector3 back_left = (Vector3.back + Vector3.left).normalized * 10;
		Vector3 back_right = (Vector3.back + Vector3.right).normalized * 10;
		v=new Vector3[] {Vector3.forward*10,forward_left,Vector3.left*10,back_left,Vector3.back*10,back_right,Vector3.right*10,forward_right};
	}

	public virtual void movetostart()
	{
		gameObject.transform.Translate(Vector3.up*21);
	}

	public virtual void checkbound()
	{
		if(gameObject.tag!="decoration")
		{
			if(gameObject.transform.position.y>upperbound||gameObject.transform.position.y<lowerbound)
				Destroy(gameObject);
		}
		else
		{
			if(gameObject.transform.position.y<lowerbound)
				Destroy(gameObject);

		}

	}
}
