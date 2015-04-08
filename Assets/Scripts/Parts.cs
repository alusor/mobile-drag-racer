using UnityEngine;
using System.Collections;

public class Parts : MonoBehaviour {

	public static Parts instance = null;

	//List of all parts and their bonus, these are examples
	public float part1 = 1.0f; //Affects accelaration
	public float part2 = 8.5f; //Affects grip

	//Makes sure this script is a singleton
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this;
		
		else if (instance != this)	
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a Parts.
			Destroy(gameObject);    
		
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
}
