using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MonoBehaviour, ActionState
{
    Rigidbody2D rb2d;
    public float jumpForce = 2000f;
	Sprite s1;
	Sprite s2;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		s1 = Resources.LoadAll<Sprite>("runguyjump")[0];
		s2 = Resources.LoadAll<Sprite>("runguyjump")[1];
    }

    public void Action()
    {
        rb2d.AddForce(Vector2.up * jumpForce);
    }
	
	public Sprite GetSprite(){
		if((int)(Time.time * 5) % 2 == 0){
			return s1;
		}
		return s2;
	}
}
