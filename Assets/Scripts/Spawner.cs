using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour {
    
    public GameObject[] prefabs;
    public float referenceWidth;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

    // Use this for initialization
    void Start()
    {
        ResetDelay();
        StartCoroutine(ObjectGenerator());

        // Fixes spawner position to top left of screen
        float spawnerPosX = (-Screen.width / PixelPerfectCamera.pixelsToUnits) / 2;
        float spawnerPosY = (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2;
        Vector3 spawnerPos = new Vector3 (spawnerPosX,spawnerPosY,0); 
        transform.position = spawnerPos;
    }

    IEnumerator ObjectGenerator(){
        yield return new WaitForSeconds(delay); // Pauses execution for however many seconds

        // Spawns new obstacle if active = true
        if (active)
        {
			// Ensures instances fall in 'lanes' according to size of sprite
			// Randomizes starting position of each GeoObject instance
			referenceWidth = prefabs[0].GetComponent<GeoObject>().shapes[0].bounds.size.x + 8;
            System.Random rand = new System.Random();
            int laneIndex = rand.Next(1, System.Convert.ToInt32(Screen.width / (referenceWidth*PixelPerfectCamera.pixelsToUnits)));
            float xrand = laneIndex*referenceWidth;
            Vector3 newPosition = new Vector3 (this.transform.position.x + xrand, this.transform.position.y, this.transform.position.z);
            GameObjectUtil.Instantiate(prefabs[0], newPosition);


            ResetDelay();
        }

        StartCoroutine(ObjectGenerator());

    }
	
    // Resets Delay value between 1 and 2
    // TO DO: adjust delay according to level
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }
}
