using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	public float walkSpeed;
	private Camera camera;
	private PlayerAction playerAction;
	private bool hasADestination;
	private bool dodging;
	private Vector2 playerDestination;
	private Vector2 returnLocation;

	
	void Start () 
	{
		camera = Camera.main;
		hasADestination = false;
		playerAction = this.GetComponent<PlayerAction>();
	}
	
	
	void Update () 
	{
		if (!playerAction.getState().Equals("talking"))
		{
			moveplayer();
		}
	}


	public void LateUpdate ()
	{
		if (!playerAction.getState().Equals("talking"))
		{
			movePlayerTowardTarget();
		}
		
	}


	private void moveplayer()
	{
		if(Input.GetMouseButton(0))
		{
			if (!playerAction.getState().Equals("combat"))
			{
				hasADestination = true;
				playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
			}
			else
			{
				Vector2 dodgeDirection = camera.ScreenToWorldPoint(Input.mousePosition);
				returnLocation = this.transform.position;
				dodgeDirection.Normalize();
				playerDestination = dodgeDirection;
				dodging = true;
			}
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

			Debug.Log("hasArrived " + !hasADestination);
		}
		else if (dodging)
		{
			dodgeMove();
		}
	}


	private void movePlayerTowardTarget()
	{
		if(Input.GetMouseButtonUp(1))
		{
			if (playerAction.getIfInCombat())
			{
				hasADestination = true;
				playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
				playerAction.setState("idle", null);
				Debug.Log("Hey I am disengaging.");
			}
			else if (playerAction.getState().Equals("combat"))
			{
				hasADestination = true;
				playerDestination = playerAction.getObjectOfInteraction().transform.position;
			}
			else if (!playerAction.getState().Equals("idle"))
			{
				hasADestination = true;
				playerDestination = camera.ScreenToWorldPoint(Input.mousePosition);
			}
		}
	}


	private void dodgeMove ()
	{
		Vector2 playerPos = this.transform.position;

			this.transform.position = Vector2.MoveTowards(playerPos,
			 playerDestination, walkSpeed * Time.deltaTime);

			if (playerPos.Equals(playerDestination) && !playerDestination.Equals(returnLocation))
			{
				dodging = false;
			}
			 
			Debug.Log("playerDestination = " + playerDestination);
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
