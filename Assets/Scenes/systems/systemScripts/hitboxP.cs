using UnityEngine;

public class hitboxP : MonoBehaviour
{
    public spawner S;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //using the Enemies in the list
        //it comparing its own pos with the list of enemies
        //then destroy it too close
        for (int i = S.EList.Count - 1; i >= 0; i--)
        {
            GameObject Enemy = S.EList[i];
            if (Enemy != null)
            {
                Bounds slug = GetComponent<SpriteRenderer>().bounds;
                if (slug.Contains(Enemy.transform.position))
                {
                    Debug.Log("Enemy Destroyed!");
                    Destroy(gameObject);
                    Destroy(Enemy);

                }
            }
        }
    }
}
