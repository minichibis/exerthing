using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfEnergyState : MonoBehaviour, ActionState
{
	PlayerBehaviour player;
	Sprite s1;

	void Start()
	{
		player = this.gameObject.GetComponent<PlayerBehaviour>();
		s1 = Resources.LoadAll<Sprite>("runguydie")[0];
	}

	public void Action()
	{
		
	}

	public Sprite GetSprite()
	{
		return s1;
	}
}