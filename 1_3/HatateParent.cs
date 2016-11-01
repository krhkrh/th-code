using UnityEngine;
using System.Collections;

public class HatateParent : MonoBehaviour {

	//game objects
	public GameObject player;
	public GameObject root;
	public GameObject textlist;
	public GameObject conversationManager;
	public GameObject hatate;
	public GameObject b3_v;
	public GameObject shooter3;
	public GameObject cam;
	//action flag
	bool finish1 = false,card_finish1 = false
		,finish2 = false,card_finish2 = false
		,finish3 = false,card_finish3 = false
		,finish4 = false,card_finish4 = false;
	
	//audio command
	private const int SPELLCARD = 0,TIMER = 1,NORMAL_END = 2,SPELL_END = 3,BOSS_END = 4;
	//orbit status
	private const int POSITIVE_FAR = 0, POSITIVE_NEAR = 1,NEGATIVE_FAR = 2, NEGATIVE_MEAR = 3;

	public bool finish3_1_1 = false,finish3_1_2 = false,finish3_2_1 = false,finish3_2_2 = false
		,finish3_3_1 = false,finish3_3_2 = false,finish3_4_1 = false,finish3_4_2 = false;
	
	//motion factors and functional state
	public int moveState = -1;
	public int state = 0;
	private Vector3 transPivot;
	const int  OUTTER_INNER_TRANSIT = 98,NORMAL = 1,CAM_CONTROLLER = 2;
	public float yspeed=0,wspeed=0;
	
	public int clockWise = 1 ,up =1;

	void clear()
	{
		moveState=NORMAL;
		yspeed=2.0f;
	}
	//

	void Awake()
	{

		player = GameObject.FindGameObjectWithTag("Player");
		root = GameObject.FindGameObjectWithTag("GameController");
		conversationManager = GameObject.FindGameObjectWithTag("manager");
		textlist = GameObject.FindGameObjectWithTag("textlist");
		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;
		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;

		//load some shooter
	}

	void Start () {

		hatate.GetComponent<Boss1_3>().player = player;
		hatate.GetComponent<Boss1_3>().parent = gameObject;
		yunit = yborder/20;
		timeCounter = xborder/2;
	
		StartCoroutine(mainRoutine());

	}
	
	private void setBossReady()
	{

		hp = maxhp;
		GUIState = RESTORE;
		invincible = false;
	}
	
	IEnumerator mainRoutine()
	{
		//state moveState
		moveState = 0;
		yield return new WaitForSeconds(3.0f);

		hatate.GetComponent<Boss1_3>().triggerPrepare();

		while(state==0)
		{
			yield return new WaitForSeconds(0.5f);
		}

		if(state == 1)
		{
			hatate.GetComponent<Boss1_3>().triggerStart();
			StartCoroutine(boss1_3_1());
		}

		while(state==1)
		{
			yield return new WaitForSeconds(0.5f);
		}

		//debug setting
		state = 5;

		if(state == 2)
		{
			setBossReady();
			StartCoroutine(boss1_3_spell_1());
		}
		while(state==2)
		{
			yield return new WaitForSeconds(0.5f);
		}
		if(state == 3)
		{
			setBossReady();
			StartCoroutine(boss1_3_2());
		}
		while(state==3)
		{
			yield return new WaitForSeconds(0.5f);
		}

		if(state == 4)
		{
			setBossReady();
			StartCoroutine(boss1_3_spell_2());
		}
		while(state==4)
		{
			yield return new WaitForSeconds(0.5f);
		}
		if(state == 5)
		{
			setBossReady();
			StartCoroutine(boss1_3_3());
		}
		while(state==5)
		{
			yield return new WaitForSeconds(0.5f);
		}
		if(state == 6)
		{
			setBossReady();
			StartCoroutine(boss1_3_spell_3());
		}
		while(state==6)
		{
			yield return new WaitForSeconds(0.5f);
		}
		if(state == 7)
		{
			setBossReady();
			StartCoroutine(boss1_3_4());
		}
		while(state==7)
		{
			yield return new WaitForSeconds(0.5f);
		}
		if(state == 8)
		{
			setBossReady();
			StartCoroutine(boss1_3_spell_4());
		}
		while(state==8)
		{
			yield return new WaitForSeconds(0.5f);
		}
		invincible = true;

		//end game routines
		root.SendMessage("bossfinish",SendMessageOptions.DontRequireReceiver);
	}
	
	const int FAR_LANE = 1, NEAR_LANE = 2;
	const float ZERO = 0f;
	public int laneState = 0;

	const float NEGATIVE_Z_ROTATION = 45;
	const float POSITIVE_Z_ROTATION = 0;
	//const float NEAR_STANDARD_Z_ROTATION = 225;

	const float NEGATIVE_Y_ROTATION = -120;
	const float POSITIVE_Y_ROTATION = 90;



	IEnumerator boss1_3_1()
	{

		StartCoroutine(counter3_1_1(10));//60
		moveState = NORMAL;
		yspeed = 0;
		wspeed = 60;
		clockWise = -1;
		laneState = NEAR_LANE;
		hatate.GetComponent<Boss1_3>().turnAroundDec();

		hatate.GetComponent<Boss1_3>().setTargetRotation(0,NEGATIVE_Y_ROTATION,NEGATIVE_Z_ROTATION);
		hatate.GetComponent<Boss1_3>().setIsTurning(true);

		yield return new WaitForSeconds(360 / wspeed);

		while(!finish3_1_1)
		{

			invincible = true;
			transPivot = getNearToFarPivot();
			moveState = OUTTER_INNER_TRANSIT;

			hatate.SendMessage("acc_Dec",SendMessageOptions.DontRequireReceiver);

			yield return new WaitForSeconds((360 / wspeed) / 2);
			
			laneState = FAR_LANE;
			moveState = NORMAL;
			int i = 0;


			while(i < 2 && !finish3_1_1)
			{
				if(absGetAngleDif(transform.position,player.transform.position)< 45)
				{
					if(isCooldown)
					{}
					else{
						hatate.GetComponent<Boss1_3>().triggerAttackM();
						StartCoroutine(generalCoolDown(3.0f));
						i++;
					}
				}
				yield return new WaitForSeconds(0.5f);
			}
			i=0;

			transPivot = getFarToNearPivot();
			moveState = OUTTER_INNER_TRANSIT;
			wspeed = 45;
			yield return new WaitForSeconds((360 / wspeed) / 2);
			laneState = NEAR_LANE;
			moveState = NORMAL;
			invincible = false;

			while(i < 2 && !finish3_1_1)
			{
				if(absGetAngleDif(transform.position,player.transform.position)< 45)
				{
					if(isCooldown)
					{}
					else{

						hatate.GetComponent<Boss1_3>().triggerAttackS();
						StartCoroutine(generalCoolDown(3.0f));
						i++;
					}
				}
				yield return new WaitForSeconds(0.5f);
			}
			i=0;
			yield return new WaitForSeconds(2.0f);


		}

		//at the end
		//1 play audio
		//2 clear danmaku
		//3 state++;



		state++;

	}
	
	private Vector3 getNearToFarPivot()
	{
		Vector3 temp = new Vector3(transform.position.x, 0, transform.position.z);
		return temp.normalized * -5;
	}
	
	private Vector3 getFarToNearPivot()
	{
		Vector3 temp = new Vector3(transform.position.x, 0, transform.position.z);
		return temp.normalized * 5;
	}

	const float speedAdjustingTimeSpan = 0.5f;



	const float STANDARD_RATIO = 0.5f;
	const float sample_height_distance = 2.5f*Mathf.PI;
	private Vector3 choosePoint(Vector3 target)
	{
		// Vector3 t = target.transform.position;
		//  float height_diff = transform.position.y - t.y;
		//  float angle_diff = getAngleDifference(transform.position, t);
		
		bool relativeDirection = getRelativeDirection(target ,transform.position);
		
		if (relativeDirection)
		{
			Vector3 idealPosition = target;
			idealPosition = Quaternion.Euler(0,0.05f*360, 0)* idealPosition ;
			idealPosition.y += sample_height_distance;
			
			return idealPosition;
		}
		else {
			
			Vector3 idealPosition = target;
			idealPosition = Quaternion.Euler(0, -0.05f * 360, 0) * idealPosition;
			idealPosition.y += sample_height_distance;
			return idealPosition;
		}
	}

	float maxYSpeed = 4;
	float maxWSpeed = 50;
	private void adjustSpeed(Vector3 target)
	{
		wspeed = getAngleDifference(transform.position, target);
		yspeed = getHeightDifference(transform.position, target);
		if (wspeed > 0){
			if (wspeed > maxWSpeed){
				wspeed = maxWSpeed;
			}
		}
		else if (wspeed < 0){
			if (wspeed < -maxWSpeed){
				wspeed = -maxWSpeed;
			}
		}

		if (yspeed > 0){
			if (yspeed > maxYSpeed){
				yspeed = maxYSpeed;
			}
		}
		else if (yspeed < 0) {
			if (yspeed < -maxYSpeed){
				yspeed = -maxYSpeed;
			}
		}
	}

	const float DASH_ACC_FACTOR = 2;
	public float dash_wSpeed, dash_ySpeed;
	
	private bool Dash(Vector3 target)
	{
		bool flag = false;
		if (Mathf.Abs(wspeed) < Mathf.Abs(dash_wSpeed) || Mathf.Abs(yspeed) < Mathf.Abs(dash_ySpeed))
		{
			wspeed *= 2.0f;
			yspeed *= 2.0f;
			flag = false;

		}
		else {
			if ((transform.position - target).magnitude > 3)
				flag = true;
			else flag = false;
		}
		return flag;
	}

	private Vector3 chooseRise(Vector3 target)
	{
		
		bool relativeDirection = getRelativeDirection(target, transform.position);
		
		if (relativeDirection)
		{
			Vector3 idealPosition = target;
			idealPosition = Quaternion.Euler(0, 60, 0) * idealPosition;
			idealPosition.y += 1;
			
			return idealPosition;
		}
		else
		{
			
			Vector3 idealPosition = target;
			idealPosition = Quaternion.Euler(0, -60, 0) * idealPosition;
			idealPosition.y += 1;
			return idealPosition;
		}
	}

	IEnumerator boss1_3_spell_1()
	{
		textlist.SendMessage("addtext",spellcardname[0],SendMessageOptions.DontRequireReceiver);

		StartCoroutine(counter3_1_2(60));//50
		GameObject bb;
		Vector3 va = Vector3.zero;

		invincible = true;
		transPivot = getNearToFarPivot();
		moveState = OUTTER_INNER_TRANSIT;
		
		hatate.SendMessage("acc_Dec",SendMessageOptions.DontRequireReceiver);
		
		yield return new WaitForSeconds((360 / wspeed) / 2);
		
		laneState = FAR_LANE;
		moveState = CAM_CONTROLLER;
		yspeed = 3;

		textlist.SendMessage("addtext",camSize[0],SendMessageOptions.DontRequireReceiver);
		cam.GetComponent<MeshRenderer>().enabled = true;
		cam.GetComponent<Collider>().enabled = true;

		int i=0;
		while(!finish3_1_2)
		{
			if(i%10 == 0)
			{
				Vector3 minusHorizontalPosition = - getPlayerXYVector(player.transform);
				minusHorizontalPosition.y = 9.5f + Random.Range(-5,5);
				bb = (GameObject)Instantiate (b3_v, minusHorizontalPosition, Quaternion.Euler(270,0,0));
				bb.AddComponent("rainbowseed");
				bb.GetComponent<rainbowseed>().bossVersion = true;
				i++;
			}
			else{
				i++;
			}
			yield return new WaitForSeconds(1.0f);
		}

		cam.GetComponent<MeshRenderer>().enabled = false;
		cam.GetComponent<Collider>().enabled = false;



		transPivot = getFarToNearPivot();
		moveState = OUTTER_INNER_TRANSIT;
		wspeed = 45;
		yspeed = 0;
		yield return new WaitForSeconds((360 / wspeed) / 2);
		laneState = NEAR_LANE;
		moveState = NORMAL;

		while(yspeed>20)
		{
			yspeed -= 5f;
			yield return new WaitForSeconds(0.2f);

		}

		destroyEnergy();
		destroyFunction();

		state++;
	}
	
	private Vector3 getPlayerXYVector(Transform asdf)
	{
		Vector3 v = new Vector3(0,0,0);
		v.Set(asdf.position.x,0,asdf.position.z);
		return v;
	}

	IEnumerator boss1_3_2()
	{

		StartCoroutine(counter3_2_1(60));//60

		clockWise = 1;
		hatate.GetComponent<Boss1_3>().setTargetRotation(0,0);

		hatate.GetComponent<Boss1_3>().setIsTurning(true);
		hatate.SendMessage("turnAroundDec",SendMessageOptions.DontRequireReceiver);



		textlist.SendMessage("addtext",camSize[1],SendMessageOptions.DontRequireReceiver);
		cam.GetComponent<MeshRenderer>().enabled = true;
		cam.GetComponent<Collider>().enabled = true;
		cam.GetComponent<camcontrol>().setSize(1);

		invincible = true;
		GameObject bb;

		bb = (GameObject)Instantiate (shooter3, Vector3.zero, Quaternion.identity);
		bb.AddComponent("Shooter3_7");
		bb.GetComponent<Shooter3_7> ().player = player;
		bb.GetComponent<Shooter3_7> ().workingMode = Shooter3_7.BossBattle;
		yield return new WaitForSeconds(1.0f);

		Vector3 target;
		
		while (!finish3_2_1)
		{
			target = choosePoint(player.transform.position);
			
			while ((transform.position - target).magnitude > 1)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			
			hatate.GetComponent<Boss1_3>().triggerMoveToDown();
			yield return new WaitForSeconds(0.5f);
			
			wspeed = getAngleDifference(transform.position, player.transform.position);
			
			
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,wspeed,0);
			
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			yspeed = getHeightDifference(transform.position, player.transform.position);
			hatate.GetComponent<Boss1_3>().turnAroundDec();
			dash_wSpeed = DASH_ACC_FACTOR * wspeed;
			dash_ySpeed = DASH_ACC_FACTOR * yspeed;

			while (Dash(player.transform.position) == false)
			{

				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			hatate.GetComponent<Boss1_3>().turnAroundDec();

			target = chooseRise(player.transform.position);
			hatate.GetComponent<Boss1_3>().triggerDownToMove();
			int iterator = 0;
			while(iterator < 5)
			{
				wspeed *= 0.9f;
				yspeed *= 0.9f;
				yield return new WaitForSeconds(0.1f);
				iterator++;
			}
			hatate.GetComponent<Boss1_3>().turnAroundDec();
			hatate.GetComponent<Boss1_3>().triggerMoveToUp();
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,-30);
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			while(iterator < 5)
			{
				wspeed *= 0.9f;
				yspeed *= 0.9f;
				yield return new WaitForSeconds(0.1f);
				iterator++;
			}
			
			while ((transform.position - target).magnitude > 2)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,0);
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			target = choosePoint(player.transform.position);
			hatate.GetComponent<Boss1_3>().triggerUpToMove();
			
			while ((transform.position - target).magnitude > 1)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}

		}

		destroyDecoration();

		cam.GetComponent<MeshRenderer>().enabled = false;
		cam.GetComponent<Collider>().enabled = false;

		state++;
		
	}


	IEnumerator boss1_3_spell_2()
	{
		textlist.SendMessage("addtext",spellcardname[1],SendMessageOptions.DontRequireReceiver);
		textlist.SendMessage("addtext",camSize[1],SendMessageOptions.DontRequireReceiver);

		hatate.GetComponent<Boss1_3>().setTargetRotation(0,POSITIVE_Y_ROTATION,POSITIVE_Z_ROTATION);
		
		hatate.GetComponent<Boss1_3>().setIsTurning(true);
		hatate.SendMessage("turnAroundDec",SendMessageOptions.DontRequireReceiver);

		moveState = CAM_CONTROLLER;

		clockWise = 1;
		wspeed = 60;

		if(transform.position.y > 7)
			yspeed = -3;
		else yspeed = 3;

		StartCoroutine(counter3_2_2(60));

		cam.GetComponent<MeshRenderer>().enabled = true;
		cam.GetComponent<Collider>().enabled = true;
		cam.GetComponent<camcontrol>().setSize(1);

		GameObject bb;
		bb = (GameObject)Instantiate (shooter3, player.transform.position, Quaternion.identity);
		bb.AddComponent("NineCutShooter");
		bb.GetComponent<NineCutShooter> ().player = player;


		while(!finish3_2_2)
		{
			yield return new WaitForSeconds(1.0f);
		}
		bb.GetComponent<NineCutShooter> ().setHalt(false);
		destroyEnergy();
		moveState = NORMAL;
		cam.GetComponent<MeshRenderer>().enabled = false;
		cam.GetComponent<Collider>().enabled = false;
		state++;
	}
	
	IEnumerator boss1_3_3()
	{
		//TO DO
		StartCoroutine(counter3_3_1(60));

		clockWise = 1;
		hatate.GetComponent<Boss1_3>().setTargetRotation(0,0);
		
		hatate.GetComponent<Boss1_3>().setIsTurning(true);
		hatate.SendMessage("turnAroundDec",SendMessageOptions.DontRequireReceiver);
		

		textlist.SendMessage("addtext",camSize[1],SendMessageOptions.DontRequireReceiver);
		cam.GetComponent<MeshRenderer>().enabled = true;
		cam.GetComponent<Collider>().enabled = true;
		cam.GetComponent<camcontrol>().setSize(1);
		

		GameObject bb = (GameObject)Instantiate (shooter3, Vector3.zero, Quaternion.identity);
		bb.AddComponent("RisingShooter");
		bb.GetComponent<RisingShooter>().player = player;
		yield return new WaitForSeconds(1.0f);


		Vector3 target;
		
		while (!finish3_3_1)
		{
			target = choosePoint(player.transform.position);
			
			while ((transform.position - target).magnitude > 1)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			
			hatate.GetComponent<Boss1_3>().triggerMoveToDown();
			yield return new WaitForSeconds(0.5f);
			
			wspeed = getAngleDifference(transform.position, player.transform.position);
			
			
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,wspeed,0);
			
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			yspeed = getHeightDifference(transform.position, player.transform.position);
			hatate.GetComponent<Boss1_3>().turnAroundDec();
			dash_wSpeed = DASH_ACC_FACTOR * wspeed;
			dash_ySpeed = DASH_ACC_FACTOR * yspeed;
			
			while (Dash(player.transform.position) == false)
			{
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			hatate.GetComponent<Boss1_3>().turnAroundDec();
			
			target = chooseRise(player.transform.position);
			hatate.GetComponent<Boss1_3>().triggerDownToMove();
			int iterator = 0;
			while(iterator < 5)
			{
				wspeed *= 0.9f;
				yspeed *= 0.9f;
				yield return new WaitForSeconds(0.1f);
				iterator++;
			}
			hatate.GetComponent<Boss1_3>().turnAroundDec();
			hatate.GetComponent<Boss1_3>().triggerMoveToUp();
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,-30);
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			while(iterator < 5)
			{
				wspeed *= 0.9f;
				yspeed *= 0.9f;
				yield return new WaitForSeconds(0.1f);
				iterator++;
			}
			
			while ((transform.position - target).magnitude > 2)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			
			hatate.GetComponent<Boss1_3>().setTargetRotation(0,0);
			hatate.GetComponent<Boss1_3>().setIsTurning(true);
			
			target = choosePoint(player.transform.position);
			hatate.GetComponent<Boss1_3>().triggerUpToMove();
			
			while ((transform.position - target).magnitude > 1)
			{
				adjustSpeed(target);
				
				yield return new WaitForSeconds(speedAdjustingTimeSpan);
			}
			
		}

		bb.GetComponent<RisingShooter>().setFinish(true);

		cam.GetComponent<MeshRenderer>().enabled = false;
		cam.GetComponent<Collider>().enabled = false;
		
		state++;

	}
	IEnumerator boss1_3_spell_3()
	{
		StartCoroutine(counter3_3_2(60));
		textlist.SendMessage("addtext",spellcardname[2],SendMessageOptions.DontRequireReceiver);

		textlist.SendMessage("addtext",camSize[0],SendMessageOptions.DontRequireReceiver);

		cam.GetComponent<MeshRenderer>().enabled = true;
		cam.GetComponent<Collider>().enabled = true;
		cam.GetComponent<camcontrol>().setSize(0);

		moveState = CAM_CONTROLLER;
		wspeed = 25.0f;
		yspeed = 3.0f;




		while(!finish3_3_2)
		{
			yield return new WaitForSeconds(1.0f);
		}
		//state++;
	}
	
	IEnumerator boss1_3_4()
	{
		finish3_4_1 = true;
		yield return new WaitForSeconds(0.1f);
		state++;
	}
	IEnumerator boss1_3_spell_4()
	{
		StartCoroutine(counter3_4_2 (10));
		while(!finish3_4_2)
		{
			yield return new WaitForSeconds(1.0f);
		
		}
		state++;
	}

	void setstate(int i)
	{
		state =i;
	}

	void destroyEntity()
	{
		GameObject[] d1=GameObject.FindGameObjectsWithTag("entity");
		if(d1.Length!=0)
		{
			foreach(GameObject b in d1)
			{
				Destroy(b);
			}
		}
	}
	
	void destroyRay()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("ray");
		if(d2.Length!=0)
			foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}
	
	void destroyEnergy()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("energy");
		if(d2.Length!=0)
			foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}
	void destroyFunction()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("function");
		if(d2.Length!=0)
			foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}

	void destroyDecoration()
	{
		GameObject[] d2=GameObject.FindGameObjectsWithTag("decoration");
		if(d2.Length!=0)
			foreach(GameObject b in d2)
		{
			Destroy(b);
		}
	}


	void Update () {

		if (moveState == OUTTER_INNER_TRANSIT)
		{
			transform.RotateAround(transPivot, Vector3.up, clockWise * wspeed * Time.deltaTime);
			transform.Translate(Vector3.up * yspeed * Time.deltaTime,Space.World);
		}
		else if (moveState == NORMAL)
		{
			transform.RotateAround(Vector3.zero, Vector3.up,clockWise * wspeed * Time.deltaTime);
			transform.Translate(Vector3.up * yspeed * Time.deltaTime,Space.World);
		}
		else if (moveState == CAM_CONTROLLER)
		{
			if (transform.position.y>20)
			{yspeed=-yspeed;}
			
			if (transform.position.y<-5)
			{yspeed=-yspeed;}

			transform.RotateAround(Vector3.zero, Vector3.up,clockWise * wspeed * Time.deltaTime);
			transform.Translate(Vector3.up * yspeed * Time.deltaTime,Space.World);
		}
	}

	bool invincible=false;

	public GUISkin myskin; 
	public string[] spellcardname = new string[4];
	public string[] camSize = new string[3];
	float xborder=Screen.width/7;
	float yborder=Screen.height*20/21;
	float healthBarLength = 0, timeCounter = 0;
	float yunit;
	string countdownstring="40";
	string HP="HP";

	int count = 0; 
	int hp = 200;
	int maxhp=200;
	int drawhp=200;


	void OnTriggerEnter(Collider other)
	{

		GameObject otherCollider = other.gameObject;;
		if(invincible)
		{

		}

		else if (otherCollider.tag == "bullet"){
			applydamage(10);//10
		}
	}

	IEnumerator counter3_1_1(int bound)
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_1_1==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_1_1=true;
	}

	IEnumerator counter3_1_2(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_1_2==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_1_2=true;
	}

	IEnumerator counter3_2_1(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_2_1==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_2_1=true;
	}

	IEnumerator counter3_2_2(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_2_2==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_2_2=true;
	}

	IEnumerator counter3_3_1(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_3_1==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_3_1=true;
	}

	IEnumerator counter3_3_2(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_3_2==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_3_2=true;
	}

	IEnumerator counter3_4_1(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_4_1==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_4_1=true;
	}

	IEnumerator counter3_4_2(int bound )
	{
		counterUpperBound = bound;
		count=0;
		while(count<bound&&finish3_4_2==false)
		{
			
			yield return new WaitForSeconds(1.0f);
			count++;
			if(bound-count<5)
			{
				hatate.GetComponent<Boss1_3>().playOneShot(1);
			}
		}
		finish3_4_2=true;
	}
	int GUIState = 1;
	const int NO_GUI = 0, CONSUME = 1, RESTORE = 2;
	bool paintGui = true;
	int counterUpperBound = 40;

	private bool calculateWidth(int guiState)
	{
		bool restoreComplete = false;
		switch(guiState)
		{
			case CONSUME:{
				healthBarLength = xborder/maxhp* drawhp; 
				if(drawhp<hp)
				{
					drawhp++;
				}
				else if(drawhp>hp)
				{
					drawhp=hp;
				}
				if(drawhp<maxhp/2)
				{
					HP="";
				}
				else{HP="HP";}

			countdownstring=(counterUpperBound-count)+"";
			}break;
			case RESTORE:{

				if(healthBarLength<xborder)
					healthBarLength++; 
				else 
				{
					healthBarLength=xborder;
					drawhp=hp;
					restoreComplete = true;
				}

			countdownstring=(counterUpperBound-count)+"";

			}break;
			case NO_GUI:{paintGui = false;}break;

		}

		return restoreComplete;
	}


	void OnGUI()
	{

		if(state>=0 && paintGui)
		{
			if(calculateWidth(GUIState))
			{
				GUIState = CONSUME;
			}
			else
			{}

			GUILayout.BeginArea(new Rect(0,yunit ,2*xborder ,yborder/5));
			GUI.skin=myskin;	
			
			GUILayout.BeginArea(new Rect(0,0,healthBarLength,yunit));
			GUILayout.Box(HP+"");
			GUILayout.EndArea();

			GUILayout.BeginArea(new Rect(0,yunit,timeCounter,yunit));
			GUILayout.Box(countdownstring+"");
			GUILayout.EndArea();
			
			GUILayout.EndArea();
		}
	}

	/*
	 *  triggerPrepare()
		triggerStart()
		triggerMoveToDown()
		triggerMoveToUp()
		triggerAttackS()
		triggerAttackM()
		triggerUpToMove()
		triggerDownToMove()
		triggerToBreak()
		triggerFightUp()

	 */




	void applydamage(int damage)
	{
		if(invincible==false)
		{
			if(hp-damage>0)
			{

				hp-=damage;

			}
			else
			{

				hatate.GetComponent<Boss1_3>().triggerToBreak();
				hatate.GetComponent<Boss1_3>().playOneShot(NORMAL_END);
				invincible=true;

				switch(state)
				{

					case 1:{finish3_1_1 = true;}break;
					case 2:{finish3_1_2 = true;}break;
					case 3:{finish3_2_1 = true;}break;
					case 4:{finish3_2_2 = true;}break;
					case 5:{finish3_3_1 = true;}break;
					case 6:{finish3_3_2 = true;}break;
					case 7:{finish3_4_1 = true;}break;
					case 8:{finish3_4_2 = true;}break;
					
					default:{print("apply damage hp = 0 called");}break;

				}
			}
		}
	}

	//Utils region
	private Vector3 getHeightVector()
	{
		return new Vector3(0,transform.position.y,0);
	}
	
	private Vector3 getHorizontalVector()
	{
		return new Vector3(transform.position.x, 0, transform.position.z);
	}
	private Vector3 getHorizontalVector(Vector3 v)
	{
		return new Vector3(v.x, 0, v.z);
	}
	private bool getRelativeDirection(Vector3 other,Vector3 self)
	{
		float e;
		e = Vector3.Dot(Vector3.Cross(other, self), Vector3.up);
		if (e >= 0)
			return true;
		else if (e < 0)
			return false;
		else return true;
	}
	private float absGetAngleDif(Vector3 self,Vector3 other)
	{
		return Vector3.Angle(self,other);
	}

	private float getAngleDifference(Vector3 self, Vector3 other)
	{
		float e; float angle;
		
		e = Vector3.Dot(Vector3.Cross(other, self), Vector3.up);
		if (e > 0)
			e = 1;
		else if (e < 0)
			e = -1;
		
		angle = Vector3.Angle(getHorizontalVector(other), getHorizontalVector(self));
		if (angle == 180)
			e = 1;
		
		return -angle * e;
	}

	private float getHeightDifference(Vector3 self, Vector3 other)
	{
		return other.y - self.y;
	}

	private float wrappedCooldown = 5;
	private bool isCooldown = false;

	public void ManipulateCooldown(float mannedCooldown)
	{
		wrappedCooldown = mannedCooldown;
	}
	public void ChangeCooldown(float cut)
	{
		wrappedCooldown += cut;
	}
	

	private IEnumerator generalCoolDown(float coolDownTime)
	{
		isCooldown = true;
		wrappedCooldown = coolDownTime;
		float time = 0;
		while(time < wrappedCooldown)
		{
			time += 0.1f;
			yield return new WaitForSeconds(0.1f);
		}
		isCooldown = false;
	}
}
