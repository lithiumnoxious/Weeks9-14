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


    //public GameObject bulletE;

    //public float hitDistance = 1.5f;
    //public UnityEvent entereddanger;
    //public shotgun sg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
        else
        {
            transform.position = Vector2.zero;
        }


        //switches between standing and walking animation
        if ((movement.x == 0 ) && (movement.y == 0))
        {
            ani.SetBool("isWalking", false);
        }



        //for (int i = sg.Bucks.Count - 1; i >= 0; i--)
        //{
        //    GameObject Buck = sg.Bucks[i];
        //    if (Buck != null)
        //    {
        //        float dist = Vector3.Distance(transform.position, Buck.transform.position);

        //        if (dist <= hitDistance)
        //        {
        //            Debug.Log("Hitting player!");
        //            Destroy(Buck);
        //            sg.Bucks.RemoveAt(i);
        //            entereddanger.Invoke();

        //            //    //Destroy(gameObject);
        //            //}


        //        }
        //    }
        //}
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
        //ani.SetTrigger("hurt");

        StartCoroutine(stagger());
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
    public void Continue(InputAction.CallbackContext context)
    {
        if (context.performed && isdead)
        {
            PHp = MaxPHp;
            isdead = false;
            ishot = false;
        }
        
    }

    IEnumerator stagger()
    {
        ishot = true;
        StartCoroutine(stag());
        yield return null;
    }
    IEnumerator stag()
    {
        ishot = false;
        yield return null;
    }
}
