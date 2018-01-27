using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

	private float Speed;
	private float SpeedVariation;
	private float RotationSpeed;
	private bool Check1;
	private bool Check2;
	private bool Check3;
	private bool Check4;
	private bool Check5;
	public Camera camera;

	// Use this for initialization
	void Start () {
		Speed = 1;
		SpeedVariation = 1;
		RotationSpeed = 5;
		Check1 = true;
		Check2 = false;
		Check3 = false;
		Check4 = false;
		Check5 = false;
	}
	
	// Update is called once per frame
	void Update () {
		MoveForward ();
		Rotating ();
	}



	void MoveForward ()
	{
		if(Check1)
		{
			while (camera.transform.position.z != 0) {
				if (Speed <= 20)
				{
					Speed += SpeedVariation;
				}
				camera.transform.Translate (Vector3.forward * Speed, Space.World);
				Debug.Log ("Camera is at " + camera.transform.position.z);
			}
			Check1 = false;
			Check2 = true;
		}
		if (Check3) 
		{
			while (camera.transform.position.x != 0) 
			{
				if (Speed <= 20)
				{
					Speed += SpeedVariation;
				}
				camera.transform.Translate (Vector3.forward * Time.deltaTime, Space.World);
				Debug.Log ("Camera is at " + camera.transform.position.x);
			}
			Check3 = false;
			Check4 = true;
		}
		if (Check5) 
		{
			if (Speed <= 20)
			{
				Speed += SpeedVariation;
			}
			while (camera.transform.position.z != 1900)
			{
				camera.transform.Translate(Vector3.forward * Time.deltaTime, Space.World);
				Debug.Log ("Camera is at " + camera.transform.position.z);
			}
			Check4 = false;
		}
	}


	void Rotating()
	{
		if (Check2) 
		{
			while (camera.transform.rotation.y != 90) 
			{
				camera.transform.Rotate(0, Time.deltaTime * RotationSpeed, 0);
				Debug.Log ("Rotation is at " + camera.transform.rotation.y);
			}
			Check2 = false;
			Check3 = true;
		}
		
		if(Check4) 
		{
			while (camera.transform.rotation.y != 0) 
			{
				camera.transform.Rotate(0, -1 * Time.deltaTime * RotationSpeed, 0);
				Debug.Log ("Rotation is at " + camera.transform.rotation.y);
			}
			Check4 = false;
			Check5 = true;
		}
		
	}
}


//	start. 		-400, 0 , -1000
//	turn #1. 	-400, 0, 0
//	turn #2. 	200, 0, 0
//	rest. 		200, 0, 1900