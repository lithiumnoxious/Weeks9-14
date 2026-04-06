using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class hitbox : MonoBehaviour
{
    public player p;
    public float hitDistance = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //compares the postitons of the bullet and player
        //then deals 5 damage if player gets too close
        Bounds hitbox = GetComponent<SpriteRenderer>().bounds;
        if (hitbox.Contains(p.transform.position))
        {
            Debug.Log("Hitting player!");
            p.hurt(5);
            Destroy(gameObject);
        }

    }
}
