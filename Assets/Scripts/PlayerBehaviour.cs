using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, ObsCom
{
    public Rigidbody2D rb2d;
    public Collider2D duckCollider;
    public Collider2D baseCollider;
	public List<ObsServ>observers = new List<ObsServ>();
	public SpriteRenderer renderer;
    public AudioClip hitSound;
	public GameObject gameManager;

	private GameManager gManager;
    private ActionState curState;

    // Start is called before the first frame update
    void Start()
    {
        curState = gameObject.GetComponent<RunningState>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        duckCollider.enabled = false;
		gManager = gameManager.GetComponent<GameManager>();
		registerObserver(GameObject.Find("GameManager").GetComponent<GameManager>() as ObsServ);
    }

    // Update is called once per frame
    void Update()
    {
			if(Input.GetKeyDown(KeyCode.W))
			{
				if(gameObject.GetComponent<RunningState>().enabled || gameObject.GetComponent<DuckingState>().enabled){
					Jump();
					curState.Action();
				}
			}
			else if (Input.GetKeyDown(KeyCode.S))
			{
				if(gameObject.GetComponent<RunningState>().enabled){
					Duck();
					curState.Action();
				}
			}
		notifyObserver();
		renderer.sprite = curState.GetSprite();
    }

    public void Jump()
    {
		//gManager.time -= 5;
        gameObject.GetComponent<RunningState>().enabled = false;
		gameObject.GetComponent<DuckingState>().enabled = false;
        gameObject.GetComponent<JumpState>().enabled = true;
        curState = gameObject.GetComponent<JumpState>();
    }

    public void Duck()
    {
		//gManager.time -= 5;
		gameObject.GetComponent<RunningState>().enabled = false;
        gameObject.GetComponent<DuckingState>().enabled = true;
        curState = gameObject.GetComponent<DuckingState>();
        Invoke("Reset", 0.8f);
    }

    public void Reset()
    {
		if(gameObject.GetComponent<DuckingState>().enabled){
			gameObject.GetComponent<DuckingState>().enabled = false;
			baseCollider.enabled = true;
			duckCollider.enabled = false;
			gameObject.GetComponent<RunningState>().enabled = true;
			curState = gameObject.GetComponent<RunningState>();
		}
    }
	
	public void registerObserver(ObsServ o)
	{
		observers.Add(o);
	}
	
	public void removeObserver(ObsServ o)
	{
		observers.Remove(o);
	}
	
	public void notifyObserver()
	{
		foreach(ObsServ g in observers){
			g.updateObserver();
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Kill(other.gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    Debug.Log("Player Hit Obstacle [Collision]");
        //    //Do something to the player to indicate they hit the obstacle (feedback)
        //    //Here

        //    //Possibly decrement amount of running time after being hit
        //    //Here
        //}
		if(gameObject.GetComponent<JumpState>().enabled){
			gameObject.GetComponent<RunningState>().enabled = true;
			gameObject.GetComponent<JumpState>().enabled = false;
			curState = gameObject.GetComponent<RunningState>();
		}
    }
	
	public void Kill(GameObject other)
	{
		Debug.Log("Player Hit Obstacle [Trigger]");
		//Do something to the player to indicate they hit the obstacle (feedback)
		//Here
		if(!gManager.killed){
			AudioSource.PlayClipAtPoint(hitSound, other.transform.position);
			gManager.time -= (11 - gManager.power);
		}

		//Possibly decrement amount of running time after being hit
		//Here
	}
}
