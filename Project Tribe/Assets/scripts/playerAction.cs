using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour 
{
	private string[] actionStates = {"pick-up", "talk"};
	private float[] distanceToActivateState = {0.001f, 0.5f};
	private string currentActionState;
	private bool inActionState;
	private GameObject itemOfAction;

	
	void Start () 
	{
		currentActionState = "idle";
	}
	
	
	void Update () 
	{
		
	}


	public void setState(string newStatues, GameObject targetOfAction)
	{
		currentActionState = newStatues;
		itemOfAction = targetOfAction;
	}


	public bool getIfInActionState()
	{
		return inActionState;
	}


	public void setIfInActionState(bool willItBeInAction)
	{
		inActionState = willItBeInAction;
	}


	public string getState()
	{
		return currentActionState;
	}


	public GameObject getObjectOfInteraction ()
	{
		return itemOfAction;
	}


	public float getActivateDistance()
	{
		float distanceOfActionReturn = 0.0f;

		if(actionStates[0].Equals(currentActionState))
		{
			distanceOfActionReturn = distanceToActivateState[0];
		}
		else if(actionStates[1].Equals(currentActionState))
		{
			distanceOfActionReturn = distanceToActivateState[1];
		}

		return distanceOfActionReturn;
	}


	// private void stateManager()
	// {
	// 	if (playerActionState.Equals(actionStates[0]))
	// 	{
			
	// 	}
	// }
}
