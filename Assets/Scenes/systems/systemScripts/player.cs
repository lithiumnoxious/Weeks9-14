using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public Animator ani;
    public AudioSource step;
    public Vector2 movement;
    public Vector3 rot;
    public float speed = 5;

    public SpriteRenderer sr;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        if ((movement.x == 0 ) && (movement.y == 0))
        {
            ani.SetBool("isWalking", false);
        }
    }
    public void onMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

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
}
