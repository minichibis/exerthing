using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ObsCom
{
    void registerObserver(ObsServ o);
	void removeObserver(ObsServ o);
	void notifyObserver();
}
