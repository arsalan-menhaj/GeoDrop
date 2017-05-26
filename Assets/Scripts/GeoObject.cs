using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoObject : MonoBehaviour {

    public Sprite[] shapes;
    public float delay = 2.0f;
	public bool clicked = false;
    public float switchTime;
    public int spriteIndex = 0;

    
    // Use this for initialization
    void Start () {

        var renderer = GetComponent<SpriteRenderer>();

        // Randomizes the starting shape
        System.Random rand = new System.Random();
        spriteIndex = rand.Next(0, shapes.Length - 1); 
        renderer.sprite = shapes[spriteIndex];
        
    }

	
	// Update is called once per frame
	void Update () {

        // Falling speed
        float yspeed = -20f; // Why is this so slow?
        transform.Translate(0, yspeed * Time.deltaTime, 0);

        var renderer = GetComponent<SpriteRenderer>();

		/*
		if (Input.GetMouseButtonDown (0)) { 
			RaycastHit hit;
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, hit)) { clicked = true; }
		}

		// Loops through shapes
		if (!clicked)
		{
        	if (Time.time >= switchTime + delay)
        	{
            	if (spriteIndex < shapes.Length - 1) { spriteIndex++; }
            	else { spriteIndex = 0; }
            	renderer.sprite = shapes[spriteIndex];

            	// Sets the time for the next switch
            	switchTime = Time.time;
        	}
		}
*/

    }

}
