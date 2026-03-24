using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class knight : MonoBehaviour
{
    public AudioSource walk;
    public Animator hero;
    public float speed;
    public SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void footstep()
    {
        walk.Play();
    }
    IEnumerable move()
    {



        yield return null;
    }

    IEnumerable attack()
    {


        hero.SetTrigger("attack");
        yield return null;
    }
}
