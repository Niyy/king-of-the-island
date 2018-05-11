using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBehavior : MonoBehaviour 
{
	private GameObject player;
	private bool pickedUp;
	private bool targeted;


	public void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		pickedUp = targeted = false;
	}


	public void Update()
	{
		checkIfTarget();
		checkIfPickedUp();
	}


	private void checkIfTarget()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 yourPos = this.transform.position;

		if(Input.GetMouseButtonUp(1) && Vector2.Distance(yourPos, mousePos) < 0.24f && !targeted)
		{
			player.GetComponent<PlayerAction>().setState("pick-up", this.gameObject);
			targeted = true;
			player.GetComponent<PlayerAction>().setIfInActionState(false);
			Debug.Log("not really droping box. " + player.GetComponent<PlayerAction>().getIfInActionState());
		}
		else if (Input.GetMouseButtonUp(1) && targeted)
		{
			targeted = false;
			pickedUp = false;
		}
	}


	private void checkIfPickedUp ()
	{
		if (pickedUp)
		{
			this.transform.position = player.transform.position;
			Debug.Log("Hey I am being transported " + player.GetComponent<PlayerAction>().getIfInActionState());
		}
	}


	public void OnTriggerEnter2D (Collider2D collision)
	{
		if (targeted)
		{
			pickedUp = true;
			Debug.Log("I am working");
		}
	}
}
