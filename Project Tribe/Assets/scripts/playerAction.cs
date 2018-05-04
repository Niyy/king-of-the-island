using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAction : MonoBehaviour 
{
	private bool goingToPickUp;
	private GameObject pickUpTarget;

	
	void Start () 
	{
		goingToPickUp = false;
	}
	
	
	void Update () 
	{
		
	}


	public void setPickUp (bool newStatues, GameObject itemToBePickedUp)
	{
		goingToPickUp = newStatues;
		pickUpTarget = itemToBePickedUp;
	}


	public bool getPickUpStatues ()
	{
		return goingToPickUp;
	}
}
