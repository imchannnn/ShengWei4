 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generating : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPoint;
    GameObject newObject;
    public void PrefabAppear()
    {
        newObject=Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        Invoke("PrefabDestroy",10f);
    }
    public void PrefabDestroy()
    {
        Destroy(newObject);
    }
}
