using UnityEngine;
using System.Collections;
 
public class CarMods : MonoBehaviour {

	//These are the stock car stats.
	public float acceleration = 2.5f;
	public float grip = 2.5f;
	public float weight = 2.5f;

	//These are the parts installed currently. These are stand-ins
	public bool part1Installed = false;
	public bool part2Installed = false;
	

	void InstallPart ( string partName )//Might need more incoming variables.
	{
		switch (partName)
		{
		case "part1":
			acceleration += Parts.instance.part1; //calls a static script from the empty object "parts"
			part1Installed = true;
			break;
		case "part2":
			grip += Parts.instance.part2; //calls a static script from the empty object "parts"
			part2Installed = true;
			break;
		default:
			Debug.Log("Part not found! Cannot be installed.");
			break;
		}
	}

	void RemovePart ( string partName )
	{
		switch (partName)
		{
		case "part1":
			acceleration -= Parts.instance.part1; //calls a static script from the empty object "parts"
			part1Installed = false;
			break;
		case "part2":
			grip -= Parts.instance.part2; //calls a static script from the empty object "parts"
			part2Installed = false;
			break;
		default:
			Debug.Log("Part not found! Cannot be removed.");
			break;
		}
	}
}
