using System.Collections;
using UnityEngine;

public class BULLET : MonoBehaviour
{
    public float speed;
    public float timer;
    public float timecap;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer before the bullet expires
        if (timer >= timecap)
        {
            StartCoroutine(lifetime());
        }
        else
        {
            timer += 1 * Time.deltaTime;
        }
        //moves the bullet
        transform.position += transform.up * speed * Time.deltaTime;

    }
    IEnumerator lifetime()
    {
        Destroy(gameObject);
        yield return null;
    }
}
