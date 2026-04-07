using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class localmultman : MonoBehaviour
{
    public List<PlayerInput> players;
    public List<Sprite> playersprites;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onplayerjoin(PlayerInput player)
    {
        players.Add(player);

        multiplayerconetnsf controller = player.GetComponent<multiplayerconetnsf>();
        controller.manager = this;


        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playersprites[player.playerIndex];

        

    }

    public void PlayerAttacking(PlayerInput attackingplayer)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (attackingplayer == players[i]) continue;


            if (Vector2.Distance(attackingplayer.transform.position, players[i].transform.position) < 0.5f)
                    {
            Debug.Log("player " + attackingplayer.playerIndex + "hits player " + players[i].playerIndex);

                    }
        }
    }
}
