using UnityEngine;

public class hitscan : MonoBehaviour
{
    public player p;
    public GameObject RotP;
    public Vector2 Transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = p.MousePos;
        RotP.transform.up = p.MousePos - (Vector2)p.transform.position;
    }
}
