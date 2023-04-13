using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Box : MonoBehaviour
{
    public int enemy_health = 100;
    public Animator anim1;
    
    void Awake() {
        anim1 = GetComponent<Animator>();
    }
    

    

    public void DamageToEnemy(int damage) 
    {
        enemy_walk enemies = GetComponent<enemy_walk>();
        foreach(GameObject enemy in enemies.gameObjects)
        {    
        enemy_health = enemy_health - damage;

        if(enemy_health <= 0)
        {
            anim1.SetTrigger("Die");
            enemy.transform.Translate(0,0,0);
        }
        }
    }

}
