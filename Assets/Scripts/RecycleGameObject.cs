// This class contains methods to de-/reactivate objects
// as part of the Recycle property

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleGameObject : MonoBehaviour {

    public void Restart()
    {
        gameObject.SetActive(true);
    }

    public void Shutdown()
    {
        gameObject.SetActive(false);
		gameObject.GetComponent<GeoObject> ().clicked = false;
    }
}
