using UnityEngine;
using System.Collections;

public class enemybasic : basic {

	
	public int health=100;
	// Use this for initialization
	public int status=1;
	public GameObject power;
	public GameObject point;

	void inchealth(int p)
	{
		health+=p;
	}


	public virtual void Awake()
	{
		power = Resources.Load ("power cube", typeof(GameObject)) as GameObject;
		point = Resources.Load ("point cube", typeof(GameObject)) as GameObject;
	}

	void Start () {

		StartCoroutine(mainroutine());
	}
	
	public void applydamage(int d)
	{
		if(status==1)
		{
			health-=d;
			if(health<=0)
			{
				status=0;
				remove();
			}
		}
	}
	public override void OnTriggerEnter (Collider other)
	{
	}

	public virtual void remove()
	{
		Destroy(gameObject);
	}

	public virtual IEnumerator mainroutine()
	{
		yield return new WaitForSeconds(1.0f);
	}
	
	// Update is called once per frame
	public void Update () {
		base.checkbound();
	
	}
}
