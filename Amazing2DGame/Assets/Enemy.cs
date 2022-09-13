using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Hitpoints;
    public float MaxHitpoints = 5;
    public bool combatTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        Hitpoints = MaxHitpoints;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
