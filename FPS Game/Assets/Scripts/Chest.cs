using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{

    GameObject player;

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("PlayerCapsule");

        float playerZ = player.transform.position.z;
        float zPos = transform.position.z;

        if(zPos - playerZ <= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
