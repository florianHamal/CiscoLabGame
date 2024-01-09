using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPrefab : MonoBehaviour
{
    private int count = 0;
    private HashSet<GameObject> countedPrefabs = new HashSet<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider's GameObject has a specific component and hasn't been counted before
        if (other.GetComponent<Grap>() != null && !countedPrefabs.Contains(other.gameObject))
        {
            // Increment the count
            count++;
            countedPrefabs.Add(other.gameObject);
        }
    }

    private void end()
    {
        PlayerPrefs.SetInt("finished", 1);
        //end the game
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (count == 4)
        {
            this.end();
        }
    }
}
