using System.Collections;
using UnityEngine;

public class shotgun : MonoBehaviour
{
    public bulletspawner bs;
    public float timer;
    public float timecap;

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
        //spawns bullet
        bs.SpawnedBullet = Instantiate(bs.Bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, -90));
        bs.Bullets.Add(bs.SpawnedBullet);
        yield return null;
    }
}
