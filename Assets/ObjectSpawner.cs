using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public Transform spawnParent;
    public Vector3 localPosition;
    
    public void SpawnObject(GameObject objectToSpawn)
    {
        GameObject go = Instantiate(objectToSpawn);
        go.transform.parent = spawnParent;
        go.transform.localPosition = new Vector3(0, -5, 0);
    }
}
