using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealthBar : MonoBehaviour 
{
	public Slider healthSlider;
    public Vector3 sliderOffset;
    public Slider healthSliderPrefab;
    public Canvas canvas;


	private NPCInteraction npcInteraction;
    private bool takenDamage;
	

    public void Start ()
    {
        createHealthSlider();

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


    private void createHealthSlider()
    {
            Vector2 spawnPosition = new Vector2(this.transform.position.x, this.transform.position.y + sliderOffset.y);
            healthSlider = Instantiate(healthSliderPrefab, spawnPosition, Quaternion.identity, canvas.transform) as Slider;
    }
}
