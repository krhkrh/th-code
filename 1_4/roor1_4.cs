using UnityEngine;
using System.Collections;

public class root1_4 : MonoBehaviour {

	public GameObject player;
	public GameObject manager;
	public GameObject boss;
	GameObject bossHandler;
	public GameObject textlist;
	
	public AudioClip[] clips;
	public Material[] skies;
	public float volume=Control.volume;

	public string stageName = "";

	bool skip=false;

	Vector3[] v8;
	Vector3[] v6;
	Vector3 va = new Vector3 (0, 19.0f, 0);

	Vector3[] v8;
	Vector3[] v6;
	Vector3 va = new Vector3 (0, 19.0f, 0);
	

	GameObject conversationmanager1_4;
	GameObject myscude;
	GameObject title3;
	
	GameObject root1_5;

	
	GameObject shooter2;
	GameObject shooter3;
	GameObject b3_v;
	GameObject b3_i;
	GameObject fairyred,fairyblue;
	
	bool conversationend=false;

	void Awake ()
	{

		player = GameObject.FindGameObjectWithTag ("Player");


		textlist = GameObject.FindGameObjectWithTag("textlist");
		v8 = new Vector3[] {
			Vector3.forward * 10,
			(Vector3.forward + Vector3.left).normalized * 10,
			Vector3.left * 10,
			(Vector3.back + Vector3.left).normalized * 10,
			Vector3.back * 10,
			(Vector3.back + Vector3.right).normalized * 10,
			Vector3.right * 10,
			(Vector3.forward + Vector3.right).normalized * 10
		};
		
		v6 = new Vector3[] {
			Vector3.forward * 10,
			Quaternion.Euler (0, -60, 0) * v8 [0],
			Quaternion.Euler (0, -120, 0) * v8 [0],
			Quaternion.Euler (0, -180, 0) * v8 [0],
			Quaternion.Euler (0, 120, 0) * v8 [0],
			Quaternion.Euler (0, 60, 0) * v8 [0],
			
		};

		//TODO create asset
		root1_5= Resources.Load("root1_5",typeof(GameObject)) as GameObject;

		//TODO create asset
		boss= Resources.Load("tenshi",typeof(GameObject)) as GameObject;

		//TODO create asset
		conversationmanager1_4= Resources.Load("conversationmanager1_4",typeof(GameObject)) as GameObject;

		shooter2 = Resources.Load("shooter2", typeof(GameObject)) as GameObject;
		shooter3 = Resources.Load("shooter3", typeof(GameObject)) as GameObject;
		myscude = Resources.Load ("cmyscube", typeof(GameObject)) as GameObject;
		title4= Resources.Load("title1_4", typeof(GameObject)) as GameObject;
		
		fairyred= Resources.Load("littltfairy", typeof(GameObject)) as GameObject;
		fairyblue= Resources.Load("littltfairyb", typeof(GameObject)) as GameObject;

		b3_i = Resources.Load("b3_i",typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;

	}

	void Start () {
		audio.volume=volume;
		StartCoroutine (maincoroutine());
		manager = (GameObject)Instantiate (conversationmanager1_4,player.transform.position, Quaternion.identity);
		manager.transform.parent=player.transform;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape")) {
			Application.Quit ();
		}
	}

	void bgmpause()
	{
		audio.mute=true;
	}
	
	void bgmresume()
	{
		audio.mute=false;
	}

	IEnumerator maincoroutine ()
	{
		//TODO create content
		yield return new WaitForSeconds(1.0f);



	}

	IEnumerator endstage4()
	{
		if(bossHandler != null){
			bossHandler.SendMessage("clear",SendMessageOptions.DontRequireReceiver);
			while(bossHandler.transform.position.y>-5)
			{
				audio.volume*=0.5f;
				yield return new WaitForSeconds(1.0f);
			}
		}
	}

	IEnumerator createnext()
	{
		if(root1_5 != null)
		{
			GameObject bb;
			bb = (GameObject) Instantiate(root1_5,Vector3.zero,Quaternion.identity);
			yield return new WaitForSeconds(1.0f);
			
			manager.GetComponent<conversationmanager1_4>().halt();
			player.GetComponent<Control>().changeroot(bb);
			yield return new WaitForSeconds(1.0f);

			Destroy(gameObject);
		}
	
	}

	public void bossfinish()
	{
		bossfin=true;
	}

	void clearDecoration()
	{
		foreach(GameObject g in GameObject.FindGameObjectsWithTag("decoration"))
		{
			Destroy(g);
		}
	}

	private Vector3 getXZhorizontal(Vector3 t)
	{
		return new Vector3(t.x,0,t.z);
	}


}