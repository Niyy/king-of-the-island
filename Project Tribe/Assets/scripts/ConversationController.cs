using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationController : MonoBehaviour 
{
	public Text buttonOne;
	public Text buttonTwo;
	public Text buttonThree;
	public Text buttonFour;
	public Text body;


	private playerAction playerAction;


	
	void Start() 
	{
		setUpButtons();

		playerAction = GameObject.FindGameObjectWithTag("Player").GetComponent<playerAction>();
		buttonFour.text = "Bye";
	}


	public void leaveConversation()
	{
		playerAction.setIfInActionState(false);
		playerAction.setState("idle", null);
		this.GetComponentInParent<DialogPanelController>().setHasDipPanelSpawned(false);
		Destroy(this.gameObject);
	}


	private void setUpButtons()
	{
		ArrayList listOfButtons = new ArrayList(GameObject.FindObjectsOfType<Text>());

		foreach(Text text in listOfButtons)
		{
			Debug.Log("Button Name: " + text.name);
		}

		for(int count = 4; count > -1; count--)
			{
				switch(count)
				{
					case 4: body = (Text)listOfButtons[count];
					break;
					case 3: buttonOne = (Text)listOfButtons[count];
					break;
					case 2: buttonTwo = (Text)listOfButtons[count];
					break;
					case 1: buttonThree = (Text)listOfButtons[count];
					break;
					case 0: buttonFour = (Text)listOfButtons[count];
					break;
				}
			}
	}
}
