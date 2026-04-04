using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Danger : MonoBehaviour
{

    public SpriteRenderer bulletE;
    public SpriteRenderer lazerE;
    public bool isindanger = false;
    public UnityEvent entereddanger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if (bulletE.bounds.Contains(transform.position) || lazerE.bounds.Contains(transform.position))
            {
                if (isindanger == true)
                {
                //still in the hazard
                Debug.Log("hazard");

            }
            else
                {
                    //first frame to have entered hazard
                    isindanger= true;
                    Debug.Log("entered hazard");
                    entereddanger.Invoke();
                }
            }
            else
            {
                if (isindanger== true)
                {
                    //first fame out of the hazard
                    isindanger = false;
                    Debug.Log("exited hazard");
                }
            }
        }
    }
