using System.Collections;
using UnityEngine;

public class BULLET : MonoBehaviour
{
    public float speed;
    //public bulletspawner bull;

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
            StartCoroutine(lifetime());
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }

        transform.position += transform.up * speed * Time.deltaTime;

    }

    IEnumerator lifetime()
    {
        Destroy(gameObject);
        //bull.Bullets.Add(gameObject);

        timer = 0;
        yield return null;


    }
}
