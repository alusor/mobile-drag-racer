using UnityEngine;
using System.Collections;

public class CarMods : MonoBehaviour {

	//These are the stock car stats.
	public float acceleration 	= 2.5f;
	public float grip 			= 2.5f;
	public float weight 		= 2.5f;

	//These are the parts installed currently.
	public bool part1Installed = false;
	public bool part2Installed = false;

	void InstallPart ( string partName )//Might need more incoming variables.
	{
		//TODO: Case the part number.
	}

	void RemovePart ( int partNumber)
	{
		//TODO: Case the part number,
	}

}
