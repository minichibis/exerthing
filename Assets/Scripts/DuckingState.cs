using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingState : MonoBehaviour, ActionState
{
    PlayerBehaviour player;

    void Start()
    {
        player = this.gameObject.GetComponent<PlayerBehaviour>();
    }

    public void Action()
    {
        player.baseCollider.enabled = false;
        player.duckCollider.enabled = true;
    }
}
