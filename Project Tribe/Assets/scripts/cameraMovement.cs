using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour 
{
	private float panSpeed;
	private GameObject player;
	private bool hasArrived;
	private bool amIMoving;

	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		hasArrived = true;
		panSpeed = player.GetComponent<playerMovement>().getWalkSpeed();
	}
	
	
	void Update () 
	{
		moveCameraTowardsPlayer();
	}


	private bool hasPlayerLeftSweetSpot()
	{
		bool soHaveThey = false;
		Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y,
		-10);
		Vector3 yourPos = this.transform.position;

		if(Vector3.Distance(yourPos, playerPos) > 4)
		{
			soHaveThey = true;
			hasArrived = false;
		}

		return soHaveThey;
	}


	private bool isPlayerInSweetSpot()
	{
		bool soHaveThey = false;
		Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y,
		-10);
		Vector3 yourPos = this.transform.position;

		if(!hasArrived && Vector2.Distance(yourPos, playerPos) >= 0.01f)
		{
			soHaveThey = true;
			hasArrived = false;
		}
		else
		{
			hasArrived = true;
		}

		return soHaveThey;
	}


	private void moveCameraTowardsPlayer()
	{
		Vector3 playerPos = new Vector3(player.transform.position.x, player.transform.position.y,
				-10);

		if(hasPlayerLeftSweetSpot())
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos,
			panSpeed * Time.deltaTime);
			Debug.Log("Player is not in the sweet spot.");
		}
		else if(isPlayerInSweetSpot())
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, playerPos,
			panSpeed * Time.deltaTime * 0.5f);
			Debug.Log("The camera is moving, but in sweet spot.");
		}
		
	}


	public bool isCameraMoving ()
	{
		Debug.Log("hasArrived: " + hasArrived);

		return hasArrived;
	}
}
