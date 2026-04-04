using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class bulletspawner : MonoBehaviour
{
    public int MaxAmmo =10;
    public int CurrentAmmo = 10;
    
    Coroutine Reload;

    public SpriteRenderer bsr;
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
        //when mousepressed the gun fires but only if ammo is above 1
        if (context.performed && CurrentAmmo > 0)
        {
        //this part spawns the bullet and lowers a bullet
            StartCoroutine(fire());
            CurrentAmmo -= 1;
        }
        //if ammo ran out then this text would play
        else if (context.performed)
        {
            Debug.Log("Out of ammo, Hold E to reload.");
        }
    }
    public void onReload(InputAction.CallbackContext context)
    {
        //when E is held and when ammo is below max capacity
        if (context.performed && CurrentAmmo < MaxAmmo)
        {
            //starts reloading
            Reload = StartCoroutine(reload());
        }
    }
    IEnumerator fire()
    {
        //spawns bullet
        SpawnedBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Bullets.Add(SpawnedBullet);
        Debug.Log("Current " + CurrentAmmo);
        //if triggered during reloading
        //then it stops the reloading process.
        if(Reload != null)
        {
            StopCoroutine(Reload);
            Debug.Log("reload stopped");
        }

        yield return null;
    }
    IEnumerator reload()
    {
        while (CurrentAmmo<MaxAmmo)
        {
            //reloads ammo
            CurrentAmmo += 1;
            Debug.Log("Reloading " + CurrentAmmo);
            //gives more time between reload.
            yield return new WaitForSeconds(2f);
        }
        Debug.Log("Reloading Done");
        yield return null;
    }
}
