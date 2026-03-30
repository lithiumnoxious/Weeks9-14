using UnityEngine;

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
        Vector2 direction = (Vector2)P.transform.position - (Vector2)transform.position;
        transform.right = direction;
    }
}
