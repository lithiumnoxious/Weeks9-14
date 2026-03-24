using System.Collections;
using UnityEngine;

public class grow : MonoBehaviour
{
    public Transform treetrans;
    public Transform appletrans;
    public float apes = 2;

    Coroutine thegrow;
    Coroutine thetree;
    Coroutine theapple;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        treetrans.localScale = Vector2.zero;
        appletrans.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startgrow()
    {
        if(thegrow != null)
        {
            StopCoroutine(thegrow);
        }

        if(thetree != null)
        {
            StopCoroutine (thetree);
        }
        if (theapple != null)
        {
            StopCoroutine(theapple);
        }


        thegrow = StartCoroutine(growTree());

        StartCoroutine(growTree());
    }
    IEnumerator growTree()
    {
        appletrans.localScale = Vector2.zero;
       
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            treetrans.localScale = Vector2.one * t;
            yield return null;
        }

        yield return new WaitForSeconds(apes);

        StartCoroutine(growApple());
        //while (t > 0 )
        //{
        //    t -= Time.deltaTime;
        //    treetrans.localScale = Vector2.one * t;
        //    yield return null;
        //}
    }
    IEnumerator growApple()
    {
        appletrans.localScale = Vector2.zero;
        float t = 0;
        t = 0;


        while (t < 1)
        {
            t += Time.deltaTime;
            appletrans.localScale = Vector2.one * t;
            yield return null;
        }

        yield return null;

    }
}
