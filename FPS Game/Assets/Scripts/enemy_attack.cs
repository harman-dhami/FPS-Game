using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class enemy_attack : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    Animator anim2;
    
    // Start is called before the first frame update
    void Start()
    {
        anim2 = GetComponent<Animator>();

        Directory.CreateDirectory("Assets/movementPattern/Enemy_location/");
        writeToFile();

        
    }

    // Update is called once per frame
    void Update()
    {
        Gun_Shoot playerHealth = GetComponent<Gun_Shoot>();
        enemy_walk enemies = GetComponent<enemy_walk>();

        player = GameObject.Find("PlayerCapsule");
        

        Vector3 tDirection = player.transform.position - transform.position;

        foreach (GameObject enemy in enemies.gameObjects)
        {
            
        

        float enemyX = enemy.transform.position.x;
        float playerX = player.transform.position.x;

        float enemyZ = enemy.transform.position.z;
        float playerZ = player.transform.position.z;

        if(Vector3.Distance(player.transform.position, transform.position) <= 5.0f)
        {
            Vector3 newRotation = Vector3.RotateTowards(transform.forward, tDirection, Time.deltaTime * 2, 0.0f);
            transform.rotation = Quaternion.LookRotation(newRotation);
            transform.Translate(0,0,Time.deltaTime);
            anim2.SetTrigger("Run");
            
        }
        else if(enemyX - playerX < 5 && enemyZ - playerZ < 5)
        {
            anim2.SetTrigger("Attack"); 
        }

        
        
        }
        
    }

    public void writeToFile()
    {
        enemy_walk enemies = GetComponent<enemy_walk>();
        string newFile = "Assets" + "/movementPattern/" + "Enemy_location/" + "location" + ".txt";
        if (!File.Exists(newFile))
        {
            File.WriteAllText(newFile, "Coordinates of the first enemy \n \n");
        }
        
        for(int i=0; i< 1; i++)
        {
            string enemyXValue = "The x value for the first enemy is: " + enemies.gameObjects[i].transform.position.x + "\n \n";
            File.AppendAllText(newFile, enemyXValue);

                string enemyZValue = "The z value for the first enemy is: " + enemies.gameObjects[i].transform.position.z + "\n \n";
                File.AppendAllText(newFile, enemyZValue);

        }
        
    }

}
