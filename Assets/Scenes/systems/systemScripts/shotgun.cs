using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public SpriteRenderer bsr;
    public GameObject Buck;
    public GameObject SpawnedBuck;


    public List<GameObject> Bucks = new List<GameObject>();

    public float timer;
    public float timecap;

    public float MaxBuck;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timecap)
        {
            StartCoroutine(shoot());
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }
    }

    IEnumerator shoot()
    {

        timer = 0;
        for (int buckshot = 0; buckshot <= MaxBuck; buckshot++)
        {
            float randomZ = Random.Range(-20f, 20f);
            //spawns bullet
            //Quaterion identity is used to make sure the bullet is going up
            //added random range for the shotgun spread.

            SpawnedBuck = Instantiate(Buck, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90 + randomZ));
            Bucks.Add(SpawnedBuck);
            
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return null;
    }
}
