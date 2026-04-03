using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class bulletspawner : MonoBehaviour
{
    public int MaxAmmo;
    public int CurrentAmmo;

    Coroutine Reload;
    Coroutine Fire;

    public GameObject Bullet;
    public GameObject SpawnedBullet;

    public List<GameObject> Bullets = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onShoot(InputAction.CallbackContext context)
    {
        
        //Fire = StartCoroutine(fire());



        if (context.performed && CurrentAmmo > 0)
        {
            StartCoroutine(fire());
            CurrentAmmo -= 1;
        }

        if (context.performed && CurrentAmmo <= 0)
        {

            StartCoroutine(reload());
        }
    }

    IEnumerator fire()
    {
        
        SpawnedBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Bullets.Add(SpawnedBullet);
        Debug.Log("Current " + CurrentAmmo);
        yield return null;

    }
    IEnumerator reload()
    {
        while (CurrentAmmo<MaxAmmo)
        {
            //if (Reload != null)
            //{
            //    StopCoroutine(Fire);
            //}

            CurrentAmmo += 1;
            
            Debug.Log("reloading " + CurrentAmmo);
            yield return new WaitForSecondsRealtime(1f);


        }
    }
}
