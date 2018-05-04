using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpBehavior : MonoBehaviour 
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

		if(Input.GetMouseButtonUp(1) && Vector2.Distance(yourPos, mousePos) < 0.24f)
		{
			player.GetComponent<playerAction>().setPickUp(true, this.gameObject);
			targeted = true;
		}
	}


	private void checkIfPickedUp ()
	{
		if (pickedUp)
		{
			this.transform.position = player.transform.position;
			Debug.Log("Hey I am being transported");
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
