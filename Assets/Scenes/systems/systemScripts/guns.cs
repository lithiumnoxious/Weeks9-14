using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI.Table;

public class guns : MonoBehaviour
{
    public Vector2 movement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePos - (Vector2)transform.position;
        transform.up = direction;
    }
    public void onPoint(InputAction.CallbackContext context)
    {
        //Vector2 direction = (context.ReadValue<Vector2>()) - (Vector2)transform.position;
        //transform.up = direction;

        movement = Camera.main.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }


}
