using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, ObsCom
{
    public Rigidbody2D rb2d;
    public Collider2D duckCollider;
    public Collider2D baseCollider;
	public List<ObsServ>observers = new List<ObsServ>();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        baseCollider = gameObject.GetComponent<BoxCollider2D>();
        duckCollider = gameObject.GetComponent<BoxCollider2D>();
        duckCollider.enabled = false;
		registerObserver(GameObject.Find("GameManager").GetComponent<GameManager>() as ObsServ);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Duck();
        }
		notifyObserver();
    }

    public void Jump()
    {
        rb2d.AddForce(Vector2.up);
        Debug.Log("Jumping");
    }

    public void Duck()
    {
        baseCollider.enabled = false;
        duckCollider.enabled = true;
        Invoke("ResetPos", 1f);
    }

    public void ResetPos()
    {
        baseCollider.enabled = true;
        duckCollider.enabled = false;
    }
	
	public void registerObserver(ObsServ o){
		observers.Add(o);
	}
	
	public void removeObserver(ObsServ o){
		observers.Remove(o);
	}
	
	public void notifyObserver(){
		foreach(ObsServ g in observers){
			g.updateObserver();
		}
	}
}
