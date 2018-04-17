using UnityEngine;
using System.Collections;

public class MainLoop: MonoBehaviour {
	
	public GameObject[] stones = new GameObject[3]; //Array donde almacenar los 3 prefabs
	public float torque = 5.0f; //Torsion, para que la piedra cuando nazca tenga rotación inicial
	public float minAntiGravity = 20.0f, maxAntiGravity = 40.0f;
	public float minLateralForce = -15.0f, maxLateralForce = 15.0f;
	public float minTimeBetweenStones = 1f, maxTimeBetweenStones = 3f;
	public float minX = -30.0f, maxX = 30.0f;
	public float minZ = -5.0f, maxZ = 20.0f;
	
	private bool enableStones = true;
	private Rigidbody rigidbody;
	
	// Use this for initialization
	void Start () {
		GameManager.currentNumberDestroyedStones = 0;
		GameManager.currentNumberStonesThrown = 0;
		StartCoroutine(ThrowStones());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator ThrowStones()
	{
		// Initial delay
		yield return new WaitForSeconds(2.0f);
		
		while(enableStones) {

			if (GameManager.currentNumberStonesThrown == 100) {
				Application.LoadLevel ("Final");
				Time.timeScale = Time.timeScale + 1;
				//Application.LoadLevel ("Final");
			}
				

			GameObject stone = (GameObject) Instantiate(stones[Random.Range(0, stones.Length)]);
			stone.transform.position = new Vector3(Random.Range(minX, maxX), -30.0f, Random.Range(minZ, maxZ));
			stone.transform.rotation = Random.rotation;

			rigidbody = stone.GetComponent<Rigidbody>();

			//Rotación de la roca
			rigidbody.AddTorque(Vector3.up * torque, ForceMode.Impulse);
			rigidbody.AddTorque(Vector3.right * torque, ForceMode.Impulse);
			rigidbody.AddTorque(Vector3.forward * torque, ForceMode.Impulse);
			
			rigidbody.AddForce(Vector3.up * Random.Range(minAntiGravity, maxAntiGravity), ForceMode.Impulse); //Se va hacia arriba o abajo
			rigidbody.AddForce(Vector3.right * Random.Range(minLateralForce, maxLateralForce), ForceMode.Impulse);	//Se va hacia derecha o izquierda

			GameManager.currentNumberStonesThrown++; //Numero de piedras que el juego lanza



			yield return new WaitForSeconds(Random.Range(minTimeBetweenStones, maxTimeBetweenStones));
			
		}
		
	}
}

