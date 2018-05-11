using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogPanelController : MonoBehaviour 
{
	public GameObject dialogPanelPrefab;
	public float panelXOffset;
	public float panelYOffset;


	private GameObject player;
	private bool hasDipPanelSpawned;

	
	void Start() 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		hasDipPanelSpawned = false;
	}
	
	
	void Update() 
	{
		spawndiplomacyPanel();
	}


	public void setHasDipPanelSpawned(bool newBool)
	{
		hasDipPanelSpawned = false;
	}


	private void  spawndiplomacyPanel()
	{
		PlayerAction playerAction = player.GetComponent<PlayerAction>();

		if(playerAction.getState().Equals("talk") && playerAction.getIfInActionState() && !hasDipPanelSpawned &&
		Camera.main.GetComponent<CameraMovement>().isCameraMoving())
		{
			Vector2 npc = playerAction.getObjectOfInteraction().transform.position;
			Vector2 cameraPos = Camera.main.transform.position;
			Vector2 panelSpawnPoint = new Vector2(npc.x + panelXOffset, npc.y + panelYOffset);

			Instantiate(dialogPanelPrefab, Camera.main.WorldToScreenPoint(panelSpawnPoint), Quaternion.identity, this.transform);
			hasDipPanelSpawned = true;

			Debug.Log("npc cordonites: " + npc);
		}
	}
}
