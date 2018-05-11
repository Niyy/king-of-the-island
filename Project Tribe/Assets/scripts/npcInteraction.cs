using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour 
{
	private GameObject player;
	private bool targeted;
	private bool talking;
	public string allianceRelation;

	
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		allianceRelation = "neutral";
	}
	
	
	void Update () 
	{
		checkIfTarget();
		talkToPlayer();
		engageInCombat();
	}


	private void talkToPlayer ()
	{
		if(targeted)
		{
			Vector2 playerPos = player.transform.position;
			Vector2 yourPos = this.transform.position;

			if(Vector2.Distance(yourPos, playerPos) <= player.GetComponent<PlayerAction>().getActivateDistance())
			{
				player.GetComponent<PlayerAction>().setIfInActionState(true);
				targeted = false;
			}
		}
	}


	private void checkIfTarget()
	{
		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 yourPos = this.transform.position;

		if(Input.GetMouseButtonUp(1))
		{
			if (allianceRelation.Equals("war"))
			{
				player.GetComponent<PlayerAction>().setState("combat", this.gameObject);
				targeted = true;
				Debug.Log("I have been targeted for combat");
			}
			else if(Vector2.Distance(yourPos, mousePos) <= 0.44)
			{
				player.GetComponent<PlayerAction>().setState("talk", this.gameObject);
				targeted = true;
			}
		}
	}


	private void engageInCombat()
	{
		
	}
}
