using UnityEngine;
using UnityEngine.InputSystem;

public class multiplayerconetnsf : MonoBehaviour
{
    public localmultman manager;
    public PlayerInput PlayerInput; 
    public Vector2 movInput;
    public float movSpeed = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movInput *movSpeed * Time.deltaTime;
    }

    public void onMove (InputAction.CallbackContext context)
    {
        movInput = context.ReadValue<Vector2>();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player "+ PlayerInput.playerIndex + " attacking");
            manager.PlayerAttacking(PlayerInput);

        }
        
    }
}
