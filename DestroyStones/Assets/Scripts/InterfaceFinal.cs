using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InterfaceFinal : MonoBehaviour {

	public Text textThrown;
	public Text textDestroyed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textThrown.text = "Number of Stones: " + GameManager.currentNumberStonesThrown;
		textDestroyed.text = "Destroyed: " + GameManager.currentNumberDestroyedStones;

	}

	public void Click(){
		Application.LoadLevel ("Awake");
	}
}
