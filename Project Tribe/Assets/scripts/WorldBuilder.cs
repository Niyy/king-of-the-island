using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour 
{
	public int widthMax;
	public int heightMax;
	public GameObject desertBlockPrefab;
	public GameObject relicOne, relicTwo, relicThree, relicFour;


	private float xInterval = 0.64f;
	private float yInterval = 0.323f;


	void Start () 
	{
		buildWorld();
	}


	private void buildWorld ()
	{
		float shift = Mathf.Ceil(widthMax) * xInterval;

		for(int height = 0; height < heightMax; height++)
		{
			for (int width = 0; width < widthMax - (height); width++)
			{
				Instantiate(desertBlockPrefab, new Vector3(((width * 2 * xInterval) - shift) + (height * xInterval), 
				height * yInterval, heightMax + height), Quaternion.identity, this.transform);
				Instantiate(desertBlockPrefab, new Vector3(((width * 2 * xInterval) - shift) + (height * xInterval), 
				(-height) * yInterval, heightMax - height), Quaternion.identity, this.transform);
			}
		}
	}
}
