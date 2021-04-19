using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MonoBehaviour, ActionState
{
	Sprite s1;
	Sprite s2;
	Sprite s3;
	Sprite s4;
	
    // Start is called before the first frame update
    void Start()
    {
        s1 = Resources.LoadAll<Sprite>("runguyrun")[0];
		s2 = Resources.LoadAll<Sprite>("runguyrun")[1];
		s3 = Resources.LoadAll<Sprite>("runguyrun")[2];
		s4 = Resources.LoadAll<Sprite>("runguyrun")[3];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Action()
    {

    }
	
	public Sprite GetSprite(){
		int t = (int)(Time.time * 5);
		if(t % 4 == 0){
			return s1;
		}else if(t % 4 == 1){
			return s2;
		}else if(t % 4 == 2){
			return s3;
		}else{
			return s4;
		}
	}
}
