using UnityEngine;
using UnityEngine.InputSystem;

public class controllerinput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement *speed * Time.deltaTime;
        //transform.position = movement;
    }

    public void onMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
    public void onSound(InputAction.CallbackContext context)
    {
        Debug.Log("attack!" + context.phase);
        if (context.performed) 
        { 
            SFX.Play();
        }
    }

    public void onPoint(InputAction.CallbackContext context)
    {
        //Mouse.current.ReadValue()
        //movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
}
