using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour 
{
	public float attackTime;
	public float timeTillAttack;
	public bool dodging;
	public float damageStrengthMin;
	public float damageStrengthMax;


	private Animator animator;
	private string[] actionStates = {"pick-up", "talk", "combat"};
	private float[] distanceToActivateState = {0.001f, 0.4f, 0.4f};
	private string currentActionState;
	private bool inActionState;
	private bool inCombat;
	private GameObject itemOfAction;
	private PlayerMovement playerMovement;
	private PlayerAction playerAction;

	
	void Start () 
	{
		playerMovement = this.GetComponent<PlayerMovement>();
		playerAction = this.GetComponent<PlayerAction>();
		animator = this.GetComponent<Animator>();
		currentActionState = "idle";
		dodging = false;
	}
	
	
	void Update () 
	{
		if (currentActionState.Equals(actionStates[2]))
		{
			combatWatcher();
		}
		else
		{
			inCombat = false;
		}
		Debug.Log("current action state: " + currentActionState);
	}


	public void setState(string newStatues, GameObject targetOfAction)
	{
		currentActionState = newStatues;
		itemOfAction = targetOfAction;

		if(newStatues.Equals(actionStates[2]))
		{
			timeTillAttack = Time.time;
		}
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
		else if (actionStates[2].Equals(currentActionState))
		{
			distanceOfActionReturn = distanceToActivateState[2];
		}

		return distanceOfActionReturn;
	}


	private void combatWatcher()
	{
		if (playerMovement.getHasArrived() && Time.time - timeTillAttack >= attackTime)
		{
			inCombat = true;
			float damageDealt = Mathf.RoundToInt(Random.Range(damageStrengthMin, 
			damageStrengthMax));
			Debug.Log("Attack enemy: " + damageDealt);
			itemOfAction.GetComponent<NPCInteraction>().takeDamage(damageDealt);
			timeTillAttack = Time.time;
		}
	}


	public void getAnimationDirection ()
	{

	}

	
	public bool getIfInCombat ()
	{
		Debug.Log("am I in combat: " + inCombat);
		return inCombat;
	}
}
