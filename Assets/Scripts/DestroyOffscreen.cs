using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour {

    public float offset = 16f;
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenY = 0;
    private Rigidbody2D body2d;

  	// Use this for initialization
	void Start () {
        offscreenY = -((Screen.height / PixelPerfectCamera.pixelsToUnits)/2 +  offset);
	}
	
	// Update is called once per frame
	void Update () {

        var posY = transform.position.y;
       
        if(posY < offscreenY) { offscreen = true; }
        else { offscreen = false;  }
        
        // Calls OnOutofBounds method if object is offscreen
        if (offscreen)
        {
            OnOutofBounds();
        }
	}

    public void OnOutofBounds()
    {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject); 

        // Calls DestroyCallback event when object dies
        if(DestroyCallback != null)
        {
            DestroyCallback();
        }
    }
}
