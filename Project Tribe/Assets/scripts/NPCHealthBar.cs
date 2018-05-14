using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour 
{
	public Slider healthSlider;
    public Vector3 sliderOffset;


	private NPCInteraction npcInteraction;
    private bool takenDamage;
	

    public void Start ()
    {
        npcInteraction = GetComponent<NPCInteraction>();
        takenDamage = false;
        updateHealth();
    }


    public void Update ()
    {
        updateHealth();
    }


    private void updateHealth()
    {
        updateHealthSliderPos();
        healthSlider.value = npcInteraction.getCurrentHealth();
    }


    private void updateHealthSliderPos()
    {
        healthSlider.transform.position = Camera.main.WorldToScreenPoint(this.transform.position + sliderOffset);
    }
}
