using UnityEngine;
using System.Collections;

public class boss3_1_util
{

	public static Vector3 get_orbital_changing_axis(Vector3 currentposition,float targetradius)
	{
		Vector3 dey_position = new Vector3(currentposition.x,0,currentposition.z);
		float currentradius = dey_position.magnitude;


		if(currentradius < targetradius)
		{
			return (Vector3.zero - dey_position).normalized * (targetradius - currentradius)/2;
		}
		else
		{
			return  dey_position.normalized * (currentradius-targetradius)/2;

		}
		return Vector3.zero;
	}

	// level:limited number majorly 1~2
	//level = 1 means return the difference between selfposition and playerposition

	public static Vector3 get_exceed_player_position(Vector3 playerposition,Vector3 selfposition,float level)
	{
		float wspeed,yspeed;
		bool type=false;

		Vector3 direction =new Vector3 (selfposition.x, 0, selfposition.z);
		
		float angle=Quaternion.LookRotation(direction).eulerAngles.y;
		
		direction = new Vector3(playerposition.x,0,playerposition.z);

		float headingAngle = Quaternion.LookRotation(direction).eulerAngles.y;

		if(Mathf.Abs(angle- headingAngle) > Mathf.Abs(headingAngle-angle))
			wspeed = (headingAngle-angle)*level;
		else wspeed = (angle-headingAngle)*level;
		//axis unsured

		yspeed = (playerposition.y -selfposition.y)*level;


		return Quaternion.Euler(0,wspeed,0)*selfposition+Vector3.up*yspeed;

	}


	public static float get_relative_height_difference(Vector3 selfposition,Vector3 playerposition)
	{

		float wspeed,yspeed;
		
		Vector3 direction =new Vector3 (selfposition.x, 0, selfposition.z);
		
		float angle=Quaternion.LookRotation(direction).eulerAngles.y;
		
		direction = new Vector3(playerposition.x,0,playerposition.z);
		
		float headingAngle = Quaternion.LookRotation(direction).eulerAngles.y;
		

		wspeed =Mathf.Abs( headingAngle-angle);
		yspeed = Mathf.Abs( playerposition.y -selfposition.y);
		
		return Mathf.Atan2( yspeed,wspeed*Mathf.Deg2Rad*10)*Mathf.Rad2Deg;

	}




}
