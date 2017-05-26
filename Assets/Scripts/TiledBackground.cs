using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour {

    public int textureSize = 32;
    public bool scaleHorizontally = true;
    public bool scaleVertically = true;

	// Use this for initialization
	void Start () {

        // Calculate how many times the texture has to be repeated in the x and y directions
        var NewWidth = !scaleHorizontally ? 1 : Mathf.Ceil(Screen.width / (textureSize * PixelPerfectCamera.scale)); 
        var NewHeight = !scaleVertically ? 1 :  Mathf.Ceil(Screen.height / (textureSize * PixelPerfectCamera.scale));

        // Tiles the texture according to above
        transform.localScale = new Vector3(NewWidth * textureSize, NewHeight * textureSize, 1);

        // Assign new texture scale to material
        GetComponent<Renderer>().material.mainTextureScale = new Vector3(NewWidth, NewHeight, 1);
    }
}
