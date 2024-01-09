using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public int spawnInterval = 5;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Spawn()
    {
        GameObject spawnedPrefab = Instantiate(prefab, transform.position,transform.rotation);
        spawnedPrefab.GetComponent<Throwable>().flyDirection = (player.transform.position-this.transform.position);
        spawnedPrefab.GetComponent<Throwable>().player = this.player;
    }
}
