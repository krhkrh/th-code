using UnityEngine;
using System.Collections;

public class Boss1_3 : MonoBehaviour {


	/*

right hand positive
far lane and near lane

1, positive near lane
-> face player
-> can shoot_m
-> can shoot_s

2,positive far lane
-> back player
-> can't shoot_m
-> can't shoot_s

3,negative near lane
-> back player
-> can't shoot_s
-> can shoot_m

4,negative far lane
-> face player
-> can shoot_m
-> can shoot_s



	*/

	Animator anim;
	
	int state_idle = Animator.StringToHash("Base Layer.idle");
	int state_stand = Animator.StringToHash("Base Layer.stand");
	int state_start = Animator.StringToHash("Base Layer.start");
	int state_move = Animator.StringToHash("Base Layer.move");
	int state_attack_s = Animator.StringToHash("Base Layer.attack_s");
	int state_attack_m = Animator.StringToHash("Base Layer.attack_m");
	int state_move_to_down = Animator.StringToHash("Base Layer.movetodown");
	int state_go_down = Animator.StringToHash("Base Layer.godown");
	int state_down_to_move = Animator.StringToHash("Base Layer.downtomove");
	int state_move_to_up = Animator.StringToHash("Base Layer.movetoup");
	int state_go_up = Animator.StringToHash("Base Layer.goup");
	int state_up_to_move = Animator.StringToHash("Base Layer.uptomove");
	int state_fight_up = Animator.StringToHash("Base Layer.fight_up");
	int state_spell_break = Animator.StringToHash("Base Layer.break");

	int prepare_trigger = Animator.StringToHash("prepare");
	int start_trigger = Animator.StringToHash("start");
	int attack_s_trigger = Animator.StringToHash("attack_s");
	int attack_m_trigger = Animator.StringToHash("attack_m");
	int moveToDown_trigger = Animator.StringToHash("moveToDown");
	int moveToUp_trigger = Animator.StringToHash("moveToUp");
	int upToMove_trigger = Animator.StringToHash("upToMove");
	int downToMove_trigger = Animator.StringToHash("downToMove");
	int toBreak_trigger = Animator.StringToHash("toBreak");
	int fightUp_trigger = Animator.StringToHash("fightUp");

	public bool isTurning = false;
	private Quaternion targetRotation;

	public AudioClip[] clips = new AudioClip[6];

	public GameObject parent;

	/* 
	clips[0] = spellcard
	clips[1] = timer1
	clips[2] = enep00
	clips[3] = enep02
	clips[4] = BossEnd
*/

	public void playOneShot(int audioCode)
	{
		audio.PlayOneShot(clips[audioCode]);
	}




	public void setTargetRotation(float x,float y,float z)
	{
		this.targetRotation = Quaternion.Euler(x,y,z);
	}

	public void setTargetRotation(int pos,float param)
	{
		if(pos == 0)
		{
			this.targetRotation = Quaternion.Euler(param,transform.rotation.y,transform.rotation.z);
		}
		else if (pos == 1)
		{
			this.targetRotation = Quaternion.Euler(transform.rotation.x,param,transform.rotation.z);
		}
		else if (pos == 2)
		{
			this.targetRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,param);
		}

	}


	public void setTargetRotation(Quaternion quaternion)
	{
		this.targetRotation = quaternion;
	}
	public Quaternion getTargetRotation()
	{
		return this.targetRotation;
	}

	public void setIsTurning(bool turning)
	{
		this.isTurning = turning;
	}

	public void triggerPrepare()
	{
		anim.SetTrigger (prepare_trigger);
	}
	public void triggerStart()
	{
		anim.SetTrigger(start_trigger);
	}
	public void triggerMoveToDown()
	{
		anim.SetTrigger (moveToDown_trigger);
	}
	public void triggerMoveToUp()
	{
		anim.SetTrigger(moveToUp_trigger);
	}
	public void triggerAttackM()
	{
		anim.SetTrigger(attack_m_trigger);
	}
	public void triggerAttackS()
	{
		anim.SetTrigger(attack_s_trigger);

	}

	public void triggerUpToMove()
	{
		anim.SetTrigger(upToMove_trigger);
	}
	public void triggerDownToMove()
	{
		anim.SetTrigger(downToMove_trigger);
	}
	public void triggerToBreak()
	{
		anim.SetTrigger(toBreak_trigger);
	}
	public void triggerFightUp()
	{
		anim.SetTrigger(fightUp_trigger);
	}
	
	public bool isDownToMovePlaying()
	{
		AnimatorStateInfo stateInfo;
		stateInfo = anim.GetCurrentAnimatorStateInfo(0);
		if(stateInfo.nameHash == state_down_to_move)
			return true;
		else return false;
	}


	void movingShoot()
	{
		GameObject bb,shooter;
		
		bb = (GameObject)Instantiate (b3_v_finger, leftFingerTip.transform.position ,Quaternion.LookRotation(player.transform.position - leftFingerTip.transform.position));
		bb.AddComponent<freeBullet>();
		bb.GetComponent<freeBullet>().lifeSpan = 10;
		bb.GetComponent<freeBullet>().speed = (player.transform.position - leftFingerTip.transform.position).normalized *2 ;
		
		shooter = (GameObject)Instantiate (shooter3, leftFingerTip.transform.position,Quaternion.identity);
		shooter.AddComponent<Shooter3_B_windCore>();
		
		shooter.transform.parent = bb.transform;

	}
	private Vector3 getHorizontalVector(Vector3 v)
	{
		return new Vector3(v.x, 0, v.z);
	}
	void steadyShoot()
	{
		GameObject bb,shooter;

		bb = (GameObject)Instantiate (b3_v_finger, leftFingerTip.transform.position ,Quaternion.LookRotation(player.transform.position - leftFingerTip.transform.position));
		bb.AddComponent<freeBullet>();
		bb.GetComponent<freeBullet>().lifeSpan = 10;
		bb.GetComponent<freeBullet>().speed = (player.transform.position - leftFingerTip.transform.position).normalized *2;

		shooter = (GameObject)Instantiate (shooter3, leftFingerTip.transform.position,Quaternion.identity);
		shooter.AddComponent<Shooter3_B_windCore>();

		shooter.transform.parent = bb.transform;

	}

	void leftFoot()
	{
		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter3, leftToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().audio.Play();
	}

	void rightFoot()
	{

		GameObject bb;
		
		bb = (GameObject)Instantiate (shooter3, rightToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().audio.Play();
		bb.GetComponent<Shooter3_B_toeDec>().audio.Play();
	}

	public void turnAroundDec()
	{
		GameObject bb;
		bb = (GameObject)Instantiate (shooter3, rightToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().speedFactor = 10f;
		bb.GetComponent<Shooter3_B_toeDec>().parimeter = 18;

		bb = (GameObject)Instantiate (shooter3, rightToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().speedFactor = 10f;
		bb.GetComponent<Shooter3_B_toeDec>().parimeter = 18;


		bb = (GameObject)Instantiate (shooter3, rightToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().speedFactor = 10f;
		bb.GetComponent<Shooter3_B_toeDec>().parimeter = 18;

		playOneShot(5);

	}

	void acc_Dec()
	{
		GameObject bb;
		bb = (GameObject)Instantiate (shooter3, rightToeTip.transform.position,Quaternion.identity);
		bb.AddComponent<Shooter3_B_toeDec>();
		bb.GetComponent<Shooter3_B_toeDec>().speedFactor = 10f;
		bb.GetComponent<Shooter3_B_toeDec>().parimeter = 18;

		bb.GetComponent<Shooter3_B_toeDec>().audio.Play();
	}



	GameObject b3_v,b3_v_finger;
	GameObject bt2_b,bt2_r,bt2_v;
	GameObject bt2_b_d,bt2_r_d,bt2_v_d;
	public GameObject leftFingerTip,leftToeTip,rightToeTip;
	GameObject[] bt2_d = new GameObject[3];
	GameObject shooter3,shooter2;
	public GameObject player;

	void Awake()
	{
		bt2_b = Resources.Load("bt2_b",typeof(GameObject)) as GameObject;
		bt2_r = Resources.Load("bt2_r",typeof(GameObject)) as GameObject;
		bt2_v = Resources.Load("bt2_v",typeof(GameObject)) as GameObject;

		bt2_b_d = Resources.Load("bt2_b_d",typeof(GameObject)) as GameObject;
		bt2_r_d = Resources.Load("bt2_r_d",typeof(GameObject)) as GameObject;
		bt2_v_d = Resources.Load("bt2_v_d",typeof(GameObject)) as GameObject;

		b3_v = Resources.Load("b3_v",typeof(GameObject)) as GameObject;
		b3_v_finger = Resources.Load("b3_vFingerTip",typeof(GameObject)) as GameObject;

		shooter3 = Resources.Load("shooter3",typeof(GameObject)) as GameObject;
		shooter2 = Resources.Load("shooter2",typeof(GameObject)) as GameObject;

		bt2_d[0] = bt2_b_d;
		bt2_d[1] = bt2_r_d;
		bt2_d[2] = bt2_v_d;

	}

	void Start () {

		anim = GetComponent<Animator>();
		audio.volume= Control.volume;
		audio.rolloffMode=AudioRolloffMode.Linear;
	


	}


	void Update () {

		if(isTurning)
		{
			transform.localRotation  =  Quaternion.Slerp(transform.localRotation, targetRotation , Time.deltaTime *2.5f);
			if(Quaternion.Angle(transform.localRotation ,targetRotation) < 3)
			{
				isTurning = false;
			}
		}

	}
}
