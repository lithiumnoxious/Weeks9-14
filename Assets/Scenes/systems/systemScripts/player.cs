using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Animator ani;
    public AudioSource step;
    public Vector2 movement;

    public float speed = 5;

    public SpriteRenderer sr;

    public Vector2 MousePos;

    public float MaxPHp = 100;
    public float PHp = 100;
    public bool ishot = false;
    public bool isdead = false;
    public float recovery = 10;
    public float c = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        PHp = MaxPHp;
    }

    // Update is called once per frame
    void Update()
    {

        if (!ishot)
        {
            //movement
            transform.position += (Vector3)movement * speed * Time.deltaTime;
            //cope = transform;
        }

        //switches between standing and walking animation
        if ((movement.x == 0) && (movement.y == 0))
        {
            ani.SetBool("isWalking", false);
        }

    }
    public void onMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        //changes depending on which side the player is facing
        ani.SetBool("isWalking", true);
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    public void steps()
    {
        step.Play();
    }
    public void onPoint(InputAction.CallbackContext context)
    {
        MousePos = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    public void hurt(float damage)
    {
        //are they already dead
        if (isdead) return;
        PHp -= damage;
        Debug.Log("Current " + PHp);
        //do they die
        if (!isdead && PHp <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        PHp = 0;
        isdead = true;
    }

    public void Beamed()
    {
        StartCoroutine(stagger());
    }

    IEnumerator stagger()
    {
        for (int i = 0; i < recovery; i++)
        {
            ishot = true;
        }
        ishot = false;
        yield return new WaitForSeconds(0.05f);
    }
}
