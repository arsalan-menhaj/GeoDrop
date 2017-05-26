// What is this script attached to??

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    public RecycleGameObject prefab; // The hell does this do?

    // List of 
    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();

    // Method to create new instance GameObject if none exist in pool
    private RecycleGameObject CreateInstance(Vector3 pos)
    {
        var clone = GameObject.Instantiate(prefab);
        clone.transform.position = pos;
        clone.transform.parent = transform;

        poolInstances.Add(clone);

        return clone;
    }

    
    public RecycleGameObject NextObject(Vector3 pos)
    {
        RecycleGameObject instance = null;

        // Loops through each GameObject in pool. 
        // If instance is deactivated, it becomes the reference for the next instance that will appear
        // Note: instance.restart is called outside of this loop, and is only called once
        foreach(var go in  poolInstances) {
            if(go.gameObject.activeSelf != true) {
                instance = go;
                instance.transform.position = pos;
            }
        }

        // If no deactivated instances exist, a new instance is created
        if (instance == null) { instance = CreateInstance(pos); }

        instance.Restart();
        return instance;
    }
}
