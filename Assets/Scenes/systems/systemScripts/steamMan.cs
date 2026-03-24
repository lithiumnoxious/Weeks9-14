using UnityEngine;
using UnityEngine.InputSystem;

public class steamMan : MonoBehaviour
{
    public Animator Animator;
    public Vector2 move;
    public float speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)move * speed * Time.deltaTime;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        Animator.SetTrigger("run");
    }
}
