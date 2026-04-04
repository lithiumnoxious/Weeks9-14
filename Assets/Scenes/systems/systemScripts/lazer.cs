using System.Collections;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public Transform beamtrans;
    public float Currentlength;
    public float Maxlength;



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
            StartCoroutine(ignite());

        }
        else
        {
            timer += Time.deltaTime;
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
            yield return new WaitForSeconds(0.05f);
        }
        beamtrans.localScale = new Vector3(1,0,1);
        
       
        yield return null;
    }

    IEnumerator retract()
    {


        yield return null;
    }


}
