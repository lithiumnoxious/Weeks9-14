using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Enemyguns : MonoBehaviour
{
    public player P;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 direction = P.transform.position - transform.position;
        transform.right = direction;

    }
}
