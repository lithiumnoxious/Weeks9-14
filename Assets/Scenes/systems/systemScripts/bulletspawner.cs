using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class bulletspawner : MonoBehaviour
{
    public float MaxAmmo;
    public float CurrentAmmo;

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

        if (context.performed)
        {
            StartCoroutine(fire());
        }

    }

    IEnumerator fire()
    {
        SpawnedBullet = Instantiate(Bullet, transform.position,transform.rotation);
        Bullets.Add(SpawnedBullet);
        yield return null;


    }
}
