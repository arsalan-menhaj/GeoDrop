// This is a class containing static functions Instantiate, Destroy, GetObjectPool
// The static functions allow GameObjects to be recycled if they have RecycleGameObject component
// This script does not need to be attached to anything, since all it does is define static functions

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectUtil  {

    private static Dictionary<RecycleGameObject, ObjectPool> pools = new Dictionary<RecycleGameObject, ObjectPool>();


    public static GameObject Instantiate(GameObject prefab, Vector3 pos)
    {
        GameObject instance = null;

        // Checks if GameObject has Recycle component, and if so, re-activates next object in object pool
        // Otherwise, creates new instance of GameObject
        var recycledScript = prefab.GetComponent<RecycleGameObject>();
        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject(pos).gameObject;
        } else {
            instance = GameObject.Instantiate(prefab);
            instance.transform.position = pos;
        }

        return instance;
    }

    public static void Destroy(GameObject gameObject)
    {
        // Checks if object has recycle property
        var recycleGameObject = gameObject.GetComponent<RecycleGameObject>();
		if (recycleGameObject != null) { recycleGameObject.Shutdown(); }
		else { GameObject.Destroy(gameObject);  }
     }

    private static ObjectPool GetObjectPool(RecycleGameObject reference)
    {
        ObjectPool pool = null;

        // Assigns GameObject to appropriate pool
        if (pools.ContainsKey (reference)) { pool = pools[reference]; }
        else
        {
            // Creates new ObjectPool if none exist for the prefab
            var poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            pool = poolContainer.AddComponent<ObjectPool>();
            pool.prefab = reference;
            pools.Add(reference, pool);
        }
        return pool; 
    }
}
