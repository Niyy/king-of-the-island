using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcInteraction : MonoBehaviour 
{
	private GameObject player;
	private bool targeted;
	private bool talking;

	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	
	void Update () 
	{
		checkIfTarget();
		talkToPlayer();
	}


	private void talkToPlayer ()
	{
		if(targeted)
		{
			Vector2 playerPos = player.transform.position;
			Vector2 yourPos = this.transform.position;

			if(Vector2.Distance(yourPos, playerPos) <= player.GetComponent<playerAction>().getActivateDistance())
			{
				Debug.Log("Hey whats up Maui!");
				player.GetComponent<playerAction>().setIfInActionState(true);
				targeted = false;
			}
		}
	}


	private void checkIfTarget()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 yourPos = this.transform.position;

		if(Input.GetMouseButtonUp(1) && Vector2.Distance(yourPos, mousePos) < 0.24f)
		{
			player.GetComponent<playerAction>().setState("talk", this.gameObject);
			targeted = true;
		}
	}
}
