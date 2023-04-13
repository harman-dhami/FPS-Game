using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_walk : MonoBehaviour
{
    GameObject enemy;
    public GameObject[] gameObjects;
   
   
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Skeleton@Skin");
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotate = new Vector3(0,180,0);
        transform.Translate(0,0,Time.deltaTime);

        if(transform.position.z >= 10)
        {
            transform.Rotate(rotate);
            transform.Translate(Vector3.back * Time.deltaTime, Space.World);
        }
        else if(transform.position.z <= 0)
        {
            transform.Rotate(rotate);
            transform.Translate(0,0,Time.deltaTime);
        }
        
    }
}
