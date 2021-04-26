using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPooler : MonoBehaviour
{
	public List<MoverPool> pools = new List<MoverPool>(2);
	
    // Start is called before the first frame update
    void Start()
    {
        FillPool(pools[0]);
		FillPool(pools[1]);
		Spawn(pools[0]);
		Spawn(pools[1]);
		Spawn(pools[0]);
		Spawn(pools[1]);
		Spawn(pools[0]);
		Spawn(pools[1]);
		pools[0].Reposition(0);
		pools[0].Reposition(0);
		pools[0].Reposition(1);
		pools[1].Reposition(0);
		pools[1].Reposition(0);
		pools[1].Reposition(1);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 2; i++){
			pools[i].dist += pools[i].vel* Time.deltaTime;
			if(pools[i].dist >= pools[i].length){
				pools[i].dist -= pools[i].length;
				Spawn(pools[i]);
			}
		}
    }
	
	public void FillPool(MoverPool m){
		m.pool = new List<GameObject>(m.size);
		for(int i = 0; i < m.size; i++){
			m.pool.Add(GameObject.Instantiate(m.g));
			m.pool[i].SetActive(false);
		}
	}
	
	public void Spawn(MoverPool m){
		m.Spawn();
	}
}
