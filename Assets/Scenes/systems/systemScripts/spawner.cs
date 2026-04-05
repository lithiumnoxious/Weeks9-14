using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class spawner : MonoBehaviour
{
    public float time1 = 0;
    public float time2 = 0;
    public float timecap = 5;

    public GameObject E1;
    public GameObject SpawnedE1;

    public GameObject E2;
    public GameObject SpawnedE2;

    public player Player;

    //list of both enemy types combined
    public List<GameObject> EList = new List<GameObject>();

    public float hitDistance = 1.5f;
    public UnityEvent entereddanger;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer on when they spawn
        //they have different values
        if (time1 >= timecap)
        {
            StartCoroutine(CloneE1());
        }
        if (time2 >= timecap*2.5)
        {
            StartCoroutine(CloneE2());
        }
        else
        {
            time1 += 1 * Time.deltaTime;
            time2 += 1 * Time.deltaTime;
        }

    }
    //spawning the different enemies
    IEnumerator CloneE1()
    {
        SpawnedE1 = Instantiate(E1, new Vector2(Random.Range(-6f, 6f),Random.Range(-3.5f, 3.5f)), Quaternion.identity);
        Enemyguns rot = SpawnedE1.GetComponentInChildren<Enemyguns>();
        if (rot != null)
        {
            rot.Ppos = Player;
        }
        shotgun gun = SpawnedE1.GetComponentInChildren<shotgun>();
        if (gun != null)
        {
            gun.P = Player;
        }

        EList.Add(SpawnedE1);
        time1 = 0;
        
        yield return null;
    }
    IEnumerator CloneE2()
    {
        SpawnedE2 = Instantiate(E2, new Vector2(Random.Range(-6f, 6f), Random.Range(-3.5f, 3.5f)), Quaternion.identity);
        Enemyguns rot = SpawnedE2.GetComponentInChildren<Enemyguns>();
        if (rot != null)
        {
            rot.Ppos = Player;
        }
        lazer l = SpawnedE2.GetComponentInChildren<lazer>();
        if (l != null)
        {
            l.P = Player;
        }

        EList.Add(SpawnedE2);
        time2 = 0;
        yield return null;
    }
    IEnumerator iskilled()
    {
        

        Debug.Log("hit");
        yield return null;
    }
}
