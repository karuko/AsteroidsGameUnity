using UnityEngine;
using System.Collections;


public class InterfaceAwake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameManager.currentNumberDestroyedStones = 0;
		GameManager.currentNumberStonesThrown = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Click(){
		Application.LoadLevel ("stoneGame");
	}
}
