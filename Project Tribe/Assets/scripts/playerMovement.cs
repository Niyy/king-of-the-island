using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour 
{
	public float walkSpeed;
	private Camera camera;
	private playerAction playerAction;
	private bool hasADestination;
	private Vector2 playerDestination;

	
	void Start () 
	{
		camera = Camera.main;
		hasADestination = false;
		playerAction = this.GetComponent<playerAction>();
	}
	
	
	void Update () 
	{
		if (!playerAction.getState().Equals("talking") && !playerAction.getIfInActionState())
		{
			moveplayer();
		}
	}


	public void LateUpdate ()
	{
		if (!playerAction.getState().Equals("talking") && !playerAction.getIfInActionState())
		{
			movePlayerTowardTarget();
		}
		
	}


	private void moveplayer()
	{
		if(Input.GetMouseButton(0))
		{
			hasADestination = true;
			playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
		}

		if(hasADestination)
		{
			this.transform.position = Vector2.MoveTowards(this.transform.position,
			 playerDestination, walkSpeed * Time.deltaTime);

			if (playerAction.getState().Equals("talk") && 
			Vector2.Distance(this.transform.position, playerDestination) <= 0.40f)
			{
				hasADestination = false;
				playerAction.setIfInActionState(false);
			}
			else if(Vector2.Distance(this.transform.position, playerDestination) <= 0.01f)
			{
				hasADestination = false;
			}
		}
	}


	private void movePlayerTowardTarget()
	{
		if (Input.GetMouseButtonUp(1) && !GetComponent<playerAction>().getState().Equals("idle"))
		{
			hasADestination = true;
			playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
		}
	}


	public float getWalkSpeed()
	{
		return walkSpeed;
	}
}
