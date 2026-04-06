using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class lazer : MonoBehaviour
{
    public Transform beamtrans;
    public SpriteRenderer sr;
    public float Currentlength;
    public float Maxlength;

    public float timer;
    public float timecap;

    public player P;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timecap)
        {
            StartCoroutine(ignite());
        }
        else
        {
            timer += Time.deltaTime;
        }
        Bounds hitbox = GetComponent<SpriteRenderer>().bounds;
        if (hitbox.Contains(P.transform.position))
        {
            Debug.Log("lazer Hitting player!");
            P.ishot = true;
        }
        else
        {
            P.ishot = false;
        }
    }
    IEnumerator ignite()
    {
        timer = 0;
        Currentlength = 0;
        
        while (Currentlength < Maxlength)
        {
            Currentlength += 3*Time.deltaTime;
            beamtrans.localScale += new Vector3(0,Currentlength,0);
            beamtrans.localScale = new Vector3(1, 0, 1);
            
            yield return new WaitForSeconds(0.05f);
        }
        //resets the object to its original postition
        //its like this because only the Y value actually changes
        
        yield return null;
    }
}
