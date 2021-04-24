using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPool : MonoBehaviour
{
	public int size = 3;
	public float dist;
	public float vel;
	public GameObject g;
	public List<GameObject> pool;
	public Vector3 startpos;
	public int current = 0;
	public float length = 17.8f;
	
    // Start is called before the first frame update
    void Start()
    {
		current = 0;
		Reposition(0);
		Reposition(0);
		Reposition(1);
    }

    // Update is called once per frame
    void Update()
    {
		
    }
	
	public void Kill(GameObject g){
		for(int i = 0; i < size; i++){
			if(g == pool[i]){
				g.SetActive(false);
				break;
			}
		}
	}
	
	public void Spawn(){
		pool[current].SetActive(true);
		pool[current].transform.position = startpos;
		current++;
		current = current % size;
	}
	
	public void Reposition(int i){
		pool[i].gameObject.transform.position += transform.right * -20;
	}
}
