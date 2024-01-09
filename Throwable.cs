using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Throwable : MonoBehaviour
{
    //public GameObject player;
    public Vector3 flyDirection; // Adjust the vector as needed
    public float speed = 0.4f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //flyDirection = (player.transform.position - transform.position);
        transform.Translate(flyDirection * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        Destroy(gameObject);
    }
}
