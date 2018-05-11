using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed;
	private Camera camera;
	private PlayerAction playerAction;
	private bool hasADestination;
	private Vector2 playerDestination;

	
	void Start () 
	{
		camera = Camera.main;
		hasADestination = false;
		playerAction = this.GetComponent<PlayerAction>();
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
			Vector2.Distance(this.transform.position, playerDestination) <= playerAction.getActivateDistance())
			{
				hasADestination = false;
				playerAction.setIfInActionState(false);
			}
			else if(playerAction.getState().Equals("combat") &&
			Vector2.Distance(this.transform.position, playerDestination) <= playerAction.getActivateDistance())
			{
				hasADestination = false;
			}
			else if(Vector2.Distance(this.transform.position, playerDestination) <= playerAction.getActivateDistance())
			{
				hasADestination = false;
			}
		}
	}


	private void movePlayerTowardTarget()
	{
		if (Input.GetMouseButtonUp(1) && !GetComponent<PlayerAction>().getState().Equals("idle"))
		{
			hasADestination = true;
			playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
		}
	}


	public float getWalkSpeed()
	{
		return walkSpeed;
	}


	public bool getHasArrived()
	{
		return !hasADestination;
	}
}
