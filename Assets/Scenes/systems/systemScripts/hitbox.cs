using UnityEngine;
using UnityEngine.Events;

public class hitbox : MonoBehaviour
{
    public GameObject p;

    public float hitDistance = 1.5f;
    public UnityEvent entereddanger;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dist = Vector3.Distance(transform.position, p.transform.position);

        if (dist < hitDistance)
        {
            Debug.Log("Hitting player!");
            entereddanger.Invoke();

            Destroy(gameObject);
        }
    }

}
