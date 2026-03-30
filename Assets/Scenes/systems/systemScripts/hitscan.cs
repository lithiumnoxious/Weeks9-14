using UnityEngine;

public class hitscan : MonoBehaviour
{
    public player point;
    public GameObject gun;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = point.rot;
        gun.transform.up = point.rot;
    }
}
