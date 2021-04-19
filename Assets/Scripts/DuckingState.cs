using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingState : MonoBehaviour, ActionState
{
    PlayerBehaviour player;
	Sprite s1;
	Sprite s2;

    void Start()
    {
        player = this.gameObject.GetComponent<PlayerBehaviour>();
		s1 = Resources.LoadAll<Sprite>("runguyslide")[0];
		s2 = Resources.LoadAll<Sprite>("runguyslide")[1];
    }

    public void Action()
    {
        player.baseCollider.enabled = false;
        player.duckCollider.enabled = true;
    }
	
	public Sprite GetSprite(){
		if((int)(Time.time * 10) % 2 == 0){
			return s1;
		}
		return s2;
	}
}
