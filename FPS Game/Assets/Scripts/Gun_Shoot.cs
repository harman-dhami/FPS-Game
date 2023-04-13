using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Shoot : MonoBehaviour
{
    Stack myStack = new Stack();
    public int userHealth = 100;
    public int damage = 25;
    public Transform gEnd;
    private Camera userCam;
    LineRenderer bulletLine;
    AudioSource gun_shot_sound;
    private WaitForSeconds shotTime = new WaitForSeconds(1);
    RaycastHit hit;
    
    
    Animator anim;
    void Start()
    {
        bulletLine = GetComponent<LineRenderer> ();
        gun_shot_sound = GetComponent<AudioSource> ();
        userCam = GetComponentInParent<Camera> ();

        
    }

    
    void Update()
    {
        anim = GetComponent<Animator>();
        if(Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShotSound());
            anim.SetTrigger("Shoot");
            bulletLine.SetPosition(0, gEnd.position);

            if(bulletShot())
            {
                bulletLine.SetPosition(1, hit.point);
                Enemy_Box health = hit.collider.GetComponent<Enemy_Box>();

                if(health.enemy_health != null)
                {
                    health.DamageToEnemy(damage);
                    //enemyAnim.SetTrigger("Hit");
                }
            } 
            
        }
    }
    private IEnumerator ShotSound()
    {
        gun_shot_sound.Play ();
        bulletLine.enabled = true;
        yield return shotTime;
        bulletLine.enabled = false;
    }

    private bool bulletShot()
    {
        Ray bullet = new Ray(gEnd.position, userCam.transform.forward);
        return Physics.Raycast(bullet, out hit);
    }
}
