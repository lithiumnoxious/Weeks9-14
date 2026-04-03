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
        
            if (context.performed && CurrentAmmo > 0)
            {
                StartCoroutine(fire());
                CurrentAmmo -= 1;
            }
            else if (context.performed)
            {
                Debug.Log("Out of ammo, Hold E to reload.");
            }

    }

    public void onReload(InputAction.CallbackContext context)
    {
        if (context.performed && CurrentAmmo < MaxAmmo)
        {
            Reload = StartCoroutine(reload());
        }
    }

    IEnumerator fire()
    {
        SpawnedBullet = Instantiate(Bullet, transform.position, transform.rotation);
        Bullets.Add(SpawnedBullet);
        Debug.Log("Current " + CurrentAmmo);

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

            CurrentAmmo += 1;
            
            Debug.Log("Reloading " + CurrentAmmo);
            yield return new WaitForSeconds(2f);
        }
        Debug.Log("Reloading Done");
        yield return null;
    }
}
