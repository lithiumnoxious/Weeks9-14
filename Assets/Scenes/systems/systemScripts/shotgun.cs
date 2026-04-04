using System.Collections;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public bulletspawner bs;
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

            bs.SpawnedBullet = Instantiate(bs.Bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90 + randomZ));
            bs.Bullets.Add(bs.SpawnedBullet);
            
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return null;
    }
}
