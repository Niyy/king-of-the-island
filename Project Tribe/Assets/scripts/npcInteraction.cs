using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour 
{
	public float currentHealth;
	public float startingHealth;
	public float areaOfAgro;


	private GameObject player;
	private bool targeted;
	private bool talking;
	private NPCMovement npcMovement;
	public string allianceRelation;

	
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		npcMovement = this.GetComponent<NPCMovement>();
		currentHealth = startingHealth;
		//allianceRelation = "neutral";
	}
	
	
	void Update () 
	{
		checkIfTarget();
		talkToPlayer();
		//engageInCombat();
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
			if (allianceRelation.Equals("war") && Vector2.Distance(yourPos, mousePos) <= 0.40)
			{
				player.GetComponent<PlayerAction>().setState("combat", this.gameObject);
				targeted = true;
				Debug.Log("I have been targeted for combat, ");
			}
			else if(Vector2.Distance(yourPos, mousePos) <= 0.40f)
			{
				player.GetComponent<PlayerAction>().setState("talk", this.gameObject);
				targeted = true;
			}
		}
	}


	private void engageInCombat()
	{
		if(Vector2.Distance(this.transform.position, player.transform.position) <= areaOfAgro
		&& allianceRelation.Equals("war"))
		{
			npcMovement.setMoveTarget(player.transform.position);
			Debug.Log("I want to engage in combat!");
		}
	}


	public void takeDamage(float damageAmount)
	{
		currentHealth -= damageAmount;
	}


	public float getCurrentHealth()
	{
		return currentHealth;
	}


	public string getAlliance()
	{
		return allianceRelation;
	}
}
