using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{    
    public GameObject prefab;
    public int poolSize = 40;

    private List<GameObject> pooledObjects;

    private void Start() {
        pooledObjects = new List<GameObject>(poolSize);

        for (int i = 0; i < poolSize; i++) {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject() {
        foreach (GameObject obj in pooledObjects) {
            if (!obj.activeInHierarchy) {
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab);
        pooledObjects.Add(newObj);
        return newObj;
    }
}
