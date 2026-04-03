using UnityEngine;
using UnityEngine.InputSystem;

public class controllerinput : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public Vector3 rot;
    public float rotSpeed = 100;
    public float pointval;
    public AudioSource SFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rot = transform.eulerAngles;
        //rot.z = pointval;

        transform.position += (Vector3)movement *speed * Time.deltaTime;
        transform.eulerAngles += (Vector3)rot * speed * Time.deltaTime;
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

    public void onlook(InputAction.CallbackContext context)
    {
        //rot = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
        rot = context.ReadValue<Vector2>();
    }
}
