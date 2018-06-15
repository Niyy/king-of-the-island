using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour 
{
	public Vector2 finalDestination;
	public Vector2 currentDestination;
	public float[] patrolArea = new float[4]; //[xmin, xmax, ymin, ymax]
	public string task;
	public float idleTime;
	public float npcMoveSpeed;


	private float capturedTime;
	private bool movingTowardDestination;
	private GameObject defendTarget;
	private bool doINeedADestination;
	private string[] npcStates = new string[3] {"combat", "patrol", "idle"};


	void Start () 
	{
		patrolArea[0] = -5 + this.transform.position.x;
		patrolArea[1] = 5 + this.transform.position.x;
		patrolArea[2] = -5 + this.transform.position.y;
		patrolArea[3] = 5 + this.transform.position.y;

		capturedTime = 0.0f;

		movingTowardDestination = false;
		doINeedADestination = true;

		defendTarget = null;
	}
	
	
	void Update () 
	{
		findNextDestination();
		moveToTarget();
	}


	private void findNextDestination()
	{
		if(capturedTime + idleTime <= Time.time && doINeedADestination)
		{
			finalDestination = new Vector2(Random.Range(patrolArea[0], patrolArea[1]), Random.Range(patrolArea[2], patrolArea[3]));
			capturedTime = Time.time;
			movingTowardDestination = true;
		}
	}


	private void moveToTarget()
	{
		if (movingTowardDestination)
		{
			transform.position = Vector2.MoveTowards(this.transform.position, finalDestination, npcMoveSpeed * Time.deltaTime);
		}

		if (Vector2.Distance(this.transform.position, finalDestination) <= 0.40 && task.Equals(npcStates[0]))
		{
			movingTowardDestination = false;
		}
		else if (Vector2.Distance(this.transform.position, finalDestination) <= 0.00001)
		{

		}
	}


	public void setMoveTarget(Vector2 newMovePosition)
	{
		finalDestination = newMovePosition;
		movingTowardDestination = true;
		doINeedADestination = false;
	}
}
