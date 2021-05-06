using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepShitPlease : MonoBehaviour
{
	public static KeepShitPlease k;
	
	public GameManager m;
	
	public int speed = 1;
    public int stamina = 1;
    public int power = 1;

    public int speedBuff = 0;
    public int stamBuff = 0;
    public int powerBuff = 0;
	
	public bool statted = false;
	
    // Start is called before the first frame update
    void Start()
    {
		m = FindObjectOfType<GameManager>();
		if(k == null){
			k = this;
			DontDestroyOnLoad(gameObject);
		}else{
			Debug.Log("a");
			Destroy(gameObject);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(m == null){
			//Debug.Log(power);
			m = GameObject.Find("GameManager").GetComponent<GameManager>();
			/*if (m != null){
				m.speed = speed;
				m.stamina = stamina;
				m.power = power;
				m.speedBuff = speedBuff;
				m.stamina = stamBuff;
				m.power = powerBuff;
				//Debug.Log(m.power);
			}*/
		}else{
			speed = m.speed;
			stamina = m.stamina;
			power = m.power;
			speedBuff = m.speedBuff;
			stamBuff = m.stamBuff;
			powerBuff = m.powerBuff;
			if(m.isRunning){
				if(!statted){
					statted = true;
					m.time += stamina + stamBuff;
				}
				speedBuff = 0;
				stamBuff = 0;
				powerBuff = 0;
			}else{
				statted = false;
			}
		}
    }
}
